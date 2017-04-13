using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.IO;
using System.Net;
using HtmlAgilityPack;
using System.Net.Json;
using System.Text.RegularExpressions;
using System.Web;

namespace Tester
{
	class Program
	{
		struct WebtoonDetailPageInformations // 웹툰 한 회 페이지의 정보들을 담는 구조체
		{
			public string title;
			public string thumbnail;
			public List<string> contents;
			public string commentByAuthor;
			public List<string> bestComments;
		}

		struct WebtoonListPageInformations
		{
			public string title;
			public string description;
			public string thumbnail;
			public List<WebtoonListSpecificPageInformations> specificPageInformations;
		}

		struct WebtoonListSpecificPageInformations
		{
			public string title;
			public string thumbnail;
			public string url;
			public int num;
			public double starRate;
			public string uploadDate;
			public string bgm;
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

							Console.WriteLine( i.InnerText );
						}

						return currentMaxPage;
					}
				}
			}
			catch ( Exception ex )
			{
				Console.WriteLine( ex );

				return -1;
			}
		}

		public static void BeginWork( string url )
		{
			if ( IsValidWebtoonListURL( ref url ) )
			{

			}
			else
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
						//using ( StreamReader reader = new StreamReader( responseStream, Encoding.UTF8 ) )
						//{
						//	string html = reader.ReadToEnd( );

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

							Console.WriteLine( index + " >PAGE : " + thumbnailImageNode.GetAttributeValue( "src", "" ) + " / " + thumbnailImageClickerANode.GetAttributeValue( "href", "" ) + " / " + thumbnailImageNode.GetAttributeValue( "title", "" ) );
							Console.WriteLine( starRateNode.InnerText );
							Console.WriteLine( uploadDateNode.InnerText );
							Console.WriteLine( "BGM : " + ( bgmAvaliable != null ).ToString() );

							specificPageData.title = HttpUtility.HtmlDecode( thumbnailImageNode.GetAttributeValue( "title", "" ) );
							specificPageData.thumbnail = thumbnailImageNode.GetAttributeValue( "src", "" );
							specificPageData.starRate = double.Parse( starRateNode.InnerText );
							specificPageData.uploadDate = uploadDateNode.InnerText;
							specificPageData.url = "http://comic.naver.com" + thumbnailImageClickerANode.GetAttributeValue( "href", "" );
							specificPageData.num = int.Parse( HttpUtility.ParseQueryString( ( new Uri( specificPageData.url ) ).Query ).Get( "no" ) );

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
				Console.WriteLine( ex );

				return null;
			}
		}

		public static void GetWebtoonListPageInformations( string url )
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

						int maxListPage = GetWebtoonListPageMaxPage( url );

						if ( maxListPage > 0 )
						{
							//File.AppendAllText( "data.txt", data.title + "\n" + data.description + "\n" + data.thumbnail + "\n\n" );

							data.specificPageInformations = new List<WebtoonListSpecificPageInformations>( );

							for ( int currentListPage = 1; currentListPage <= maxListPage; currentListPage++ )
							{
								if ( currentListPage != 8 ) continue; // for test


								Console.WriteLine( currentListPage + " / " + maxListPage );

								List<WebtoonListSpecificPageInformations> specificPageInformations = GetInternalWebtoonListPageInformations( url, currentListPage );

								if ( specificPageInformations != null )
								{
									data.specificPageInformations = data.specificPageInformations.Concat( specificPageInformations ).ToList( );
								}
							}

							//File.AppendAllText( "data.txt", maxListPage + " -> maxpage > \n\n\n" );
							foreach ( WebtoonListSpecificPageInformations i in data.specificPageInformations )
							{
								//File.AppendAllText( "data.txt", i.title + "/" + i.starRate + "/" + i.uploadDate + " \n" );
							}
						}
						else
						{

						}

						//Console.WriteLine( data.title + Environment.NewLine + data.description + Environment.NewLine + data.thumbnail );

						//}
					}
				}
			}
			catch ( Exception ex )
			{
				Console.WriteLine( ex );
			}
		}

		public static string GetDetailPageInformations( string url )
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
						//using ( StreamReader reader = new StreamReader( responseStream, Encoding.UTF8 ) )
						//{
						//	string html = reader.ReadToEnd( );

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
							Console.WriteLine( webtoonDetailPageTitle.GetAttributeValue( "content", "" ) );
							dataStruct.title = webtoonDetailPageTitle.GetAttributeValue( "content", "" ).Trim( );
						}

						if ( webtoonDetailPageThumbnail != null )
						{
							Console.WriteLine( webtoonDetailPageThumbnail.GetAttributeValue( "content", "" ) );
							dataStruct.thumbnail = webtoonDetailPageThumbnail.GetAttributeValue( "content", "" ).Trim( );
						}

						if ( webtoonDetailContentImagesDIV != null )
						{
							dataStruct.contents = new List<string>( );

							foreach ( HtmlNode i in webtoonDetailContentImagesDIV.ChildNodes )
							{
								if ( i.Name == "img" )
								{
									Console.WriteLine( i.GetAttributeValue( "src", "" ) );
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
									Console.WriteLine( i.InnerText );
									dataStruct.commentByAuthor = i.InnerText.Trim( );
									break;
								}
							}
						}

						return "";
						//}
					}
				}
			}
			catch ( Exception ex )
			{
				Console.WriteLine( ex );
				return "";
			}
		}

		static void Main( string[ ] args )
		{
			string url = "http://comic.naver.com/webtoon/detail.nhn?titleId=679519&no=90&weekday=thu"; //"http://comic.naver.com/webtoon/detail.nhn?titleId=570503&no=92";

			//GetPageInformations( "http://comic.naver.com/webtoon/list.nhn?titleId=679519&weekday=thu" );

			//Console.WriteLine( GetPageBGMUrl( url ) );
			//GetDetailPageInformations( url );
			GetWebtoonListPageInformations( "http://comic.naver.com/webtoon/list.nhn?titleId=570503" );
			//while(true)
			//{

			//}
		}
	}
}
