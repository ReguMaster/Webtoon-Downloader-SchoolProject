using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebtoonDownloader_CapstoneProject.Core;
using WebtoonDownloader_CapstoneProject.UI;

namespace WebtoonDownloader_CapstoneProject
{
	public partial class MainForm : Form
	{
		private Pen lineDrawer = new Pen( GlobalVar.ThemeColor );

		public MainForm( )
		{
			InitializeComponent( );

			this.SetStyle( ControlStyles.OptimizedDoubleBuffer, true );
			this.SetStyle( ControlStyles.ResizeRedraw, true );
			this.Opacity = 0;
		}

		private void MainForm_Load( object sender, EventArgs e )
		{
			( new UI.Forms.WelcomeSplashForm( ) ).ShowDialog( );

			if ( this.Disposing || this.IsDisposed ) return;

			Animation.UI.FadeIn( this );

			this.VERSION_LABEL.Text = "버전 " + GlobalVar.APPLICATION_VER;

			this.BACKGROUND_SPLASH.Top = this.Height;
			Animation.NumberSmoothEffect( this.Height, 70, ( float val ) =>
			{
				this.BACKGROUND_SPLASH.Top = ( int ) val;
				this.BACKGROUND_SPLASH.Invalidate( );
			} );

			//NotifyBox.Show( this, "환영합니다", "WELCOME", "웹툰 다운로더에 처음으로 오신 것을 환영합니다!", NotifyBox.NotifyBoxType.OK, NotifyBox.NotifyBoxIcon.Information );
		}

		private void MainForm_Paint( object sender, PaintEventArgs e )
		{
			int w = this.Width, h = this.Height;

			e.Graphics.DrawLine( lineDrawer, 0, 0, w, 0 ); // 위
			e.Graphics.DrawLine( lineDrawer, 0, 0, 0, h ); // 왼쪽
			e.Graphics.DrawLine( lineDrawer, w - lineDrawer.Width, 0, w - lineDrawer.Width, h ); // 오른쪽
			e.Graphics.DrawLine( lineDrawer, 0, h - lineDrawer.Width, w, h - lineDrawer.Width ); // 아래
		}

		private void WEBTOON_SELECT_BUTTON_Click( object sender, EventArgs e )
		{

		}

		private void INFO_BUTTON_Click( object sender, EventArgs e )
		{

		}

		private bool APP_TITLE_BAR_BeginClose( )
		{
			return NotifyBox.Show( this, "종료 확인", "Are you SURE?", "정말로 웹툰 다운로더를 종료하시겠습니까?", NotifyBox.NotifyBoxType.YesNo, NotifyBox.NotifyBoxIcon.Error ) == NotifyBox.NotifyBoxResult.Yes;
		}
	}
}
