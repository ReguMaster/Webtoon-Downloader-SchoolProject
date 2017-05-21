using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static WebtoonDownloader_CapstoneProject.Core.NaverWebtoon;

namespace WebtoonDownloader_CapstoneProject
{
	public static class GlobalVar
	{
		public static readonly System.Drawing.Color ThemeColor = System.Drawing.Color.Silver;
		public static readonly string APPLICATION_DIRECTORY;
		public static readonly string APPLICATION_VER;
		public const string DefaultUserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/57.0.2987.133 Safari/537.36";

		public static WebtoonListPageInformations? GlobalListPageInformations;
		public static Thread DownloadThread;
		public static List<string> DownloadErrorList;
		public static int BeginDownloadDetailNum;
		public static int EndDownloadDetailNum;
		public static bool BGMDownloadOption;
		public static bool ViewerCreateOption;
		public static int QualityOption;

		public const int DefaultCountDown = 30;

		static GlobalVar( )
		{
			APPLICATION_DIRECTORY = System.Windows.Forms.Application.StartupPath;
			APPLICATION_VER = System.Reflection.Assembly.GetExecutingAssembly( ).GetName( ).Version.ToString( );
			//APPLICATION_VER = string.Format( "{0}.{1}.{2}.{3}", version.Major, version.Minor, version.Build, version.Revision );
		}
	}
}
