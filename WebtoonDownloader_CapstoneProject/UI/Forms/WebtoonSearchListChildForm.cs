using System;
using System.Drawing;
using System.Windows.Forms;
using WebtoonDownloader_CapstoneProject.Core;
using static WebtoonDownloader_CapstoneProject.Core.NaverWebtoon;

namespace WebtoonDownloader_CapstoneProject.UI.Forms
{
	public partial class WebtoonSearchListChildForm : UserControl
	{
		private Pen lineDrawer = new Pen( GlobalVar.ThemeColor );
		public event Action<string, bool[ ]> SelectWebtoon;
		private WebtoonSearchResultList tempData;

		public WebtoonSearchListChildForm( )
		{
			InitializeComponent( );

			this.SetStyle( ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw, true );
			this.UpdateStyles( );
		}

		public void Initialize( WebtoonSearchResultList data )
		{
			this.TITLE_LABEL.Text = data.title;
			this.DESC_LABEL.Text = data.description;
			this.TOTAL_NUM_LABEL.Text = "총 " + data.totalNum + "화";

			if ( !string.IsNullOrEmpty( data.thumbnail ) )
			{
				try
				{
					this.THUMBNAIL_IMAGE.Load( data.thumbnail );
				}
				catch ( Exception ex )
				{
					Util.WriteErrorLog( ex );
				}
			}
			else
				this.THUMBNAIL_IMAGE.Image = null;

			this.STORE_ICON.Visible = data.metaData[ 0 ];
			this.ADULT_ICON.Visible = data.metaData[ 1 ];

			this.tempData = data;
		}

		private void WebtoonSearchListChildForm_Load( object sender, EventArgs e )
		{

		}

		private void WebtoonSearchListChildForm_Paint( object sender, PaintEventArgs e )
		{
			int w = this.Width, h = this.Height;

			e.Graphics.DrawLine( lineDrawer, 0, h - lineDrawer.Width, w, h - lineDrawer.Width ); // 아래
		}

		private void TITLE_LABEL_Click( object sender, EventArgs e )
		{

		}

		private void SELECT_BUTTON_Click( object sender, EventArgs e )
		{
			SelectWebtoon.Invoke( this.tempData.url, this.tempData.metaData );
		}
	}
}
