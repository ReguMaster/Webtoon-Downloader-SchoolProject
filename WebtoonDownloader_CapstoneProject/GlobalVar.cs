using System.Collections.Generic;
using System.Threading;
using WebtoonDownloader_CapstoneProject.Core;

namespace WebtoonDownloader_CapstoneProject
{
	public static class GlobalVar
	{
		public static readonly System.Drawing.Color ThemeColor = System.Drawing.Color.Silver;
		public static readonly string APPLICATION_DIRECTORY; // 현재 프로그램 경로
		public static readonly string APPLICATION_VER; // 프로그램 버전
		public static readonly string CACHE_DIRECTORY; // CACHE 경로
		public const string DefaultUserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/57.0.2987.133 Safari/537.36"; // 기본 UserAgent

		public static NaverWebtoon.WebtoonListPageInformations? GlobalListPageInformations;
		public static Thread DownloadThread; // 다운로드 thread
		public static List<string> DownloadErrorList; // 사용하지 않음
		public static int BeginDownloadDetailNum; // 기본 설정용 시작 지점
		public static int EndDownloadDetailNum; // 기본 설정용 끝 지점
		public static bool BGMDownloadOption; // BGM 다운로드 옵션
		public static bool ViewerCreateOption; // HTML 뷰어 생성 옵션
		public static int QualityOption; // 이미지 품질 옵션
		public static List<int> DownloadSections; // 다운로드 구간 세부 설정용 지점

		public const int DefaultSystemShutDownCountDown = 30;

		static GlobalVar( )
		{
			APPLICATION_DIRECTORY = System.Windows.Forms.Application.StartupPath;
			APPLICATION_VER = System.Reflection.Assembly.GetExecutingAssembly( ).GetName( ).Version.ToString( );
			CACHE_DIRECTORY = APPLICATION_DIRECTORY + @"\cache";
		}
	}
}
