using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WebtoonDownloader_CapstoneProject.UI.Forms
{
	public partial class WebtoonDownloadDetailSectionPageIndexForm : UserControl
	{
		public int index;
		public event Action<int> PageIndexClicked;

		public WebtoonDownloadDetailSectionPageIndexForm( int index )
		{
			InitializeComponent( );

			this.index = index;
		}

		private void WebtoonDownloadDetailSectionPageIndexForm_Load( object sender, EventArgs e )
		{

		}

		private void WebtoonDownloadDetailSectionPageIndexForm_MouseDown( object sender, MouseEventArgs e )
		{
			PageIndexClicked.Invoke( this.index );
		}
	}
}
