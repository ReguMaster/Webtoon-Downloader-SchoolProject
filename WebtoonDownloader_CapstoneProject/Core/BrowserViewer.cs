using System;
using System.IO;
using System.Text;

namespace WebtoonDownloader_CapstoneProject.Core
{
	static class BrowserViewer
	{
		private static readonly string HTML_LOCATION;

		static BrowserViewer( )
		{
			HTML_LOCATION = GlobalVar.APPLICATION_DIRECTORY + @"\viewerHtmlBase.html";
		}

		public static bool Create( string title, string baseDir, string url, int maxImageCount, bool bgmAvaliable, Action<string> ExceptionCallback = null )
		{
			try
			{
				if ( File.Exists( HTML_LOCATION ) )
				{
					StringBuilder sb = new StringBuilder( File.ReadAllText( HTML_LOCATION, Encoding.UTF8 ) );

					sb.Replace( "&title", title );
					sb.Replace( "&url", url );
					sb.Replace( "&thumbnail", "데이터/thumanail.jpg" );

					if ( bgmAvaliable )
					{
						sb.Replace( "&bgmPlayer", @"<audio id='audioControl'>
						<source src='데이터/bgm.mp3' type='audio/mpeg'>
						귀하의 웹 브라우저는 BGM 사운드를 지원하지 않습니다.
						</audio>"
						);
					}
					else
						sb.Replace( "&bgmPlayer", "" );

					StringBuilder contentSB = new StringBuilder( );

					for ( int i = 1; i <= maxImageCount; i++ )
					{
						contentSB.AppendLine( "<img src='데이터/" + i + "_image.jpg' alt='웹툰 이미지' />" );
					}

					sb.Replace( "&imageContent", contentSB.ToString( ) );

					File.WriteAllText( baseDir + "\\웹툰 뷰어.html", sb.ToString( ), Encoding.UTF8 );
					return true;
				}
				else
					return false;
			}
			catch ( IOException ex )
			{
				ExceptionCallback?.Invoke( "IOException:" + ex.Message + " - " + ex.StackTrace );

				return false;
			}
			catch ( UnauthorizedAccessException ex )
			{
				ExceptionCallback?.Invoke( "UnauthorizedAccessException:" + ex.Message + " - " + ex.StackTrace );

				return false;
			}
			catch ( Exception ex )
			{
				ExceptionCallback?.Invoke( ex.Message + " - " + ex.StackTrace );

				return false;
			}
		}
	}
}
