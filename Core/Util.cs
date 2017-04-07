using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
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

		// http://stackoverflow.com/questions/3519539/how-to-check-if-a-string-contains-any-of-some-strings
		public static bool ContainsMultiple( this string target, params string[ ] args )
		{
			foreach ( string i in args )
			{
				if ( target.Contains( i ) )
					return true;
			}

			return false;
		}

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

			return Color.FromArgb( ( int ) Math.Round( newA ), ( int ) Math.Round( newR ), ( int ) Math.Round( newG ), ( int ) Math.Round( newB ) );
		}

		// http://bananamandoo.tistory.com/27
		public static void Delay( int ms )
		{
			DateTime thisMoment = DateTime.Now;
			DateTime afterWards = thisMoment.Add( new TimeSpan( 0, 0, 0, 0, ms ) );

			while ( afterWards >= thisMoment )
			{
				Application.DoEvents( );
				thisMoment = DateTime.Now;
			}
		}

		public static string StripFolderName( string folderName )
		{
			return System.Text.RegularExpressions.Regex.Replace( folderName, "[\\\\/:*?\"<>|]", "_" );
		}

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
					string.Format( "MilkPowerCafeStaff_ErrorLOG_{0} @{1} :	{2} -> #{3}		{4}:{5}" + Environment.NewLine,
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

		// http://stackoverflow.com/questions/14488796/does-net-provide-an-easy-way-convert-bytes-to-kb-mb-gb-etc
		private static readonly string[ ] SizeSuffixes = { "bytes", "KB", "MB", "GB", "TB", "PB", "EB", "ZB", "YB" };

		public static string SizeSuffix( Int64 value, int decimalPlaces = 1 )
		{
			if ( value < 0 ) { return "-" + SizeSuffix( -value ); }

			int i = 0;
			decimal dValue = ( decimal ) value;
			while ( Math.Round( dValue, decimalPlaces ) >= 1000 )
			{
				dValue /= 1024;
				i++;
			}

			return string.Format( "{0:n" + decimalPlaces + "} {1}", dValue, SizeSuffixes[ i ] );
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

		// http://stackoverflow.com/questions/10520048/calculate-md5-checksum-for-a-file
		public static string GetMD5Hash( string fileName )
		{
			try
			{
				using ( MD5 md5 = MD5.Create( ) )
				{
					using ( FileStream stream = File.OpenRead( fileName ) )
					{
						return Convert.ToBase64String( md5.ComputeHash( stream ) );
					}
				}
			}
			catch { return ""; }
		}

		public static string GetMD5Hash( byte[ ] fileByte )
		{
			try
			{
				using ( MD5 md5 = MD5.Create( ) )
				{
					using ( Stream stream = new MemoryStream( fileByte ) )
					{
						return Convert.ToBase64String( md5.ComputeHash( stream ) );
					}
				}
			}
			catch { return ""; }
		}

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

		public static void OpenWebPage( string url, Form parent = null )
		{
			try
			{
				Process.Start( url );
			}
			catch ( Exception ex )
			{
				WriteErrorLog( "WebPageOpenFailed - " + url + " - " + ex.Message, LogSeverity.EXCEPTION );
				//NotifyBox.Show( parent, "오류", "죄송합니다, 웹 페이지를 여는 도중 오류가 발생했습니다.", NotifyBoxType.OK, NotifyBoxIcon.Error );
			}
		}

		/*
		<html><head><style>
					html, body { margin: 0; width: 100%; height: 100%; }
				</style></head>
				<body><img src='data:image/gif;base64,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' width=45px height=40px /></body>
			</html>
			*/
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
	}
}
