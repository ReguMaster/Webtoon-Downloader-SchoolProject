using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace WebtoonDownloader_CapstoneProject.Core
{
	struct CookieTable
	{
		public string id;
		public string value;

		public CookieTable( string id, string value )
		{
			this.id = id;
			this.value = value;
		}
	}

	static class Util
	{
		public static class Win32
		{
			// http://blog.bloodcat.com/153
			[DllImport( "advapi32.dll" )]
			public static extern void InitiateSystemShutdown( string lpMachineName, string lpMessage, int dwTimeout, bool bForceAppsClosed, bool bRebootAfterShutdown );
		}

		#region FlashWindow Library
		public static class FlashWindow
		{
			[DllImport( "user32.dll" )]
			[return: MarshalAs( UnmanagedType.Bool )]
			private static extern bool FlashWindowEx( ref FLASHWINFO pwfi );

			[StructLayout( LayoutKind.Sequential )]
			private struct FLASHWINFO
			{
				/// <summary>
				/// The size of the structure in bytes.
				/// </summary>
				public uint cbSize;
				/// <summary>
				/// A Handle to the Window to be Flashed. The window can be either opened or minimized.
				/// </summary>
				public IntPtr hwnd;
				/// <summary>
				/// The Flash Status.
				/// </summary>
				public uint dwFlags;
				/// <summary>
				/// The number of times to Flash the window.
				/// </summary>
				public uint uCount;
				/// <summary>
				/// The rate at which the Window is to be flashed, in milliseconds. If Zero, the function uses the default cursor blink rate.
				/// </summary>
				public uint dwTimeout;
			}

			/// <summary>
			/// Stop flashing. The system restores the window to its original stae.
			/// </summary>
			public const uint FLASHW_STOP = 0;

			/// <summary>
			/// Flash the window caption.
			/// </summary>
			public const uint FLASHW_CAPTION = 1;

			/// <summary>
			/// Flash the taskbar button.
			/// </summary>
			public const uint FLASHW_TRAY = 2;

			/// <summary>
			/// Flash both the window caption and taskbar button.
			/// This is equivalent to setting the FLASHW_CAPTION | FLASHW_TRAY flags.
			/// </summary>
			public const uint FLASHW_ALL = 3;

			/// <summary>
			/// Flash continuously, until the FLASHW_STOP flag is set.
			/// </summary>
			public const uint FLASHW_TIMER = 4;

			/// <summary>
			/// Flash continuously until the window comes to the foreground.
			/// </summary>
			public const uint FLASHW_TIMERNOFG = 12;


			/// <summary>
			/// Flash the spacified Window (Form) until it recieves focus.
			/// </summary>
			/// <param name="form">The Form (Window) to Flash.</param>
			/// <returns></returns>
			public static bool Flash( Form form )
			{
				if ( form == null ) return false;

				// Make sure we're running under Windows 2000 or later
				if ( Win2000OrLater )
				{
					FLASHWINFO fi = Create_FLASHWINFO( form.Handle, FLASHW_ALL | FLASHW_TIMERNOFG, uint.MaxValue, 0 );
					return FlashWindowEx( ref fi );
				}
				return false;
			}

			public static bool Flash( )
			{
				MainForm form = GetMainForm( ); // Utility.GetMainForm( );

				if ( form == null ) return false;

				// Make sure we're running under Windows 2000 or later
				if ( Win2000OrLater )
				{
					FLASHWINFO fi = Create_FLASHWINFO( form.Handle, FLASHW_ALL | FLASHW_TIMERNOFG, uint.MaxValue, 0 );
					return FlashWindowEx( ref fi );
				}
				return false;
			}

			private static FLASHWINFO Create_FLASHWINFO( IntPtr handle, uint flags, uint count, uint timeout )
			{
				FLASHWINFO fi = new FLASHWINFO( );
				fi.cbSize = Convert.ToUInt32( Marshal.SizeOf( fi ) );
				fi.hwnd = handle;
				fi.dwFlags = flags;
				fi.uCount = count;
				fi.dwTimeout = timeout;
				return fi;
			}

			/// <summary>
			/// Flash the specified Window (form) for the specified number of times
			/// </summary>
			/// <param name="form">The Form (Window) to Flash.</param>
			/// <param name="count">The number of times to Flash.</param>
			/// <returns></returns>
			public static bool Flash( Form form, uint count )
			{
				if ( Win2000OrLater )
				{
					FLASHWINFO fi = Create_FLASHWINFO( form.Handle, FLASHW_ALL, count, 0 );
					return FlashWindowEx( ref fi );
				}
				return false;
			}

			/// <summary>
			/// Start Flashing the specified Window (form)
			/// </summary>
			/// <param name="form">The Form (Window) to Flash.</param>
			/// <returns></returns>
			public static bool Start( Form form )
			{
				if ( Win2000OrLater )
				{
					FLASHWINFO fi = Create_FLASHWINFO( form.Handle, FLASHW_ALL, uint.MaxValue, 0 );
					return FlashWindowEx( ref fi );
				}
				return false;
			}

			/// <summary>
			/// Stop Flashing the specified Window (form)
			/// </summary>
			/// <param name="form"></param>
			/// <returns></returns>
			public static bool Stop( Form form )
			{
				if ( Win2000OrLater )
				{
					FLASHWINFO fi = Create_FLASHWINFO( form.Handle, FLASHW_STOP, uint.MaxValue, 0 );
					return FlashWindowEx( ref fi );
				}
				return false;
			}

			/// <summary>
			/// A boolean value indicating whether the application is running on Windows 2000 or later.
			/// </summary>
			private static bool Win2000OrLater
			{
				get { return Environment.OSVersion.Version.Major >= 5; }
			}
		}
		#endregion

		#region String Extend
		public static string Repeat( this char target, int count )
		{
			return new string( target, count );
		}

		// http://stackoverflow.com/questions/3519539/how-to-check-if-a-string-contains-any-of-some-strings
		public static bool ContainsMultiple( this string target, params string[ ] args )
		{
			for ( int i = 0; i < args.Length; i++ )
				if ( target.Contains( args[ i ] ) ) return true;

			return false;
		}
		#endregion

		#region Math Method
		// Lerp (Linear interpolation, 선형보간법) 
		// p 의 값이 0에 가까워질수록 ( a - b ) 에 비례하여 중간 값이 커진다 (애니메이션이 빨라진다)
		// p 의 값이 1에 가까워질수록 ( a - b ) 에 비례하여 중간 값이 작아진다 (애니메이션이 느려진다)
		// ( p 의 값이 0 ~ 1F )
		// http://stackoverflow.com/questions/33044848/c-sharp-lerping-from-position-to-position
		// http://dodnet.tistory.com/993
		public static float Lerp( float a, float b, float p )
		{
			return a * p + b * ( 1 - p );
		}

		public static int Clamp( int original, int max, int min )
		{
			if ( original > max )
				return max;

			if ( original < min )
				return min;

			return original;
		}

		public static Color LerpColor( Color a, Color b, float p )
		{
			float newR = 0, newG = 0, newB = 0, newA = 0;

			newR = a.R * p + b.R * ( 1 - p );
			newG = a.G * p + b.G * ( 1 - p );
			newB = a.B * p + b.B * ( 1 - p );
			newA = a.A * p + b.A * ( 1 - p );

			return Color.FromArgb(
				( int ) Math.Round( newA ),
				( int ) Math.Round( newR ),
				( int ) Math.Round( newG ),
				( int ) Math.Round( newB )
			);
		}
		#endregion

		#region Error Handling Method
		public enum LogSeverity
		{
			NORMAL,
			EXCEPTION,
			ERROR
		}

		// https://msdn.microsoft.com/ko-kr/library/8kb3ddd4(v=vs.110).aspx
		// http://www.codeproject.com/Tips/606379/Caller-Info-Attributes-in-Csharp
		public static void WriteErrorLog( string errorString, LogSeverity severity = LogSeverity.NORMAL,
		[CallerMemberName] string debugTraceCallerName = "Unknown",
		[CallerFilePath] string debugTraceCallerFilePath = "Unknown Location",
		[CallerLineNumber] int debugTraceCallerLine = -1 )
		{
			try
			{
				string path = GlobalVar.APPLICATION_DIRECTORY + @"\log\" + DateTime.Now.ToString( "yyyy-MM-dd" );

				if ( !Directory.Exists( path ) )
					Directory.CreateDirectory( path );

				File.AppendAllText( path + @"\error.log",
					string.Format( "WebtoonDownloader_ErrorLOG{0} @{1} :	{2} -> #{3}		{4}:{5}" + Environment.NewLine,
						DateTime.Now.ToString( "HH:mm:ss" ), // 0
						severity.ToString( ), // 1
						debugTraceCallerName, // 2
						errorString, // 3
						Path.GetFileName( debugTraceCallerFilePath ), // 4
						debugTraceCallerLine // 5
					), Encoding.UTF8
				);
			}
			catch { }
		}

		public static void WriteErrorLog( Exception exception, LogSeverity severity = LogSeverity.EXCEPTION,
		[CallerMemberName] string debugTraceCallerName = "Unknown",
		[CallerFilePath] string debugTraceCallerFilePath = "Unknown Location",
		[CallerLineNumber] int debugTraceCallerLine = -1 )
		{
			try
			{
				string path = GlobalVar.APPLICATION_DIRECTORY + @"\log\" + DateTime.Now.ToString( "yyyy-MM-dd" );

				if ( !Directory.Exists( path ) )
					Directory.CreateDirectory( path );

				File.AppendAllText( path + @"\error.log",
					string.Format( "WebtoonDownloader_ErrorLOG{0} @{1} :	{2} -> #{3}		{4}:{5}" + Environment.NewLine,
						DateTime.Now.ToString( "HH:mm:ss" ), // 0
						severity.ToString( ), // 1
						debugTraceCallerName, // 2
						exception.GetType( ).Name + " : " + exception.Message + " : 0x" + exception.HResult, // 3
						Path.GetFileName( debugTraceCallerFilePath ), // 4
						debugTraceCallerLine // 5
					), Encoding.UTF8
				);
			}
			catch { }
		}
		#endregion

		#region UI Method
		// http://bananamandoo.tistory.com/27
		public static void AppliactionDelay( int ms )
		{
			DateTime thisMoment = DateTime.Now;
			DateTime afterWards = thisMoment.Add( new TimeSpan( 0, 0, 0, 0, ms ) );

			while ( afterWards >= thisMoment )
			{
				Application.DoEvents( );
				thisMoment = DateTime.Now;
			}
		}


		public static Form GetFormByName( string name )
		{
			foreach ( Form i in Application.OpenForms )
			{
				if ( i.Name == name ) return i;
			}

			return null;
		}

		public static MainForm GetMainForm( )
		{
			foreach ( Form i in Application.OpenForms )
			{
				if ( i.Name == "MainForm" ) return i as MainForm;
			}

			return null;
		}
		#endregion

		#region MD5 Hash Method
		// http://stackoverflow.com/questions/10520048/calculate-md5-checksum-for-a-file
		public static string GetMD5Hash( string fileName )
		{
			try
			{
				using ( FileStream stream = File.OpenRead( fileName ) )
				{
					StringBuilder sb = new StringBuilder( );

					foreach ( byte i in ( new MD5CryptoServiceProvider( ) ).ComputeHash( stream ) )
					{
						sb.Append( i.ToString( "X2" ) );
					}

					return sb.ToString( );
				}
			}
			catch { return ""; }
		}

		public static string GetMD5Hash( byte[ ] fileByte )
		{
			try
			{
				StringBuilder sb = new StringBuilder( );

				foreach ( byte i in ( new MD5CryptoServiceProvider( ) ).ComputeHash( fileByte ) )
				{
					sb.Append( i.ToString( "X2" ) );
				}

				return sb.ToString( );
			}
			catch { return ""; }
		}

		public static string GetMD5HashText( string text )
		{
			try
			{
				StringBuilder sb = new StringBuilder( );

				foreach ( byte i in ( new MD5CryptoServiceProvider( ) ).ComputeHash( Encoding.UTF8.GetBytes( text ) ) )
				{
					sb.Append( i.ToString( "X2" ) );
				}

				return sb.ToString( );
			}
			catch { return ""; }
		}
		#endregion

		#region SHA1 Hash Method
		public static string GetSHA1Hash( string fileName )
		{
			try
			{
				using ( FileStream stream = File.OpenRead( fileName ) )
				{
					StringBuilder sb = new StringBuilder( );

					foreach ( byte i in ( new SHA1Managed( ) ).ComputeHash( stream ) )
					{
						sb.AppendFormat( "{0:X2}", i );
					}

					return sb.ToString( );
				}
			}
			catch
			{
				return "";
			}
		}

		public static string GetSHA1Hash( byte[ ] byteArray )
		{
			try
			{
				StringBuilder sb = new StringBuilder( );

				foreach ( byte i in ( new SHA1Managed( ) ).ComputeHash( byteArray ) )
				{
					sb.AppendFormat( "{0:X2}", i );
				}

				return sb.ToString( );
			}
			catch
			{
				return "";
			}
		}

		public static string GetSHA1HashText( string text )
		{
			try
			{
				StringBuilder sb = new StringBuilder( );

				foreach ( byte i in ( new SHA1Managed( ) ).ComputeHash( Encoding.UTF8.GetBytes( text ) ) )
				{
					sb.AppendFormat( "{0:X2}", i );
				}

				return sb.ToString( );
			}
			catch
			{
				return "";
			}
		}
		#endregion

		#region SHA256 Hash Method
		public static string GetSHA256Hash( string fileName )
		{
			try
			{
				using ( FileStream stream = File.OpenRead( fileName ) )
				{
					StringBuilder sb = new StringBuilder( );

					foreach ( byte i in ( new SHA256Managed( ) ).ComputeHash( stream ) )
					{
						sb.AppendFormat( "{0:X2}", i );
					}

					return sb.ToString( );
				}
			}
			catch
			{
				return "";
			}
		}

		public static string GetSHA256Hash( byte[ ] byteArray )
		{
			try
			{
				StringBuilder sb = new StringBuilder( );

				foreach ( byte i in ( new SHA256Managed( ) ).ComputeHash( byteArray ) )
				{
					sb.AppendFormat( "{0:X2}", i );
				}

				return sb.ToString( );
			}
			catch
			{
				return "";
			}
		}

		public static string GetSHA256HashText( string text )
		{
			try
			{
				StringBuilder sb = new StringBuilder( );

				foreach ( byte i in ( new SHA256Managed( ) ).ComputeHash( Encoding.UTF8.GetBytes( text ) ) )
				{
					sb.AppendFormat( "{0:X2}", i );
				}

				return sb.ToString( );
			}
			catch
			{
				return "";
			}
		}
		#endregion

		#region Network and Cookie Method
		public static List<CookieTable> CookieParse( string cookieString )
		{
			List<CookieTable> cookieTable = new List<CookieTable>( );

			foreach ( string i in cookieString.Split( ';' ) )
			{
				string[ ] structure = i.Split( '=' );

				if ( structure.Length < 2 ) continue;

				cookieTable.Add( new CookieTable(
					structure[ 0 ].Trim( ),
					structure[ 1 ].Trim( )
				) );
			}

			return cookieTable;
		}

		// http://www.csharpstudy.com/Tip/Tip-network-connectivity.aspx
		public static bool IsInternetConnected( )
		{
			try
			{
				if ( ( new WebClient( ) ).DownloadString( "http://www.msftncsi.com/ncsi.txt" ) != "Microsoft NCSI" ) return false;

				IPHostEntry dnsHost = Dns.GetHostEntry( "dns.msftncsi.com" );

				if ( dnsHost.AddressList.Count( ) < 0 || dnsHost.AddressList[ 0 ].ToString( ) != "131.107.255.255" )
				{
					return false;
				}
			}
			catch
			{
				// Debug.WriteLine( ex );
				return false;
			}

			return true;
		}

		public static void OpenWebPage( string url, Form parent = null )
		{
			try
			{
				Process.Start( url );
			}
			catch ( Exception ex )
			{
				WriteErrorLog( ex );
			}
		}

		public static string ParseIconHTML( string base64ImageCode, int sizeW, int sizeH )
		{
			StringBuilder sb = new StringBuilder( @"<html><head><style>
					html, body { margin: 0; width: 100%; height: 100%; }
				</style></head>
				<body><img src='$image' width='$sizeWpx' height='$sizeHpx' /></body>
			</html>" );

			sb.Replace( "$image", base64ImageCode );
			sb.Replace( "$sizeW", sizeW.ToString( ) );
			sb.Replace( "$sizeH", sizeH.ToString( ) );

			return sb.ToString( );
		}

		public static void SetUriCookieContainerToNaverCookies( string url )
		{
			//if ( GlobalVar.COOKIES_LIST.Count == 0 ) return;

			//foreach ( CookieTable i in GlobalVar.COOKIES_LIST )
			//{
			//	WinAPI.InternetSetCookie( url, i.id, i.value );
			//}
		}

		// http://fdin.tistory.com/entry/C%EC%97%90%EC%84%9C-WebBrowser-cookie%EB%A5%BC-HttpWebRequest%EB%A1%9C-%EC%98%AE%EA%B8%B0%EA%B8%B0
		public static CookieContainer GetUriCookieContainer( Uri uri )
		{
			//CookieContainer cookies = null;

			//int datasize = 8192 * 16;
			//StringBuilder cookieData = new StringBuilder( datasize );
			//if ( !WinAPI.InternetGetCookieEx( uri.ToString( ), null, cookieData, ref datasize, 0x2000, IntPtr.Zero ) )
			//{
			//	if ( datasize < 0 ) return null;

			//	cookieData = new StringBuilder( datasize );
			//	if ( !WinAPI.InternetGetCookieEx( uri.ToString( ), null, cookieData, ref datasize, 0x2000, IntPtr.Zero ) )
			//		return null;
			//}

			//if ( cookieData.Length > 0 )
			//{
			//	cookies = new CookieContainer( );
			//	cookies.SetCookies( uri, cookieData.ToString( ).Replace( ';', ',' ) );
			//}

			return null;
		}
		#endregion

		public static Bitmap ImageCompress( Bitmap image )
		{
			var encoder = ImageCodecInfo.GetImageEncoders( )
							.First( c => c.FormatID == ImageFormat.Jpeg.Guid );
			var encParams = new EncoderParameters( 1 );
			encParams.Param[ 0 ] = new EncoderParameter( System.Drawing.Imaging.Encoder.Quality, 10L );

			image.SaveAdd( encParams );

			return image;
		}

		public static bool ImageSave( string path, byte[ ] byteArray, bool qualityModify = false, long quality = 100L )
		{
			try
			{
				using ( MemoryStream stream = new MemoryStream( byteArray ) )
				{
					using ( Bitmap image = new Bitmap( stream ) )
					{
						if ( qualityModify )
						{
							ImageCodecInfo encoder = ImageCodecInfo.GetImageEncoders( ).First( c => c.FormatID == ImageFormat.Jpeg.Guid );

							using ( EncoderParameters encodingParams = new EncoderParameters( 1 ) )
							{
								encodingParams.Param[ 0 ] = new EncoderParameter( System.Drawing.Imaging.Encoder.Quality, quality );
								image.Save( path, encoder, encodingParams );

								return true;
							}
						}
						else
						{
							image.Save( path );
							return true;
						}
					}
				}
			}
			catch
			{
				return false;
			}
		}

		public static MemoryStream FileToMemoryStream( string dir )
		{
			try
			{
				return new MemoryStream( File.ReadAllBytes( dir ) );
			}
			catch
			{
				return null;
			}
		}

		public static MemoryStream URLFileToMemoryStream( string url )
		{
			try
			{
				return new MemoryStream( ( new WebClient( ) ).DownloadData( url ) );
			}
			catch
			{
				return null;
			}
		}

		public static byte[ ] URLFileToByteArray( string url )
		{
			try
			{
				return ( new WebClient( ) ).DownloadData( url );
			}
			catch
			{
				return new byte[ ] { };
			}
		}

		// http://stackoverflow.com/questions/14488796/does-net-provide-an-easy-way-convert-bytes-to-kb-mb-gb-etc
		private static readonly string[ ] sizeSuffixes = { "bytes", "KB", "MB", "GB", "TB", "PB", "EB", "ZB", "YB" };

		public static string SizeSuffix( long value, int decimalPlaces = 1 )
		{
			if ( value < 0 ) { return "-" + SizeSuffix( -value ); }

			int i = 0;
			decimal dValue = ( decimal ) value;
			while ( Math.Round( dValue, decimalPlaces ) >= 1000 )
			{
				dValue /= 1024;
				i++;
			}

			return string.Format( "{0:n" + decimalPlaces + "} {1}", dValue, sizeSuffixes[ Util.Clamp( i, 0, sizeSuffixes.Length ) ] );
		}

		public static string StripFolderName( string folderName )
		{
			// IEnumerable<char> newChar = Path.GetInvalidPathChars( ).Concat( Path.GetInvalidFileNameChars( ) );

			StringBuilder sb = new StringBuilder( folderName );

			foreach ( char i in Path.GetInvalidPathChars( ).Concat( Path.GetInvalidFileNameChars( ) ) )
			{
				sb = sb.Replace( i, '_' );
			}

			return sb.ToString( );
			//return System.Text.RegularExpressions.Regex.Replace( folderName, "[\\\\/:*?\"<>|]", "_" );
		}

		// https://gist.github.com/superic/8165746
		public static Bitmap Blur( Bitmap image, Rectangle rectangle, Int32 blurSize )
		{
			Bitmap blurred = new Bitmap( image.Width, image.Height );

			// make an exact copy of the bitmap provided
			using ( Graphics graphics = Graphics.FromImage( blurred ) )
				graphics.DrawImage( image, new Rectangle( 0, 0, image.Width, image.Height ),
					new Rectangle( 0, 0, image.Width, image.Height ), GraphicsUnit.Pixel );

			// look at every pixel in the blur rectangle
			for ( Int32 xx = rectangle.X; xx < rectangle.X + rectangle.Width; xx++ )
			{
				for ( Int32 yy = rectangle.Y; yy < rectangle.Y + rectangle.Height; yy++ )
				{
					Int32 avgR = 0, avgG = 0, avgB = 0;
					Int32 blurPixelCount = 0;

					// average the color of the red, green and blue for each pixel in the
					// blur size while making sure you don't go outside the image bounds
					for ( Int32 x = xx; ( x < xx + blurSize && x < image.Width ); x++ )
					{
						for ( Int32 y = yy; ( y < yy + blurSize && y < image.Height ); y++ )
						{
							Color pixel = blurred.GetPixel( x, y );

							avgR += pixel.R;
							avgG += pixel.G;
							avgB += pixel.B;

							blurPixelCount++;
						}
					}

					if ( blurPixelCount != 0 )
					{
						avgR = avgR / blurPixelCount;
						avgG = avgG / blurPixelCount;
						avgB = avgB / blurPixelCount;
					}

					// now that we know the average for the blur size, set each pixel to that color
					for ( Int32 x = xx; x < xx + blurSize && x < image.Width && x < rectangle.Width; x++ )
						for ( Int32 y = yy; y < yy + blurSize && y < image.Height && y < rectangle.Height; y++ )
							blurred.SetPixel( x, y, Color.FromArgb( avgR, avgG, avgB ) );
				}
			}

			return blurred;
		}
	}
}
