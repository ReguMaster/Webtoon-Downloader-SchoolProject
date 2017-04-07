using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebtoonDownloader_CapstoneProject
{
	public static class GlobalVar
	{
		public static readonly System.Drawing.Color ThemeColor = System.Drawing.Color.Silver;
		public static readonly string APPLICATION_DIRECTORY;
		public static readonly string APPLICATION_VER;

		static GlobalVar( )
		{
			Version version = System.Reflection.Assembly.GetExecutingAssembly( ).GetName( ).Version;

			APPLICATION_DIRECTORY = System.Windows.Forms.Application.StartupPath;
			APPLICATION_VER = string.Format( "{0}.{1}.{2}.{3}", version.Major, version.Minor, version.Build, version.Revision );
		}
	}
}
