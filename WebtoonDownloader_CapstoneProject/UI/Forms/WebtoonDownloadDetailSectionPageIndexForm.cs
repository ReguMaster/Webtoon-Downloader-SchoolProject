using System;
using System.Windows.Forms;

namespace WebtoonDownloader_CapstoneProject.UI.Forms
{
	public partial class WebtoonDownloadDetailSectionPageIndexForm : UserControl
	{
		public int index;
		public event Action<int> PageIndexClicked; // 페이지 클릭 했을 때 호출되는 이벤트

		public WebtoonDownloadDetailSectionPageIndexForm( int index )
		{
			InitializeComponent( );

			this.index = index;
		}

		private void WebtoonDownloadDetailSectionPageIndexForm_MouseDown( object sender, MouseEventArgs e )
		{
			PageIndexClicked.Invoke( this.index );
		}
	}
}
