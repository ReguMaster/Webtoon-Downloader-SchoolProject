using System;
using System.IO;
using System.Net;

namespace WebtoonDownloader_CapstoneProject.Core
{
	static class HttpWebRequestHelper
	{
		public static void GetHttpRequest(
			string url,
			string userAgent,
			string referer,
			Action<HttpWebRequest> BeginRequest = null,
			Action<HttpWebRequest, Stream> EndRequest = null,
			Action<WebException> OnError = null
		)
		{
			try
			{
				HttpWebRequest request = ( HttpWebRequest ) WebRequest.Create( url );
				request.Method = "GET";

				if ( userAgent != null )
					request.UserAgent = userAgent;

				if ( referer != null )
					request.Referer = referer;

				BeginRequest?.Invoke( request );

				using ( HttpWebResponse response = ( HttpWebResponse ) request.GetResponse( ) )
				{
					using ( Stream responseStream = response.GetResponseStream( ) )
					{
						EndRequest?.Invoke( request, responseStream );
					}
				}
			}
			catch ( WebException ex )
			{
				OnError?.Invoke( ex );
			}
		}
	}
}
