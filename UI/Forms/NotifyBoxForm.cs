using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebtoonDownloader_CapstoneProject.Core;
using static WebtoonDownloader_CapstoneProject.Core.NotifyBox;

namespace WebtoonDownloader_CapstoneProject.UI.Forms
{
	public partial class NotifyBoxForm : Form
	{
		private Pen lineDrawer = new Pen( GlobalVar.ThemeColor );
		public NotifyBoxResult Result
		{
			get; set;
		}

		public NotifyBoxForm( string title, string titleEng, string message, NotifyBoxType type, NotifyBoxIcon icon, int timeout )
		{
			InitializeComponent( );

			this.SetStyle( ControlStyles.OptimizedDoubleBuffer, true );
			this.SetStyle( ControlStyles.ResizeRedraw, true );
			this.Opacity = 0;

		

			switch ( icon )
			{
				case NotifyBoxIcon.Information:
					SystemSounds.Asterisk.Play( );
					break;
				case NotifyBoxIcon.Question:
					SystemSounds.Asterisk.Play( );
					break;
				case NotifyBoxIcon.Error:
					SystemSounds.Hand.Play( );
					this.APP_TITLE_BAR.TextColor = Color.White;
					this.APP_TITLE_BAR.BackColor = Color.FromArgb( 255, 255, 100, 100 );
					break;
			}

			this.APP_TITLE_BAR.KoreanText = title;
			this.APP_TITLE_BAR.EnglishText = titleEng;
			this.MESSAGE_LABEL.Text = message;

			if ( type == NotifyBoxType.OK )
			{
				this.OK_BUTTON.Visible = true;
				this.YES_BUTTON.Visible = false;
				this.NO_BUTTON.Visible = false;
			}
			else if ( type == NotifyBoxType.YesNo )
			{
				this.OK_BUTTON.Visible = false;
				this.YES_BUTTON.Visible = true;
				this.NO_BUTTON.Visible = true;
			}

			if ( timeout > 0 )
			{
				this.OK_BUTTON.Visible = true;
				this.OK_BUTTON.Enabled = false;
				this.YES_BUTTON.Visible = false;
				this.NO_BUTTON.Visible = false;
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


						Util.Delay( 100 );
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
			this.Result = NotifyBoxResult.Yes;
			Animation.UI.FadeOut( this, true );
		}

		private void NO_BUTTON_Click( object sender, EventArgs e )
		{
			this.Result = NotifyBoxResult.No;
			Animation.UI.FadeOut( this, true );
		}

		private void OK_BUTTON_Click( object sender, EventArgs e )
		{
			this.Result = NotifyBoxResult.OK;
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
	}
}
