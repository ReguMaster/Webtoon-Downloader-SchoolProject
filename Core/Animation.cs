using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WebtoonDownloader_CapstoneProject.Core
{
	static class Animation
	{
		public static class UI
		{
			public static void FadeIn( Form form )
			{
				Animation.NumberSmoothEffect( 0, 100, ( float alpha ) =>
				{
					if ( form == null || form.IsDisposed || form.Disposing ) return;

					form.Opacity = alpha / 100;
					form.Invalidate( );
				} );
			}

			public static void FadeOut( Form form, bool closeAfterFadeOut )
			{
				Animation.NumberSmoothEffect( 100, 0, ( float alpha ) =>
				{
					if ( form == null || form.IsDisposed || form.Disposing ) return;

					form.Opacity = alpha / 100;
					form.Invalidate( );

					if ( closeAfterFadeOut && ( int ) alpha == 0 )
					{
						form.Close( );
					}
				} );
			}

			public static void FadeOutShutdown( Form form )
			{
				Animation.NumberSmoothEffect( 100, 0, ( float alpha ) =>
				{
					if ( form == null || form.IsDisposed || form.Disposing ) return;

					form.Opacity = alpha / 100;
					form.Invalidate( );

					if ( ( int ) alpha == 0 )
					{
						Application.Exit( );
					}
				} );
			}
		}


		public static void NumberSmoothEffect( int start, int end, Action<float> Callback )
		{
			float val = start;

			Timer animationTimer = new Timer( )
			{
				Interval = 10
			};
			animationTimer.Tick += ( object sender, EventArgs e ) =>
			{
				if ( Math.Round( val ) == end )
				{
					animationTimer.Stop( );
					return;
				}

				val = Util.Lerp( val, end, 0.8F );
				Callback.Invoke( val );
			};

			animationTimer.Start( );
		}
	}
}
