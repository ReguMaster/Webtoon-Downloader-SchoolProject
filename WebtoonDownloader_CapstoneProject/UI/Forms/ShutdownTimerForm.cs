using System;
using System.Drawing;
using System.Windows.Forms;
using WebtoonDownloader_CapstoneProject.Core;

namespace WebtoonDownloader_CapstoneProject.UI.Forms
{
	public partial class ShutdownTimerForm : Form
	{
		int countDown = GlobalVar.DefaultCountDown;

		public ShutdownTimerForm( )
		{
			InitializeComponent( );

			this.SetStyle( ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw, true );
			this.UpdateStyles( );
			this.Opacity = 0;
		}

		private void ShutdownTimerForm_Shown( object sender, EventArgs e )
		{
			Animation.UI.FadeIn( this );
			this.CountDownTimer.Start( );
		}

		private void CANCEL_SYSTEM_SHUTDOWN_BUTTON_Click( object sender, EventArgs e )
		{
			this.CountDownTimer.Stop( );
			this.Close( );
		}

		private void CountDownTimer_Tick( object sender, EventArgs e )
		{
			//System.Media.SystemSounds.Beep.Play( );

			if ( countDown > 0 )
			{
				this.COUNTDOWN_LABEL.Text = "웹툰을 모두 다운로드 했습니다, " + --countDown + "초 후 시스템이 종료됩니다.";

				if ( countDown <= 10 )
					this.COUNTDOWN_LABEL.ForeColor = Color.Red;
			}
			else
			{
				Util.Win32.InitiateSystemShutdown( "\\\\127.0.0.1",  // 컴퓨터 이름
					null,           // 종료 전 사용자에게 알릴 메시지
					0,             // 종료까지 대기 시간
					false,          // 프로그램 강제 종료 여부(false > 강제 종료)
					false           // 시스템 종료 후 다시 시작 여부(true > 다시 시작)
				);

				this.CountDownTimer.Stop( );
			}
		}
	}
}
