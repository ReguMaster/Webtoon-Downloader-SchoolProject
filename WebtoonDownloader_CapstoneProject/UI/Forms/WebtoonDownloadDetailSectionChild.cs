using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebtoonDownloader_CapstoneProject.Core;

namespace WebtoonDownloader_CapstoneProject.UI.Forms
{
	public partial class WebtoonDownloadDetailSectionChild : UserControl
	{
		public event Action<int, int> ChildMouseEnter;
		public event Action<WebtoonDownloadDetailSectionChild> ChildMouseLeave;
		public event Action<int, int> ChildMouseDown;
		private int num;

		public WebtoonDownloadDetailSectionChild( int num, NaverWebtoon.WebtoonDetailPageInformations info )
		{
			InitializeComponent( );

			this.num = num;

			this.THUMBNAIL_ICON.Load( info.thumbnail );
			this.NUM_LABEL.Text = num.ToString( );
		}

		private void WebtoonDownloadDetailSectionChild_Load( object sender, EventArgs e )
		{

		}

		private void WebtoonDownloadDetailSectionChild_MouseEnter( object sender, EventArgs e )
		{

			ChildMouseEnter.Invoke( num, this.Parent.Controls.GetChildIndex( this ) );
		}

		private void WebtoonDownloadDetailSectionChild_MouseDown( object sender, MouseEventArgs e )
		{
			ChildMouseDown.Invoke( num, this.Parent.Controls.GetChildIndex( this ) );
		}

		private void WebtoonDownloadDetailSectionChild_MouseLeave( object sender, EventArgs e )
		{
			ChildMouseLeave.Invoke( this );
		}
	}
}
