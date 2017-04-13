using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using HtmlAgilityPack;

namespace WebtoonDownloader_CapstoneProject.Core
{
	public static class NaverWebtoon
	{
		public struct WebtoonDetailPageInformations // 웹툰 한 회 페이지의 정보들을 담는 구조체
		{
			public string title;
			public string thumbnail;
			public List<string> contents;
			public string commentByAuthor;
			public List<string> bestComments;
		}

		public struct WebtoonListPageInformations // 특정 웹툰의 list.nhn 페이지에서 파싱 가능한 글로벌 정보를 담는 구조체
		{
			public string title;
			public string description;
			public string author;
			public string thumbnail;
			public string url;

			public List<WebtoonListSpecificPageInformations> specificPageInformations; // 삭제필요
		}

		public struct WebtoonListSpecificPageInformations
		{
			public string title;
			public string thumbnail;
			public string url;
			public int num;
			public double starRate;
			public string uploadDate;
			public string bgm;

			public List<string> contents; // WebtoonDetailPageInformations;
		}

		public static bool IsValidWebtoonListURL( ref string url )
		{
			try
			{
				Uri newURI = new Uri( url );

				System.Collections.Specialized.NameValueCollection query = HttpUtility.ParseQueryString( newURI.Query );

				if ( newURI.GetLeftPart( UriPartial.Path ).ToLower( ) == "http://comic.naver.com/webtoon/list.nhn" && !string.IsNullOrEmpty( query.Get( "titleId" ) ) )
				{
					url = newURI.GetLeftPart( UriPartial.Path ) + "?titleId=" + query.Get( "titleId" );

					return true;
				}

				return false;
			}
			catch ( UriFormatException )
			{
				return false;
			}
		}

		private static string GetPageBGMUrl( string url )
		{
			try
			{
				HttpWebRequest request = ( HttpWebRequest ) WebRequest.Create( url );
				request.Method = "GET";
				request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/57.0.2987.133 Safari/537.36";

				using ( HttpWebResponse response = ( HttpWebResponse ) request.GetResponse( ) )
				{
					using ( Stream responseStream = response.GetResponseStream( ) )
					{
						using ( StreamReader reader = new StreamReader( responseStream, Encoding.UTF8 ) )
						{
							string html = reader.ReadToEnd( );

							//naver.comic.bgmUrl = "http://flash.comic.naver.net/bgsound/8b1072a2-254a-11e5-969a-38eaa78b7a54.mp3";
							//showMusicPlayer("http://flash.comic.naver.net/bgsound/8b1072a2-254a-11e5-969a-38eaa78b7a54.mp3");
							if ( html.Contains( "showMusicPlayer(\"" ) ) // JavaScript 함수 검사
							{
								int startIndex = html.IndexOf( "showMusicPlayer(\"" ) + 17;
								int endIndex = html.IndexOf( "\");", startIndex );

								return html.Substring( startIndex, endIndex - startIndex );
							}
							else
								return "";

						}
					}
				}
			}
			catch ( Exception ex )
			{
				Util.WriteErrorLog( ex.Message, Util.LogSeverity.EXCEPTION );
				return "";
			}
		}

		private static int GetWebtoonListPageMaxPage( string url )
		{
			try
			{
				Uri uri = new Uri( url );
				System.Collections.Specialized.NameValueCollection query = HttpUtility.ParseQueryString( uri.Query );

				//http://comic.naver.com/webtoon/list.nhn?titleId=679519&weekday=thu&page=6

				url += "&page=999999999";

				HttpWebRequest request = ( HttpWebRequest ) WebRequest.Create( url );
				request.Method = "GET";
				request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/57.0.2987.133 Safari/537.36";

				using ( HttpWebResponse response = ( HttpWebResponse ) request.GetResponse( ) )
				{
					using ( Stream responseStream = response.GetResponseStream( ) )
					{
						HtmlDocument document = new HtmlDocument( );
						document.Load( responseStream, Encoding.UTF8 );

						int currentMaxPage = -1;

						foreach ( HtmlNode i in document.DocumentNode.SelectNodes( "//em[@class=\"num_page\"]" ) )
						{
							if ( int.Parse( i.InnerText ) > currentMaxPage )
								currentMaxPage = int.Parse( i.InnerText );

							//Console.WriteLine( i.InnerText );
						}

						return currentMaxPage;
					}
				}
			}
			catch ( Exception ex )
			{
				Util.WriteErrorLog( ex.Message, Util.LogSeverity.EXCEPTION );
				Console.WriteLine( ex );
				return -1;
			}
		}

		private static void InternalDownload( string directURL, string dir )
		{
			HttpWebRequest request = ( HttpWebRequest ) WebRequest.Create( directURL );
			request.Method = "GET";
			request.KeepAlive = true;
			request.Referer = "http://comic.naver.com";
			request.Accept = "image/webp,image/*,*/*;q=0.8";
			request.UserAgent = "Mozilla/5.0 (Windows NT 6.1) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/53.0.2785.116 Safari/537.36";

			using ( HttpWebResponse response = ( HttpWebResponse ) request.GetResponse( ) )
			{
				using ( Stream stReadData = response.GetResponseStream( ) )
				{
					using ( MemoryStream ms = new MemoryStream( ) )
					{
						stReadData.CopyTo( ms );

						File.WriteAllBytes( dir, ms.ToArray( ) );
					}
				}
			}
		}

		public static void Download( WebtoonListPageInformations info, string baseDir, Action<string> MessageChangeCallBack, Action<WebtoonListSpecificPageInformations> DownloadPageChanged, Action<float, float> DownloadProgressChanged, Action DownloadFinished )
		{
			try
			{
				int maxListPage = GetWebtoonListPageMaxPage( info.url );

				if ( maxListPage > 0 )
				{
					//File.AppendAllText( "data.txt", data.title + "\n" + data.description + "\n" + data.thumbnail + "\n\n" );

					info.specificPageInformations = new List<WebtoonListSpecificPageInformations>( );

					int totalDownloadImages = 0;
					int currentDownloadImages = 0;
					for ( int currentListPage = 1; currentListPage <= maxListPage; currentListPage++ )
					{
						//Console.WriteLine( currentListPage + " / " + maxListPage );

						List<WebtoonListSpecificPageInformations> specificPageInformations = GetInternalWebtoonListPageInformations( info.url, currentListPage );

						if ( specificPageInformations != null )
						{
							info.specificPageInformations = info.specificPageInformations.Concat( specificPageInformations ).ToList( );
						}

						foreach ( WebtoonListSpecificPageInformations i in specificPageInformations )
						{
							if ( i.contents == null ) continue;

							totalDownloadImages += i.contents.Count;
						}

						MessageChangeCallBack.Invoke( "서버에서 기본적인 정보를 불러오는 중 ... [" + currentListPage + "/" + maxListPage + "]" );
					}

					foreach ( WebtoonListSpecificPageInformations i in info.specificPageInformations )
					{
						DownloadPageChanged.Invoke( i );
						MessageChangeCallBack.Invoke( i.num + "화 다운로드 중 ..." );

						string path = baseDir + "\\" + ( i.num + " - " + Util.StripFolderName( i.title ) );

						Directory.CreateDirectory( path );
						InternalDownload( i.thumbnail, Path.Combine( path, "썸네일.jpg" ) );

						int count = 0;
						foreach ( string i2 in i.contents )
						{
							InternalDownload( i2, Path.Combine( path, ++count + ".jpg" ) );

							//( ( float ) count / ( float ) i.contents.Count ),
							DownloadProgressChanged.Invoke( 0, ( float ) ++currentDownloadImages / ( float ) totalDownloadImages );
							Util.Delay( 30 );
						}
					}

					DownloadFinished.Invoke( );
					//File.AppendAllText( "data.txt", maxListPage + " -> maxpage > \n\n\n" );
				}
				else
				{

				}
			}
			catch ( ThreadAbortException )
			{

			}
		}

		private static List<WebtoonListSpecificPageInformations> GetInternalWebtoonListPageInformations( string url, int page )
		{
			try
			{
				url += "&page=" + page;

				HttpWebRequest request = ( HttpWebRequest ) WebRequest.Create( url );
				request.Method = "GET";
				request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/57.0.2987.133 Safari/537.36";

				using ( HttpWebResponse response = ( HttpWebResponse ) request.GetResponse( ) )
				{
					using ( Stream responseStream = response.GetResponseStream( ) )
					{
						HtmlDocument document = new HtmlDocument( );
						document.Load( responseStream, Encoding.UTF8 );

						List<WebtoonListSpecificPageInformations> specificPageInformations = new List<WebtoonListSpecificPageInformations>( );

						int index = 1;
						foreach ( HtmlNode node in document.DocumentNode.SelectNodes( "//tr/td[@class!=\"title\"]" ) )
						{
							WebtoonListSpecificPageInformations specificPageData = new WebtoonListSpecificPageInformations( );

							HtmlNode thumbnailImageNode = document.DocumentNode.SelectSingleNode( "//tr[" + index + "]/td/a/img" );
							HtmlNode thumbnailImageClickerANode = document.DocumentNode.SelectSingleNode( "//tr[" + index + "]/td/a" );

							HtmlNode starRateNode = document.DocumentNode.SelectSingleNode( "//tr[" + index + "]/td/div/strong" );
							HtmlNode uploadDateNode = document.DocumentNode.SelectSingleNode( "//tr[" + index + "]/td[@class=\"num\"]" );

							HtmlNode bgmAvaliable = document.DocumentNode.SelectSingleNode( "//tr[" + index + "]/td[@class=\"title\"]/span[@class=\"ico_bgm\"]" );

							//Console.WriteLine( index + " >PAGE : " + thumbnailImageNode.GetAttributeValue( "src", "" ) + " / " + thumbnailImageClickerANode.GetAttributeValue( "href", "" ) + " / " + thumbnailImageNode.GetAttributeValue( "title", "" ) );
							//Console.WriteLine( starRateNode.InnerText );
							//Console.WriteLine( uploadDateNode.InnerText );
							//Console.WriteLine( "BGM : " + ( bgmAvaliable != null ).ToString( ) );

							specificPageData.title = HttpUtility.HtmlDecode( thumbnailImageNode.GetAttributeValue( "title", "" ) );
							specificPageData.thumbnail = thumbnailImageNode.GetAttributeValue( "src", "" );
							specificPageData.starRate = double.Parse( starRateNode.InnerText );
							specificPageData.uploadDate = uploadDateNode.InnerText;
							specificPageData.url = "http://comic.naver.com" + thumbnailImageClickerANode.GetAttributeValue( "href", "" );
							specificPageData.num = int.Parse( HttpUtility.ParseQueryString( ( new Uri( specificPageData.url ) ).Query ).Get( "no" ) );

							WebtoonDetailPageInformations detail = GetDetailPageInformations( specificPageData.url );

							specificPageData.contents = detail.contents;

							if ( bgmAvaliable != null )
								specificPageData.bgm = GetPageBGMUrl( specificPageData.url );
							else
								specificPageData.bgm = "";

							specificPageInformations.Add( specificPageData );

							index++;
						}

						return specificPageInformations;
					}
				}
			}
			catch ( Exception ex )
			{
				Util.WriteErrorLog( ex.Message, Util.LogSeverity.EXCEPTION );
				Console.WriteLine( ex );
				return null;
			}
		}

		public static WebtoonListPageInformations? GetWebtoonListPageInformations( string url )
		{
			try
			{
				HttpWebRequest request = ( HttpWebRequest ) WebRequest.Create( url );
				request.Method = "GET";
				request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/57.0.2987.133 Safari/537.36";

				using ( HttpWebResponse response = ( HttpWebResponse ) request.GetResponse( ) )
				{
					using ( Stream responseStream = response.GetResponseStream( ) )
					{
						HtmlDocument document = new HtmlDocument( );
						document.Load( responseStream, Encoding.UTF8 );

						WebtoonListPageInformations data = new WebtoonListPageInformations( );

						foreach ( HtmlNode i in document.DocumentNode.SelectNodes( "//meta" ) )
						{
							switch ( i.GetAttributeValue( "property", "" ) )
							{
								case "og:title":
									data.title = HttpUtility.HtmlDecode( i.GetAttributeValue( "content", "" ) );
									break;
								case "og:description":
									data.description = HttpUtility.HtmlDecode( i.GetAttributeValue( "content", "" ) );
									break;
								case "og:image":
									data.thumbnail = i.GetAttributeValue( "content", "" );
									break;
							}
						}

						HtmlNode webtoonAuthorLabel = document.DocumentNode.SelectSingleNode( "//span[@class=\"wrt_nm\"]" ); // 웹툰 작가 이름 찾기 -> author

						data.author = webtoonAuthorLabel.InnerText.Trim( );
						data.url = url;

						//int maxListPage = GetWebtoonListPageMaxPage( url );

						//if ( maxListPage > 0 )
						//{
						//	//File.AppendAllText( "data.txt", data.title + "\n" + data.description + "\n" + data.thumbnail + "\n\n" );

						//	data.specificPageInformations = new List<WebtoonListSpecificPageInformations>( );

						//	for ( int currentListPage = 1; currentListPage <= maxListPage; currentListPage++ )
						//	{
						//		//Console.WriteLine( currentListPage + " / " + maxListPage );

						//		List<WebtoonListSpecificPageInformations> specificPageInformations = GetInternalWebtoonListPageInformations( url, currentListPage );

						//		if ( specificPageInformations != null )
						//		{
						//			data.specificPageInformations = data.specificPageInformations.Concat( specificPageInformations ).ToList( );
						//		}
						//	}
						//	//File.AppendAllText( "data.txt", maxListPage + " -> maxpage > \n\n\n" );
						//}
						//else
						//{

						//}

						return data;

						//Console.WriteLine( data.title + Environment.NewLine + data.description + Environment.NewLine + data.thumbnail );
					}
				}
			}
			catch ( Exception ex )
			{
				Util.WriteErrorLog( ex.Message, Util.LogSeverity.EXCEPTION );
				Console.WriteLine( ex );
				return null;
			}
		}

		public static WebtoonDetailPageInformations GetDetailPageInformations( string url )
		{
			try
			{
				HttpWebRequest request = ( HttpWebRequest ) WebRequest.Create( url );
				request.Method = "GET";
				request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/57.0.2987.133 Safari/537.36";

				using ( HttpWebResponse response = ( HttpWebResponse ) request.GetResponse( ) )
				{
					using ( Stream responseStream = response.GetResponseStream( ) )
					{
						//<meta property="og:description" content="82화 - 귀영 (3화)">

						HtmlDocument document = new HtmlDocument( );
						document.Load( responseStream, Encoding.UTF8 );

						WebtoonDetailPageInformations dataStruct = new WebtoonDetailPageInformations( );

						HtmlNode webtoonDetailPageTitle = document.DocumentNode.SelectSingleNode( "//meta[@property=\"og:title\"]" ); // 웹툰 화 제목 찾기 -> title
						HtmlNode webtoonDetailPageThumbnail = document.DocumentNode.SelectSingleNode( "//meta[@property=\"og:image\"]" ); // 웹툰 썸네일 찾기 -> thumbnail
						HtmlNode webtoonDetailContentImagesDIV = document.DocumentNode.SelectSingleNode( "//div[@class=\"wt_viewer\"]" ); // 웹툰 이미지 콘텐츠 찾기 -> contents
						HtmlNode webtoonCommentByAuthorDIV = document.DocumentNode.SelectSingleNode( "//div[@class=\"writer_info\"]" ); // 작가의 말 찾기 -> commentByAuthor

						if ( webtoonDetailPageTitle != null )
						{
							//Console.WriteLine( webtoonDetailPageTitle.GetAttributeValue( "content", "" ) );
							dataStruct.title = webtoonDetailPageTitle.GetAttributeValue( "content", "" ).Trim( );
						}

						if ( webtoonDetailPageThumbnail != null )
						{
							//Console.WriteLine( webtoonDetailPageThumbnail.GetAttributeValue( "content", "" ) );
							dataStruct.thumbnail = webtoonDetailPageThumbnail.GetAttributeValue( "content", "" ).Trim( );
						}

						if ( webtoonDetailContentImagesDIV != null )
						{
							dataStruct.contents = new List<string>( );

							foreach ( HtmlNode i in webtoonDetailContentImagesDIV.ChildNodes )
							{
								if ( i.Name == "img" )
								{
									//Console.WriteLine( i.GetAttributeValue( "src", "" ) );
									dataStruct.contents.Add( i.GetAttributeValue( "src", "" ).Trim( ) );
									//break;
								}
							}
						}

						if ( webtoonCommentByAuthorDIV != null )
						{
							foreach ( HtmlNode i in webtoonCommentByAuthorDIV.ChildNodes )
							{
								if ( i.Name == "p" )
								{
									//Console.WriteLine( i.InnerText );
									dataStruct.commentByAuthor = i.InnerText.Trim( );
									break;
								}
							}
						}

						return dataStruct;
						//}
					}
				}
			}
			catch ( Exception ex )
			{
				Util.WriteErrorLog( ex.Message, Util.LogSeverity.EXCEPTION );
				Console.WriteLine( ex );
				return new WebtoonDetailPageInformations( );
			}
		}
	}
}
