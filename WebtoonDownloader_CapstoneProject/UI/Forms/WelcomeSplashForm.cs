using System;
using System.Windows.Forms;
using WebtoonDownloader_CapstoneProject.Core;

namespace WebtoonDownloader_CapstoneProject.UI.Forms
{
	public partial class WelcomeSplashForm : Form
	{
		public WelcomeSplashForm( )
		{
			InitializeComponent( );

			this.SetStyle( ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw, true );
			this.UpdateStyles( );
			this.Opacity = 0;
			this.Top = ( ( Screen.GetWorkingArea( this ).Height / 2 ) - ( this.Height / 2 ) ) + 20;
		}

		private void WelcomeSplashForm_Shown( object sender, EventArgs e )
		{
			Animation.UI.FadeIn( this );

			Animation.NumberSmoothEffect( 0, 20, ( float val ) =>
			{
				this.Top = ( ( Screen.GetWorkingArea( this ).Height / 2 ) - ( this.Height / 2 ) ) + ( int ) val;
			} );

			Util.AppliactionDelay( 2000 );

			Animation.UI.FadeOut( this, true );

			if ( !Program.CanRunProgram( ) )
			{
				Animation.UI.FadeOutShutdown( this );
			}
		}
	}
}
