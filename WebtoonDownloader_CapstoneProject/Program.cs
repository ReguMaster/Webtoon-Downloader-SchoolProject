using System;
using System.Threading;
using System.Windows.Forms;
using WebtoonDownloader_CapstoneProject.Core;
using static WebtoonDownloader_CapstoneProject.Core.NotifyBox;

namespace WebtoonDownloader_CapstoneProject
{
	static class Program
	{
		/// <summary>
		/// 해당 응용 프로그램의 주 진입점입니다.
		/// </summary>
		[STAThread]
		static void Main( )
		{
			if ( !CheckProgram( ) ) return;

			Application.EnableVisualStyles( );
			Application.SetCompatibleTextRenderingDefault( false );
			Application.Run( new MainForm( ) );
		}

		// http://stackoverflow.com/questions/19147/what-is-the-correct-way-to-create-a-single-instance-application
		private static Mutex mutex = new Mutex( true, "{e5c4a1e2-66ce-44b6-a119-ad2adb863c45}" );
		public static bool CheckProgram( )
		{
			if ( mutex.WaitOne( TimeSpan.Zero, true ) )
			{
				try
				{
					System.Reflection.Assembly.Load( "HtmlAgilityPack" ).GetName( );
					//System.Reflection.Assembly.Load( "System.Net.Json" ).GetName( );
					//System.Reflection.Assembly.Load( "Freezer" ).GetName( );
				}
				catch ( Exception )
				{
					Util.WriteErrorLog( "DLLNotFound", Util.LogSeverity.ERROR );
					NotifyBox.Show( null, "프로그램 오류", "Program Error", "죄송합니다, 필수 라이브러리를 불러올 수 없었습니다.\n프로그램을 종료합니다.", NotifyBoxType.OK, NotifyBoxIcon.Error );
					return false;
				}

				foreach ( System.Drawing.FontFamily ix in ( new System.Drawing.Text.InstalledFontCollection( ) ).Families )
				{
					if ( ix.Name == "나눔고딕" & ix.IsStyleAvailable( System.Drawing.FontStyle.Bold ) )
					{
						goto fontInstalled;
					}
				}

				Util.WriteErrorLog( "FontNotFound", Util.LogSeverity.ERROR );
				NotifyBox.Show( null, "프로그램 오류", "Program Error", "죄송합니다, 프로그램 실행에 필요한 폰트가 설치되지 않았습니다.\n프로그램을 종료합니다.", NotifyBoxType.OK, NotifyBoxIcon.Error );

				return false;

				fontInstalled:

				return true;
			}
			else
			{
				NotifyBox.Show( null, "프로그램 오류", "Program Error", "이미 웹툰 다운로더가 실행 중 입니다.", NotifyBoxType.OK, NotifyBoxIcon.Warning );
				return false;
			}
		}
	}
}
