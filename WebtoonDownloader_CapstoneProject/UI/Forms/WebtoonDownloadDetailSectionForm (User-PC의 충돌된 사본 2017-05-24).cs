using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Resources;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebtoonDownloader_CapstoneProject.Core;

namespace WebtoonDownloader_CapstoneProject.UI.Forms
{
	public partial class WebtoonDownloadDetailSectionForm : Form
	{
		private Pen lineDrawer = new Pen( GlobalVar.ThemeColor );
		private string url;
		private int childPreviousX = 0;
		private int currentPage = 1;
		private int maxPage;
		private int maxWebtoonCount;
		private bool pageRequestCancelDo;
		private Task pageRequestTask;

		private Thread pageRequestThread = null;

		private CancellationTokenSource cancelSignal = new CancellationTokenSource( );

		// ** 버그 리스트 **
		// Previous Button & Next Button 을 여러번 누를 시 lock 처리 문제로 인한 중첩 문제 발생
		// 0 화도 표시되는 문제
		// 1 화가 건너뛰어지는 문제
		// 캐시가 필요함 <- 너무 많은 Request 요청 시 네이버 서버에서 block 할 수 있음
		// end at 17-05-22 am 2:28

		public WebtoonDownloadDetailSectionForm( string url )
		{
			InitializeComponent( );

			this.SetStyle( ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw, true );
			this.UpdateStyles( );

			this.Opacity = 0;

			this.url = url;
		}

		private void WebtoonDownloadDetailSectionForm_Load( object sender, EventArgs e )
		{
			Animation.UI.FadeIn( this );

			this.DotAnimationTimer.Start( );

			this.LOADING_LABEL.Visible = true;
			this.SECTION_SET_BUTTON.Visible = false;
			this.POPUP_INFO_PANEL.Visible = false;

			// http://www.hanbit.co.kr/network/category/category_view.html?cms_code=CMS5385068689
			ManualResetEvent trafficLight = new ManualResetEvent( false );

			pageRequestTask = Task.Factory.StartNew( ( ) =>
			{
				int maxWebtoonList = NaverWebtoon.GetWebtoonListCount( this.url );

				if ( maxWebtoonList > 0 )
				{
					this.maxWebtoonCount = maxWebtoonList;

					int i = 1;

					int limit = CalcDynamicRequest( );

					maxPage = ( int ) ( maxWebtoonList / limit );

					if ( this.InvokeRequired )
						this.Invoke( new Action( ( ) => PageIndexInitialize( maxPage ) ) );
					else
						PageIndexInitialize( maxPage );


					//MessageBox.Show( limit.ToString( ) );

					while ( true )
					{
						if ( i >= limit )
							break;

						trafficLight.Reset( );

						CallGetSpecificWebtoonDetailPageInformations( i, ( NaverWebtoon.WebtoonDetailPageInformations info ) =>
						{
							AddChildPanelFromData( Math.Max( i - 1, 1 ), info );
							trafficLight.Set( );
						} );

						i++;
						trafficLight.WaitOne( );
					}



					this.DotAnimationTimer.Stop( );

					this.LOADING_LABEL.Visible = false;
					this.SECTION_SET_BUTTON.Visible = true;
					this.POPUP_INFO_PANEL.Visible = true;


					//int count = 1;
					//foreach ( var info in data )
					//{
					//	AddChildPanelFromData( count++, info );
					//}
				}
			} );
		}

		private void PageIndexClicked( int index )
		{
			currentPage = index + 1;
			PageChange( currentPage );
		}

		private void PageIndexInitialize( int maxPage )
		{
			int x = 0;

			for ( int i = 0; i <= maxPage; i++ )
			{
				WebtoonDownloadDetailSectionPageIndexForm panel = new WebtoonDownloadDetailSectionPageIndexForm( i )
				{
					Location = new Point( x, 0 ),
					Size = new Size( 20, 30 )
				};
				if ( i == 0 )
					panel.BackColor = Color.DimGray;
				else
					panel.BackColor = Color.Silver;

				panel.IndexClicked += PageIndexClicked;

				x += panel.Width + 10;

				this.PAGE_INDEX_PANEL.Controls.Add( panel );
			}

			this.PAGE_INDEX_PANEL.Location = new Point( ( this.Width / 2 ) - ( this.PAGE_INDEX_PANEL.Width / 2 ), this.PAGE_INDEX_PANEL.Location.Y );
			this.PREVIOUS_PAGE_ICON.Location = new Point(
				this.PAGE_INDEX_PANEL.Location.X - this.PREVIOUS_PAGE_ICON.Width - 10,
				this.PAGE_INDEX_PANEL.Location.Y
			);

			this.NEXT_PAGE_ICON.Location = new Point(
				this.PAGE_INDEX_PANEL.Location.X + this.PAGE_INDEX_PANEL.Width + 10,
				this.PAGE_INDEX_PANEL.Location.Y
			);
		}

		// flowLayoutPanel1 패널에 딱 맞는 리퀘스트 사이즈를 가져옴
		private int CalcDynamicRequest( )
		{
			return ( int ) ( 1119 / 40 ) + 1;
		}

		private void NextPage( )
		{
			if ( currentPage >= maxPage )
				return;

			currentPage++;

			PageChange( currentPage );
		}

		private void PreviousPage( )
		{
			if ( currentPage <= 1 )
				return;

			currentPage--;

			PageChange( currentPage );
		}

		private void PageChange( int page )
		{
			if ( pageRequestThread != null && pageRequestThread.IsAlive )
			{
				pageRequestThread.Abort( );
				pageRequestThread = null;
			}

			this.flowLayoutPanel1.Controls.Clear( );

			//if ( pageRequestTask != null )
			//MessageBox.Show( pageRequestTask.IsCompleted.ToString( ) );

			pageRequestThread = new Thread( ( ) =>
			{
				int startNum = CalcDynamicRequest( ) * ( page - 1 );
				int endNum = startNum + CalcDynamicRequest( );

				InternalRequestPage( Math.Max( startNum, 1 ), endNum );
			} )
			{
				IsBackground = true,
				Name = "PageRequestThread"
			};

			pageRequestThread.Start( );

			for ( int i = 0; i < this.PAGE_INDEX_PANEL.Controls.Count; i++ )
			{
				WebtoonDownloadDetailSectionPageIndexForm form = ( WebtoonDownloadDetailSectionPageIndexForm ) this.PAGE_INDEX_PANEL.Controls[ i ];

				if ( form.index == page - 1 )
					form.BackColor = Color.DimGray;
				else
					form.BackColor = Color.Silver;
			}

			//pageRequestThread.Join( );

			//pageRequestTask = Task.Run( ( ) =>
			//{


			//pageRequestTask.Start( );
			//pageRequestTask.Wait( );
		}

		private void InternalRequestPage( int startNum, int endNum )
		{
			ManualResetEvent trafficLight = new ManualResetEvent( true );
			List<NaverWebtoon.WebtoonDetailPageInformations> data = new List<NaverWebtoon.WebtoonDetailPageInformations>( );

			int startNumTemp = startNum;

			for ( ; startNum <= endNum; startNum++ )
			{
				if ( startNum > this.maxWebtoonCount )
					break;

				trafficLight.Reset( );

				CallGetSpecificWebtoonDetailPageInformations( startNum, ( NaverWebtoon.WebtoonDetailPageInformations info ) =>
				{
					data.Add( info );
					trafficLight.Set( );
				} );

				trafficLight.WaitOne( );
			}

			foreach ( var info in data )
			{
				this.Invoke( new Action( ( ) =>
				{
					AddChildPanelFromData( startNumTemp++, info );
				} ) );

			}
			//	AddChildPanelFromData( Math.Max( startNum - 1, 1 ), info );
		}

		private void ChildMouseEntered( int num )
		{
			//POPUP_INFO_PANEL

			int x = Util.Clamp( ( 40 ) * ( num - 1 ), this.Width - this.POPUP_INFO_PANEL.Width - 10, 10 );

			this.POPUP_INFO_PANEL.Location = new Point( x, POPUP_INFO_PANEL.Location.Y );

			CallGetSpecificWebtoonDetailPageInformations( num, ( NaverWebtoon.WebtoonDetailPageInformations info ) =>
			{
				POPUP_INFO_TITLE.Text = info.title;
				POPUP_INFO_NUM.Text = num + " 화";
				POPUP_INFO_THUMBNAIL.Load( info.thumbnail );
			} );

			//MessageBox.Show( x.ToString( ) + " / " + num );
		}

		private void ChildMouseDowned( int num )
		{

		}

		private readonly object locker = new object( );
		private void AddChildPanelFromData( int num, NaverWebtoon.WebtoonDetailPageInformations info )
		{
			lock ( locker )
			{
				if ( this.InvokeRequired )
				{
					this.Invoke( new Action( ( ) =>
					{
						WebtoonDownloadDetailSectionChild panel = new WebtoonDownloadDetailSectionChild( num, info );
						panel.Location = new Point( childPreviousX, 0 );
						panel.ChildMouseEnter += ChildMouseEntered;
						panel.ChildMouseDown += ChildMouseDowned;

						childPreviousX += panel.Width + 5;

						this.flowLayoutPanel1.Controls.Add( panel );
					} ) );
				}
				else
				{
					WebtoonDownloadDetailSectionChild panel = new WebtoonDownloadDetailSectionChild( num, info );
					panel.Location = new Point( childPreviousX, 0 );
					panel.ChildMouseEnter += ChildMouseEntered;
					panel.ChildMouseDown += ChildMouseDowned;

					childPreviousX += panel.Width + 5;

					this.flowLayoutPanel1.Controls.Add( panel );
				}
			}
		}


		private void WebtoonDownloadDetailSectionForm_Paint( object sender, PaintEventArgs e )
		{
			int w = this.Width, h = this.Height;

			e.Graphics.DrawLine( lineDrawer, 0, 0, w, 0 ); // 위
			e.Graphics.DrawLine( lineDrawer, 0, 0, 0, h ); // 왼쪽
			e.Graphics.DrawLine( lineDrawer, w - lineDrawer.Width, 0, w - lineDrawer.Width, h ); // 오른쪽
			e.Graphics.DrawLine( lineDrawer, 0, h - lineDrawer.Width, w, h - lineDrawer.Width ); // 아래
		}

		private void CallGetSpecificWebtoonDetailPageInformations( int num, Action<NaverWebtoon.WebtoonDetailPageInformations> callback )
		{
			lock ( locker )
			{
				Task.Factory.StartNew( ( ) =>
			{
				NaverWebtoon.WebtoonDetailPageInformations? info = NaverWebtoon.GetSpecificWebtoonDetailPageInformations( this.url.Replace( "list.nhn?", "detail.nhn?" ), num );

				if ( info.HasValue )
				{
					if ( this.InvokeRequired )
					{
						this.Invoke( new Action( ( ) =>
						{
							callback.Invoke( info.Value );
						} ) );
					}
					else
						callback.Invoke( info.Value );
				}
			} );
			}
		}

		//private void WEBTOON_END_NUMBER_Leave( object sender, EventArgs e )
		//{
		//	CallGetSpecificWebtoonDetailPageInformations( ( int ) this.WEBTOON_END_NUMBER.Value, ( NaverWebtoon.WebtoonDetailPageInformations info ) =>
		//	{
		//		this.END_THUMBNAIL_IMAGE.Load( info.thumbnail );
		//		this.END_TITLE_LABEL.Text = info.title;
		//	} );
		//}

		private void WebtoonDownloadOptionForm_Shown( object sender, EventArgs e )
		{

		}

		byte dotCount = 0;
		private void DotAnimationTimer_Tick( object sender, EventArgs e )
		{
			if ( dotCount > 2 )
			{
				dotCount = 0;
				if ( this.LOADING_LABEL.Text.Length > 3 )
					this.LOADING_LABEL.Text = this.LOADING_LABEL.Text.Substring( 0, this.LOADING_LABEL.Text.Length - 3 );
			}
			else
			{
				this.LOADING_LABEL.Text = this.LOADING_LABEL.Text + ".";
				dotCount++;
			}
		}

		private bool APP_TITLE_BAR_BeginClose( )
		{
			return true;
		}

		private Image ImageQualityChange( Image baseImage, int quality )
		{
			using ( MemoryStream stream = new MemoryStream( ) )
			{
				using ( Bitmap image = new Bitmap( baseImage ) )
				{
					ImageCodecInfo encoder = ImageCodecInfo.GetImageEncoders( ).First( c => c.FormatID == ImageFormat.Jpeg.Guid );

					using ( EncoderParameters encodingParams = new EncoderParameters( 1 ) )
					{
						encodingParams.Param[ 0 ] = new EncoderParameter( Encoder.Quality, ( long ) quality );
						image.Save( stream, encoder, encodingParams );

						return Image.FromStream( stream );
					}
				}
			}
		}

		private void POPUP_INFO_PANEL_Paint( object sender, PaintEventArgs e )
		{
			int w = this.POPUP_INFO_PANEL.Width, h = this.POPUP_INFO_PANEL.Height;

			e.Graphics.DrawLine( lineDrawer, 0, h - lineDrawer.Width, w, h - lineDrawer.Width ); // 아래
		}

		private void flowLayoutPanel1_Paint( object sender, PaintEventArgs e )
		{
			int w = this.flowLayoutPanel1.Width, h = this.flowLayoutPanel1.Height;

			e.Graphics.DrawLine( lineDrawer, 0, h - lineDrawer.Width, w, h - lineDrawer.Width ); // 아래
		}

		private void NEXT_PAGE_ICON_Click( object sender, EventArgs e )
		{
			NextPage( );
		}

		private void PREVIOUS_PAGE_ICON_Click( object sender, EventArgs e )
		{
			PreviousPage( );
		}
	}
}
