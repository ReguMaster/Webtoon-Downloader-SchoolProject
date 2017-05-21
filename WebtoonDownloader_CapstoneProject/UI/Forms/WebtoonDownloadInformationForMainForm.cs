using System;
using System.Windows.Forms;
using static WebtoonDownloader_CapstoneProject.Core.NaverWebtoon;

namespace WebtoonDownloader_CapstoneProject.UI.Forms
{
	public partial class WebtoonDownloadInformationForMainForm : UserControl
	{
		//private Pen lineDrawer = new Pen( GlobalVar.ThemeColor )
		//{
		//	Width = 2
		//};

		public WebtoonDownloadInformationForMainForm( )
		{
			InitializeComponent( );

			this.SetStyle( ControlStyles.OptimizedDoubleBuffer | ControlStyles.SupportsTransparentBackColor | ControlStyles.ResizeRedraw, true );
			this.UpdateStyles( );
		}

		public void SetData( WebtoonListSpecificPageInformations info, bool useAnimation )
		{
			if ( string.IsNullOrEmpty( info.thumbnail ) )
				this.THUMBNAIL_IMAGE.Image = null;
			else
			{
				try
				{
					this.THUMBNAIL_IMAGE.Load( info.thumbnail );
				}
				catch ( Exception ex )
				{
					Core.Util.WriteErrorLog( ex );
				}
			}

			if ( string.IsNullOrEmpty( info.title ) )
				this.WEBTOON_DETAIL_TITLE_LABEL.Text = "0.00";
			else
				this.WEBTOON_DETAIL_TITLE_LABEL.Text = info.title;

			double? starRate = info.starRate;

			if ( starRate.HasValue )
				this.WEBTOON_DETAIL_STAR_RATE_LABEL.Text = starRate.Value.ToString( );
			else
				this.WEBTOON_DETAIL_STAR_RATE_LABEL.Text = "0.00";

			if ( string.IsNullOrEmpty( info.uploadDate ) )
				this.WEBTOON_DETAIL_UPLOAD_DATE_LABEL.Text = DateTime.Now.Year + ".01.01";
			else
				this.WEBTOON_DETAIL_UPLOAD_DATE_LABEL.Text = info.uploadDate;
		}

		//public void SetPercent( float per )
		//{
		//	//this.PROGRESS_BAR.Progress = ( int ) ( per * 100 );
		//	//this.DOWNLOAD_PERCENT_LABEL.Text =( ( int ) (per*100)).ToString() + " %";
		//}

		private void WebtoonDownloadInformationForMainForm_Paint( object sender, PaintEventArgs e )
		{
			//int w = this.Width, h = this.Height;

			//e.Graphics.DrawLine( lineDrawer, 0, h - lineDrawer.Width, w, h - lineDrawer.Width ); // 아래
		}
	}
}
