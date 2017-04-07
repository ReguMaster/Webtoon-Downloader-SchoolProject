using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
			Application.EnableVisualStyles( );
			Application.SetCompatibleTextRenderingDefault( false );
			Application.Run( new MainForm( ) );
		}

		public static bool CheckProgram( )
		{
			try
			{
				System.Reflection.Assembly.Load( "HtmlAgilityPack" ).GetName( );
				System.Reflection.Assembly.Load( "System.Net.Json" ).GetName( );
				//System.Reflection.Assembly.Load( "Freezer" ).GetName( );
			}
			catch ( Exception )
			{
				Util.WriteErrorLog( "DLLNotFound", Util.LogSeverity.ERROR );
				NotifyBox.Show( null, "프로그램 오류", "Program Error", "죄송합니다, 필수 라이브러리를 불러올 수 없었습니다.\n프로그램을 종료합니다.", NotifyBoxType.OK, NotifyBoxIcon.Error );
				return false;
			}

			return true;
		}
	}
}
