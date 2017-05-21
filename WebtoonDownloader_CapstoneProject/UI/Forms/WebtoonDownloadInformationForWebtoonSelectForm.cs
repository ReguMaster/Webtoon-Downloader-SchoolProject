using System;
using System.Drawing;
using System.Windows.Forms;
using WebtoonDownloader_CapstoneProject.Core;

namespace WebtoonDownloader_CapstoneProject.UI.Forms
{
	public partial class WebtoonDownloadInformationForWebtoonSelectForm : UserControl
	{
		private NaverWebtoon.WebtoonListPageInformations informations;
		private Pen lineDrawer = new Pen( GlobalVar.ThemeColor )
		{
			Width = 1
		};

		public WebtoonDownloadInformationForWebtoonSelectForm( )
		{
			InitializeComponent( );

			this.SetStyle( ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw, true );
			this.UpdateStyles( );
		}

		private void WebtoonDownloadInformationForWebtoonSelectForm_Load( object sender, EventArgs e )
		{

		}

		public void SetData( NaverWebtoon.WebtoonListPageInformations data )
		{
			if ( this.InvokeRequired )
			{
				this.Invoke( new Action( ( ) =>
				{
					this.WEBTOON_LIST_TITLE_LABEL.Text = data.title;
					this.WEBTOON_LIST_AUTHOR_LABEL.Text = data.author;
					this.WEBTOON_LIST_DESC_LABEL.Text = data.description;

					try
					{
						this.THUMBNAIL_IMAGE.Load( data.thumbnail );
					}
					catch
					{
						NotifyBox.Show( null, "오류", "Error", "죄송합니다, 해당 웹툰의 썸네일 이미지를 불러올 수 없었습니다.", NotifyBox.NotifyBoxType.OK, NotifyBox.NotifyBoxIcon.Error );
					}

					this.informations = data;
				} ) );
			}
			else
			{
				this.WEBTOON_LIST_TITLE_LABEL.Text = data.title;
				this.WEBTOON_LIST_AUTHOR_LABEL.Text = data.author;
				this.WEBTOON_LIST_DESC_LABEL.Text = data.description;

				try
				{
					this.THUMBNAIL_IMAGE.Load( data.thumbnail );
				}
				catch
				{
					NotifyBox.Show( null, "오류", "Error", "죄송합니다, 해당 웹툰의 썸네일 이미지를 불러올 수 없었습니다.", NotifyBox.NotifyBoxType.OK, NotifyBox.NotifyBoxIcon.Error );
				}

				this.informations = data;
			}
		}

		public void SetData( bool falseVar )
		{
			if ( falseVar != false ) return;

			this.WEBTOON_LIST_TITLE_LABEL.Text = "웹툰 이름";
			this.WEBTOON_LIST_AUTHOR_LABEL.Text = "웹툰 작가";
			this.WEBTOON_LIST_DESC_LABEL.Text = "웹툰 설명";
			this.THUMBNAIL_IMAGE.Image = null;

			this.informations = default( NaverWebtoon.WebtoonListPageInformations );
		}

		private void WebtoonDownloadInformationForWebtoonSelectForm_Paint( object sender, PaintEventArgs e )
		{
			int w = this.Width, h = this.Height;

			e.Graphics.DrawLine( lineDrawer, 0, h - lineDrawer.Width, w, h - lineDrawer.Width ); // 아래
		}

		private void WEBTOON_LIST_SHOW_BUTTON_Click( object sender, EventArgs e )
		{
			Util.OpenWebPage( this.informations.url );
		}
	}
}
