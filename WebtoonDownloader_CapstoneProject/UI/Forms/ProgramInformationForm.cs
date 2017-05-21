using System;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebtoonDownloader_CapstoneProject.Core;

namespace WebtoonDownloader_CapstoneProject.UI.Forms
{
	public partial class ProgramInformationForm : Form
	{
		private Pen lineDrawer = new Pen( GlobalVar.ThemeColor );
		
		public ProgramInformationForm( )
		{
			InitializeComponent( );

			this.SetStyle( ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw, true );
			this.UpdateStyles( );

			this.Opacity = 0;
		}

		private void ProgramInformationForm_Load( object sender, EventArgs e )
		{
			Animation.UI.FadeIn( this );

			this.VERSION_LABEL.Text = "버전 " + GlobalVar.APPLICATION_VER;
		}

		private void ProgramInformationForm_Paint( object sender, PaintEventArgs e )
		{
			int w = this.Width, h = this.Height;

			e.Graphics.DrawLine( lineDrawer, 0, 0, w, 0 ); // 위
			e.Graphics.DrawLine( lineDrawer, 0, 0, 0, h ); // 왼쪽
			e.Graphics.DrawLine( lineDrawer, w - lineDrawer.Width, 0, w - lineDrawer.Width, h ); // 오른쪽
			e.Graphics.DrawLine( lineDrawer, 0, h - lineDrawer.Width, w, h - lineDrawer.Width ); // 아래
		}

		private void GIT_OPEN_BUTTON_Click( object sender, EventArgs e )
		{
			Util.OpenWebPage( "https://github.com/L7D/Webtoon-Downloader-SchoolProject", this );
		}
	}
}
