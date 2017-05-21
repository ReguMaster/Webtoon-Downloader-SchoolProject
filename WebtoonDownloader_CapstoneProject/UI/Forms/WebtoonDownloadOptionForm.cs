using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Resources;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebtoonDownloader_CapstoneProject.Core;

namespace WebtoonDownloader_CapstoneProject.UI.Forms
{
	public partial class WebtoonDownloadOptionForm : Form
	{
		private Pen lineDrawer = new Pen( GlobalVar.ThemeColor );
		private string url;
		public bool ForceClosed; // 닫기 버튼을 강제로 눌렀는지 확인
		private int randomImageCount;
		private string[ ] exampleImages;

		public WebtoonDownloadOptionForm( string url )
		{
			InitializeComponent( );

			this.SetStyle( ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw, true );
			this.UpdateStyles( );

			this.Opacity = 0;

			this.url = url;
		}

		private void WebtoonDownloadOptionForm_Load( object sender, EventArgs e )
		{
			Animation.UI.FadeIn( this );

			exampleImages = Directory.GetFiles( GlobalVar.APPLICATION_DIRECTORY + @"\resources\exampleImages", "QUALITY_SAMPLE*.jpg" );

			if ( exampleImages.Length > 0 )
			{
				this.QUALITY_EXAMPLE_NOT_AVAILABLE.Visible = false;
			}
			else
			{
				this.QUALITY_EXAMPLE_IMAGE.Visible = false;
				this.QUALITY_EXAMPLE_TITLE.Visible = false;
				this.QUALITY_EXAMPLE_NOT_AVAILABLE.Visible = true;
			}
		}

		private void WebtoonDownloadOptionForm_Paint( object sender, PaintEventArgs e )
		{
			int w = this.Width, h = this.Height;

			e.Graphics.DrawLine( lineDrawer, 0, 0, w, 0 ); // 위
			e.Graphics.DrawLine( lineDrawer, 0, 0, 0, h ); // 왼쪽
			e.Graphics.DrawLine( lineDrawer, w - lineDrawer.Width, 0, w - lineDrawer.Width, h ); // 오른쪽
			e.Graphics.DrawLine( lineDrawer, 0, h - lineDrawer.Width, w, h - lineDrawer.Width ); // 아래
		}

		private void WEBTOON_BEGIN_NUMBER_ValueChanged( object sender, EventArgs e )
		{
			this.WEBTOON_BEGIN_NUMBER.Maximum = Math.Max( WEBTOON_END_NUMBER.Value - 1, 1 );
		}

		private void WEBTOON_END_NUMBER_ValueChanged( object sender, EventArgs e )
		{
			this.WEBTOON_END_NUMBER.Minimum = Math.Max( WEBTOON_BEGIN_NUMBER.Value + 1, 1 );
		}

		private void WEBTOON_BEGIN_NUMBER_Enter( object sender, EventArgs e )
		{

		}

		private void WEBTOON_END_NUMBER_Enter( object sender, EventArgs e )
		{

		}

		private void CallGetSpecificWebtoonDetailPageInformations( int num, Action<NaverWebtoon.WebtoonDetailPageInformations> callback )
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

		private void WEBTOON_BEGIN_NUMBER_Leave( object sender, EventArgs e )
		{
			CallGetSpecificWebtoonDetailPageInformations( ( int ) this.WEBTOON_BEGIN_NUMBER.Value, ( NaverWebtoon.WebtoonDetailPageInformations info ) =>
			{
				this.BEGIN_THUMBNAIL_IMAGE.Load( info.thumbnail );
				this.BEGIN_TITLE_LABEL.Text = info.title;
			} );
		}

		private void WEBTOON_END_NUMBER_Leave( object sender, EventArgs e )
		{
			CallGetSpecificWebtoonDetailPageInformations( ( int ) this.WEBTOON_END_NUMBER.Value, ( NaverWebtoon.WebtoonDetailPageInformations info ) =>
			{
				this.END_THUMBNAIL_IMAGE.Load( info.thumbnail );
				this.END_TITLE_LABEL.Text = info.title;
			} );
		}

		private void WebtoonDownloadOptionForm_Shown( object sender, EventArgs e )
		{
			this.DotAnimationTimer.Start( );

			this.LOADING_LABEL.Visible = true;
			this.DOWNLOAD_OPTION_PANEL.Visible = false;

			this.BGM_DOWNLOAD_CHECKBOX.Visible = false;
			this.BGM_DOWNLOAD_LABEL.Visible = false;

			this.CREATE_VIEWER_CHECKBOX.Visible = false;
			this.CREATE_VIEWER_LABEL.Visible = false;

			this.DOWNLOAD_BUTTON.Visible = false;

			Task.Factory.StartNew( ( ) =>
			{
				int maxWebtoonList = NaverWebtoon.GetWebtoonListCount( this.url );

				if ( maxWebtoonList > 0 )
				{
					CallGetSpecificWebtoonDetailPageInformations( 1, ( NaverWebtoon.WebtoonDetailPageInformations info ) =>
					{
						this.BEGIN_THUMBNAIL_IMAGE.Load( info.thumbnail );
						this.BEGIN_TITLE_LABEL.Text = info.title;
					} );

					CallGetSpecificWebtoonDetailPageInformations( maxWebtoonList, ( NaverWebtoon.WebtoonDetailPageInformations info ) =>
					{
						this.END_THUMBNAIL_IMAGE.Load( info.thumbnail );
						this.END_TITLE_LABEL.Text = info.title;
					} );

					if ( this.InvokeRequired )
					{
						this.Invoke( new Action( ( ) =>
						{
							this.DotAnimationTimer.Stop( );

							this.LOADING_LABEL.Visible = false;
							this.DOWNLOAD_OPTION_PANEL.Visible = true;
							this.QUALITY_OPTION_PANEL.Visible = true;

							this.BGM_DOWNLOAD_CHECKBOX.Visible = true;
							this.BGM_DOWNLOAD_LABEL.Visible = true;

							this.CREATE_VIEWER_CHECKBOX.Visible = true;
							this.CREATE_VIEWER_LABEL.Visible = true;

							this.DOWNLOAD_BUTTON.Visible = true;

							this.WEBTOON_BEGIN_NUMBER.Minimum = 1;
							this.WEBTOON_BEGIN_NUMBER.Maximum = maxWebtoonList + 1;
							this.WEBTOON_BEGIN_NUMBER.Value = 1;

							this.WEBTOON_END_NUMBER.Maximum = maxWebtoonList;
							this.WEBTOON_END_NUMBER.Value = maxWebtoonList;
						} ) );
					}
					else
					{
						this.DotAnimationTimer.Stop( );

						this.LOADING_LABEL.Visible = false;
						this.DOWNLOAD_OPTION_PANEL.Visible = true;
						this.QUALITY_OPTION_PANEL.Visible = true;

						this.BGM_DOWNLOAD_CHECKBOX.Visible = true;
						this.BGM_DOWNLOAD_LABEL.Visible = true;

						this.CREATE_VIEWER_CHECKBOX.Visible = true;
						this.CREATE_VIEWER_LABEL.Visible = true;

						this.DOWNLOAD_BUTTON.Visible = true;

						this.WEBTOON_BEGIN_NUMBER.Minimum = 1;
						this.WEBTOON_BEGIN_NUMBER.Maximum = maxWebtoonList + 1;
						this.WEBTOON_BEGIN_NUMBER.Value = 1;

						this.WEBTOON_END_NUMBER.Maximum = maxWebtoonList;
						this.WEBTOON_END_NUMBER.Value = maxWebtoonList;
					}
				}
				else
				{
					NotifyBox.Show( this, "오류", "Error", "웹툰 정보를 가져올 수 없습니다.", NotifyBox.NotifyBoxType.OK, NotifyBox.NotifyBoxIcon.Error );
				}
			} );
		}

		private void DOWNLOAD_OPTION_PANEL_Paint( object sender, PaintEventArgs e )
		{
			int w = this.DOWNLOAD_OPTION_PANEL.Width, h = this.DOWNLOAD_OPTION_PANEL.Height;

			e.Graphics.DrawLine( lineDrawer, 0, h - lineDrawer.Width, w, h - lineDrawer.Width ); // 아래
		}

		private void DOWNLOAD_BUTTON_Click( object sender, EventArgs e )
		{
			// 다운로드 옵션 설정

			GlobalVar.BeginDownloadDetailNum = ( int ) this.WEBTOON_BEGIN_NUMBER.Value;
			GlobalVar.EndDownloadDetailNum = ( int ) this.WEBTOON_END_NUMBER.Value;
			GlobalVar.QualityOption = this.QUALITY_VALUE_BAR.Value;
			GlobalVar.BGMDownloadOption = this.BGM_DOWNLOAD_CHECKBOX.Status;
			GlobalVar.ViewerCreateOption = this.CREATE_VIEWER_CHECKBOX.Status;

			this.Close( );
		}

		private void BEGIN_THUMBNAIL_IMAGE_Paint( object sender, PaintEventArgs e )
		{
			int w = this.BEGIN_THUMBNAIL_IMAGE.Width, h = this.BEGIN_THUMBNAIL_IMAGE.Height;

			e.Graphics.DrawLine( lineDrawer, 0, h - lineDrawer.Width, w, h - lineDrawer.Width ); // 아래
		}

		private void END_THUMBNAIL_IMAGE_Paint( object sender, PaintEventArgs e )
		{
			int w = this.END_THUMBNAIL_IMAGE.Width, h = this.END_THUMBNAIL_IMAGE.Height;

			e.Graphics.DrawLine( lineDrawer, 0, h - lineDrawer.Width, w, h - lineDrawer.Width ); // 아래
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
			if ( NotifyBox.Show( this, "다운로드 취소", "Cancel", "정말로 다운로드를 취소하시겠습니까?", NotifyBox.NotifyBoxType.YesNo, NotifyBox.NotifyBoxIcon.Warning ) == NotifyBox.NotifyBoxResult.Yes )
			{
				this.ForceClosed = true;
				return true;
			}

			return false;
		}

		private void QUALITY_VALUE_BAR_ValueChanged( object sender, EventArgs e )
		{
			int value = this.QUALITY_VALUE_BAR.Value;

			if ( value >= 100 )
			{
				this.QUALITY_VALUE_HINT.Text = "최상";
			}
			else if ( value >= 80 )
			{
				this.QUALITY_VALUE_HINT.Text = "매우 좋음";
			}
			else if ( value >= 70 )
			{
				this.QUALITY_VALUE_HINT.Text = "좋음";
			}
			else if ( value >= 50 )
			{
				this.QUALITY_VALUE_HINT.Text = "보통";
			}
			else if ( value >= 20 )
			{
				this.QUALITY_VALUE_HINT.Text = "낮음";
			}
			else if ( value <= 0 )
			{
				this.QUALITY_VALUE_HINT.Text = "최하";
			}

			if ( File.Exists( exampleImages[ randomImageCount ] ) )
			{
				Image newImage = Image.FromFile( exampleImages[ randomImageCount ] );
				this.QUALITY_EXAMPLE_IMAGE.Image = ImageQualityChange( newImage, value );
			}

			if ( value <= 15 )
				this.WARN_TOOLOW_LABEL.Text = "해당 품질 설정으로는 원활한 보기가 어려울 수 있습니다.";
			else
				this.WARN_TOOLOW_LABEL.Text = "";
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

		//private int CalcSize( int quality )
		//{
		//	return ( 230 * 10 ) / ( 100 - quality );
		//	//SIZE_SIMULATE_LABEL
		//}

		private void QUALITY_OPTION_PANEL_Paint( object sender, PaintEventArgs e )
		{
			int w = this.QUALITY_OPTION_PANEL.Width, h = this.QUALITY_OPTION_PANEL.Height;

			e.Graphics.DrawLine( lineDrawer, 0, h - lineDrawer.Width, w, h - lineDrawer.Width ); // 아래
		}

		private void RANDOM_IMAGE_BUTTON_Click( object sender, EventArgs e )
		{
			//string[ ] files = Directory.GetFiles( GlobalVar.APPLICATION_DIRECTORY + @"\resources\exampleImages", "QUALITY_SAMPLE*.jpg" );
			if ( exampleImages.Length == 0 ) return;

			if ( randomImageCount >= exampleImages.Length - 1 )
			{
				randomImageCount = 0;
			}
			else
				randomImageCount++;

			if ( File.Exists( exampleImages[ randomImageCount ] ) )
			{
				this.QUALITY_EXAMPLE_IMAGE.Image = ImageQualityChange( Image.FromFile( exampleImages[ randomImageCount ] ), this.QUALITY_VALUE_BAR.Value );
			}
		}

		private void QUALITY_EXAMPLE_IMAGE_Paint( object sender, PaintEventArgs e )
		{
			int w = this.QUALITY_EXAMPLE_IMAGE.Width, h = this.QUALITY_EXAMPLE_IMAGE.Height;

			e.Graphics.DrawLine( lineDrawer, 0, 0, w, 0 ); // 위
			e.Graphics.DrawLine( lineDrawer, 0, 0, 0, h ); // 왼쪽
			e.Graphics.DrawLine( lineDrawer, w - lineDrawer.Width, 0, w - lineDrawer.Width, h ); // 오른쪽
			e.Graphics.DrawLine( lineDrawer, 0, h - lineDrawer.Width, w, h - lineDrawer.Width ); // 아래
		}
	}
}
