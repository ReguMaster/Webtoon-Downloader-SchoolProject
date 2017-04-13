using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebtoonDownloader_CapstoneProject.Core;

namespace WebtoonDownloader_CapstoneProject.UI.Forms
{
	public partial class WelcomeSplashForm : Form
	{
		public WelcomeSplashForm( )
		{
			InitializeComponent( );

			this.SetStyle( ControlStyles.OptimizedDoubleBuffer, true );
			this.SetStyle( ControlStyles.ResizeRedraw, true );
			this.Opacity = 0;
			this.Top = ( ( Screen.GetWorkingArea( this ).Height / 2 ) - ( this.Height / 2 ) ) + 20;
		}

		private void WelcomeSplashForm_Load( object sender, EventArgs e )
		{
			Animation.UI.FadeIn( this );

			Animation.NumberSmoothEffect( 0, 20, ( float val ) =>
			{
				this.Top = ( ( Screen.GetWorkingArea( this ).Height / 2 ) - ( this.Height / 2 ) ) + ( int ) val;
			} );

			Animation.NumberSmoothEffect( 0, 200, ( float val ) =>
			{
				this.SPLASH_BOTTOM_IMAGE.Top = this.Height - ( ( int ) val );
				this.SPLASH_BOTTOM_IMAGE.Invalidate( );
			}, ( float val ) =>
			{
				Util.Delay( 2000 );

				Animation.UI.FadeOut( this, true );

				if ( !Program.CheckProgram( ) )
				{
					Animation.UI.FadeOutShutdown( this );
				}
			} );
		}
	}
}
