using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static WebtoonDownloader_CapstoneProject.Core.NaverWebtoon;

namespace WebtoonDownloader_CapstoneProject.UI.Forms
{
	public partial class WebtoonDownloadInformationForMainForm : UserControl
	{
		public WebtoonDownloadInformationForMainForm( )
		{
			InitializeComponent( );

			this.SetStyle( ControlStyles.OptimizedDoubleBuffer, true );
			this.SetStyle( ControlStyles.ResizeRedraw, true );
		}

		public void SetData( WebtoonListSpecificPageInformations info )
		{
			this.THUMBNAIL_IMAGE.Load( info.thumbnail );

			this.WEBTOON_DETAIL_TITLE_LABEL.Text = info.title;
			this.WEBTOON_DETAIL_STAR_RATE_LABEL.Text = ( info.starRate ).ToString( );
			this.WEBTOON_DETAIL_UPLOAD_DATE_LABEL.Text = info.uploadDate;
		}

		//public void SetPercent( float per )
		//{
		//	//this.PROGRESS_BAR.Progress = ( int ) ( per * 100 );
		//	//this.DOWNLOAD_PERCENT_LABEL.Text =( ( int ) (per*100)).ToString() + " %";
		//}

		private void WebtoonDownloadInformationForMainForm_Load( object sender, EventArgs e )
		{

		}
	}
}
