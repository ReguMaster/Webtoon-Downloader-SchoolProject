using System;
using System.Drawing;
using System.Media;
using System.Threading;
using System.Windows.Forms;
using WebtoonDownloader_CapstoneProject.Core;

namespace WebtoonDownloader_CapstoneProject.UI.Forms
{
	public partial class NotifyBoxForm : Form
	{
		private Pen lineDrawer = new Pen( GlobalVar.ThemeColor );
		public NotifyBox.NotifyBoxResult Result
		{
			get; set;
		}

		public NotifyBoxForm( string title, string titleEng, string message, NotifyBox.NotifyBoxType type, NotifyBox.NotifyBoxIcon icon, int time )
		{
			InitializeComponent( );

			this.SetStyle( ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw, true );
			this.UpdateStyles( );
			this.Opacity = 0;

			switch ( icon )
			{
				case NotifyBox.NotifyBoxIcon.Information:
					SystemSounds.Asterisk.Play( );
					this.APP_TITLE_BAR.TextColor = Color.White;
					this.APP_TITLE_BAR.BackColor = Color.Gray;
					break;
				case NotifyBox.NotifyBoxIcon.Question:
					SystemSounds.Asterisk.Play( );
					this.APP_TITLE_BAR.TextColor = Color.White;
					this.APP_TITLE_BAR.BackColor = Color.DodgerBlue;
					break;
				case NotifyBox.NotifyBoxIcon.Error:
					SystemSounds.Hand.Play( );
					this.APP_TITLE_BAR.TextColor = Color.White;
					this.APP_TITLE_BAR.BackColor = Color.FromArgb( 255, 255, 100, 100 );
					break;
				case NotifyBox.NotifyBoxIcon.Danger:
					SystemSounds.Hand.Play( );
					this.APP_TITLE_BAR.TextColor = Color.White;
					this.APP_TITLE_BAR.BackColor = Color.Crimson;
					break;
				case NotifyBox.NotifyBoxIcon.Warning:
					break;
			}

			this.APP_TITLE_BAR.KoreanText = title;
			this.APP_TITLE_BAR.EnglishText = titleEng;
			this.MESSAGE_LABEL.Text = message;

			switch ( type )
			{
				case NotifyBox.NotifyBoxType.OK:
					this.OK_BUTTON.Visible = true;
					this.YES_BUTTON.Visible = false;
					this.NO_BUTTON.Visible = false;

					this.FormClosing += delegate ( object sender, FormClosingEventArgs e )
					{
						if ( Result != NotifyBox.NotifyBoxResult.OK )
						{
							Result = NotifyBox.NotifyBoxResult.OK;
						}
					};
					break;
				case NotifyBox.NotifyBoxType.YesNo:
					this.OK_BUTTON.Visible = false;
					this.YES_BUTTON.Visible = true;
					this.NO_BUTTON.Visible = true;

					this.FormClosing += delegate ( object sender, FormClosingEventArgs e )
					{
						if ( Result != NotifyBox.NotifyBoxResult.Yes && Result != NotifyBox.NotifyBoxResult.No )
						{
							Result = NotifyBox.NotifyBoxResult.No;
						}
					};
					break;
				case NotifyBox.NotifyBoxType.TimeNotify:
					this.OK_BUTTON.Visible = true;
					this.OK_BUTTON.Enabled = false;
					this.OK_BUTTON.Text = time + "초 후 닫힘";
					this.YES_BUTTON.Visible = false;
					this.NO_BUTTON.Visible = false;

					System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer( )
					{
						Interval = 1000
					};
					timer.Tick += ( object sender, EventArgs e ) =>
					{
						this.OK_BUTTON.Text = ( --time > 0 ? time : 0 ) + "초 후 닫힘";

						if ( time <= 0 )
						{
							Animation.UI.FadeOut( this, true );
						}
					};
					timer.Start( );

					this.FormClosing += delegate ( object sender, FormClosingEventArgs e )
					{
						Result = NotifyBox.NotifyBoxResult.Null;
					};
					break;
			}
		}

		private void ErrorHighlight( )
		{
			Thread highlightThread = new Thread( ( ) =>
			{
				this.Invoke( new Action( ( ) =>
				{
					for ( int i = 0; i < 5; i++ )
					{
						this.lineDrawer = new Pen( this.lineDrawer.Color == Color.Silver ? Color.DarkRed : Color.Silver );


						Util.AppliactionDelay( 100 );
					}

					this.lineDrawer = new Pen( Color.DarkRed );
					this.Invalidate( );
				} ) );

			} )
			{
				IsBackground = true
			};
			highlightThread.Start( );
		}

		private void NotifyBoxForm_Load( object sender, EventArgs e )
		{
			Animation.UI.FadeIn( this );
		}

		private void YES_BUTTON_Click( object sender, EventArgs e )
		{
			this.Result = NotifyBox.NotifyBoxResult.Yes;
			Animation.UI.FadeOut( this, true );
		}

		private void NO_BUTTON_Click( object sender, EventArgs e )
		{
			this.Result = NotifyBox.NotifyBoxResult.No;
			Animation.UI.FadeOut( this, true );
		}

		private void OK_BUTTON_Click( object sender, EventArgs e )
		{
			this.Result = NotifyBox.NotifyBoxResult.OK;
			Animation.UI.FadeOut( this, true );
		}

		private void NotifyBoxForm_Paint( object sender, PaintEventArgs e )
		{
			int w = this.Width, h = this.Height;

			e.Graphics.DrawLine( lineDrawer, 0, 0, w, 0 ); // 위
			e.Graphics.DrawLine( lineDrawer, 0, 0, 0, h ); // 왼쪽
			e.Graphics.DrawLine( lineDrawer, w - lineDrawer.Width, 0, w - lineDrawer.Width, h ); // 오른쪽
			e.Graphics.DrawLine( lineDrawer, 0, h - lineDrawer.Width, w, h - lineDrawer.Width ); // 아래
		}

		private void COPY_BUTTON_Click( object sender, EventArgs e )
		{
			Clipboard.SetText( this.MESSAGE_LABEL.Text, TextDataFormat.Text );
			this.TOOL_TIP.SetToolTip( this.COPY_BUTTON, "텍스트가 클립보드에 복사되었습니다!" );
		}
	}
}
