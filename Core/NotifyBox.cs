using System;
using System.Windows.Forms;
using WebtoonDownloader_CapstoneProject.UI.Forms;

namespace WebtoonDownloader_CapstoneProject.Core
{
	public static class NotifyBox
	{
		public enum NotifyBoxResult
		{
			Yes,
			No,
			OK,
			Null
		}

		public enum NotifyBoxType
		{
			YesNo,
			OK
		}

		public enum NotifyBoxIcon
		{
			Warning,
			Error,
			Information,
			Question,
			Danger
		}

		public static NotifyBoxResult Show( Form parent, string title, string titleEng, string message, NotifyBoxType type, NotifyBoxIcon icon, int timeout = 0 )
		{
			NotifyBoxResult returnType = NotifyBoxResult.Null;

			NotifyBoxForm form = new NotifyBoxForm( title, titleEng, message, type, icon, timeout );

			if ( parent == null )
			{
				form.StartPosition = FormStartPosition.CenterScreen;
				form.ShowDialog( );

				returnType = form.Result;
			}
			else
			{
				parent.Invoke( new Action( ( ) =>
				{
					form.Owner = parent;
					form.StartPosition = FormStartPosition.CenterParent;
					form.ShowDialog( parent );

					returnType = form.Result;
				} ) );
			}

			return returnType;
		}
	}
}
