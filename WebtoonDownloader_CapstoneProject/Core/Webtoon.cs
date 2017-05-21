using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Web;
using HtmlAgilityPack;

#pragma warning disable 0168

namespace WebtoonDownloader_CapstoneProject.Core
{
	public static class NaverWebtoon
	{
		public struct WebtoonDetailPageInformations // 웹툰 한 회 페이지의 정보들을 담는 구조체
		{
			public string title; // 제목
			public string thumbnail; // 썸네일
			public List<string> contents; // 이미지
			public string commentByAuthor; // 작가의 말
			public List<string> bestComments; // 베스트 댓글
		}

		public struct WebtoonListPageInformations // 특정 웹툰의 list.nhn 페이지에서 파싱 가능한 글로벌 정보를 담는 구조체
		{
			public string title; // 제목
			public string description; // 설명
			public string author; // 작가 이름
			public string thumbnail; // 썸네일
			public string url; // 주소

			public List<WebtoonListSpecificPageInformations> specificPageInformations;
		}

		public struct WebtoonListSpecificPageInformations // 웹툰 한 게시 페이지에서 정보들을 담는 구조체
		{
			public string title; // 제목
			public string thumbnail; // 썸네일
			public string url; // 주소
			public int num; // 화
			public double starRate; // 별점 정보
			public string uploadDate; // 업로드 일
			public string bgm; // BGM

			public List<string> contents; // WebtoonDetailPageInformations;
		}

		public struct WebtoonSearchResultList // 웹툰 검색한 결과의 child 데이터를 담는 구조체
		{
			public string title;
			public string description;
			public string thumbnail;
			public string author;
			public string genre;
			public int totalNum;
			public string url;
			public bool[ ] metaData;
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
			catch
			{
				return false;
			}
		}

		private static int GetMaxSpecificPageSearchPage( string url )
		{
			//http://comic.naver.com/search.nhn?m=webtoon&keyword=%EC%97%B0&type=title&page=2

			try

			{
				url += "&page=99999999";

				HttpWebRequest request = ( HttpWebRequest ) WebRequest.Create( url );
				request.Method = "GET";
				request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/57.0.2987.133 Safari/537.36";

				using ( HttpWebResponse response = ( HttpWebResponse ) request.GetResponse( ) )
				{
					using ( Stream responseStream = response.GetResponseStream( ) )
					{
						HtmlDocument document = new HtmlDocument( );
						document.Load( responseStream, Encoding.UTF8 );

						//HtmlNode node = document.DocumentNode.SelectSingleNode( "//em[@class=\"num_page\"][ 1 ]" );

						string count = "";

						foreach ( HtmlNode node2 in document.DocumentNode.SelectNodes( "//em[@class=\"num_page\"]" ) )
						{
							count = node2.InnerText.Trim( );
						}

						return int.Parse( count );
					}
				}
			}
			catch ( Exception ex )
			{
				return -1;
			}
		}

		public static string[ ] InternalSearchWebtoonDetailRequest( string url )
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

						string descriptionData = "";
						string thumbnailData = "";

						foreach ( HtmlNode node in document.DocumentNode.SelectNodes( "//meta" ) )
						{
							switch ( node.GetAttributeValue( "property", "" ) )
							{
								case "og:description":
									descriptionData = node.GetAttributeValue( "content", "" );
									break;
								case "og:image":
									thumbnailData = node.GetAttributeValue( "content", "" );
									break;
							}
						}

						return new string[ 2 ]
						{
							descriptionData,
							thumbnailData
						};
					}
				}
			}
			catch ( Exception ex )
			{
				return new string[ 2 ] { "", "" };
			}
		}

		public static List<WebtoonSearchResultList> InternalSearchWebtoonRequest( string url, int page )
		{
			url += "&page=" + page;

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

						List<WebtoonSearchResultList> result = new List<WebtoonSearchResultList>( );

						HtmlNodeCollection masterNode = document.DocumentNode.SelectNodes( "//ul[@class=\"resultList\"]/li" );

						if ( masterNode != null )
						{
							for ( int i = 1; i <= masterNode.Count; i++ )
							{
								WebtoonSearchResultList data = new WebtoonSearchResultList( );

								HtmlNode aNode = document.DocumentNode.SelectSingleNode( "//ul[@class=\"resultList\"]/li[ " + i + "]/h5/a" );
								HtmlNode authorNode = document.DocumentNode.SelectSingleNode( "//ul[@class=\"resultList\"]/li[ " + i + "]/ul[1]/li[1]/em/a" );
								HtmlNode genreNode = document.DocumentNode.SelectSingleNode( "//ul[@class=\"resultList\"]/li[ " + i + "]/ul[1]/li[2]/em" );
								HtmlNode totalNumNode = document.DocumentNode.SelectSingleNode( "//ul[@class=\"resultList\"]/li[ " + i + "]/ul[1]/li[3]/em" );
								HtmlNode isStoreWebtoonNode = document.DocumentNode.SelectSingleNode( "//ul[@class=\"resultList\"]/li[ " + i + "]/h5/span[@class=\"ico_store\"]" );
								HtmlNode isAdultWebtoonNode = document.DocumentNode.SelectSingleNode( "//ul[@class=\"resultList\"]/li[ " + i + "]/h5/span[@class=\"mark_adult\"]" );

								data.title = aNode.InnerText;
								data.author = authorNode.InnerText;
								data.genre = genreNode.InnerText;
								data.totalNum = int.Parse( totalNumNode.InnerText.Replace( "회", "" ) );
								data.url = "http://comic.naver.com" + aNode.GetAttributeValue( "href", "" );
								data.metaData = new bool[ 2 ]
								{
									isStoreWebtoonNode != null,
									isAdultWebtoonNode != null
								};

								string[ ] detailResult = InternalSearchWebtoonDetailRequest( data.url );

								data.description = detailResult[ 0 ];
								data.thumbnail = detailResult[ 1 ];

								//Console.WriteLine( aNode.InnerText );
								//Console.WriteLine( "http://comic.naver.com" + aNode.GetAttributeValue( "href", "" ) );
								//Console.WriteLine( authorNode.InnerText.Trim( ) );
								//Console.WriteLine( genreNode.InnerText.Trim( ) );
								//Console.WriteLine( totalNumNode.InnerText.Trim( ) );
								//Console.WriteLine( isStoreWebtoonNode != null ? "스토어웹툰" : "스토어 아님" );
								//Console.WriteLine( isAdultWebtoonNode != null ? "19" : "19 X" );

								result.Add( data );
							}
						}

						return result;
					}
				}
			}
			catch ( Exception ex )
			{
				return null;
			}
		}

		public static List<WebtoonSearchResultList> SearchWebtoonByTitle( string title )
		{
			string url = "http://comic.naver.com/search.nhn?m=webtoon&keyword=" + HttpUtility.UrlEncode( title, Encoding.UTF8 ) + "&type=title";
			int maxPage = GetMaxSpecificPageSearchPage( url );

			List<WebtoonSearchResultList> result = new List<WebtoonSearchResultList>( );

			if ( maxPage > 0 )
			{
				for ( int currentPage = 1; currentPage <= maxPage; currentPage++ )
				{
					List<WebtoonSearchResultList> newData = InternalSearchWebtoonRequest( url, currentPage );

					if ( newData != null )
						result = newData.Concat( result ).ToList( );
				}
			}

			return result;
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

						//int currentMaxPage = -1;

						HtmlNodeCollection pageHtmlNodes = document.DocumentNode.SelectNodes( "//em[@class=\"num_page\"]" );

						// legacy codes;
						//foreach ( HtmlNode i in document.DocumentNode.SelectNodes( "//em[@class=\"num_page\"]" ) )
						//{
						//	if ( int.Parse( i.InnerText ) > currentMaxPage )
						//		currentMaxPage = int.Parse( i.InnerText );

						//	//Console.WriteLine( i.InnerText );
						//}

						return int.Parse( pageHtmlNodes[ pageHtmlNodes.Count - 1 ].InnerText );
					}
				}
			}
			catch ( Exception ex )
			{
				Util.WriteErrorLog( ex.Message, Util.LogSeverity.EXCEPTION );
				return -1;
			}
		}

		private static readonly object locker = new object( );
		private static bool DownloadResource( string directURL, string dir )
		{
			lock ( locker )
			{
				WebClient client = new WebClient( )
				{
					Headers = new WebHeaderCollection( )
				};

				client.Headers.Add( HttpRequestHeader.UserAgent, "Mozilla/5.0 (Windows NT 6.1) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/53.0.2785.116 Safari/537.36" );
				client.Headers.Add( HttpRequestHeader.Referer, "http://comic.naver.com" );
				client.Headers.Add( HttpRequestHeader.Accept, "image/webp,image/*,*/*;q=0.8" );

				try
				{
					byte[ ] data = client.DownloadData( directURL );

					File.WriteAllBytes( dir, data );

					//Util.ImageSave( dir, data );

					return true;
					//HttpWebRequest request = ( HttpWebRequest ) WebRequest.Create( directURL );
					//request.Method = "GET";
					//request.KeepAlive = true;
					//request.Referer = "http://comic.naver.com";
					//request.Accept = "image/webp,image/*,*/*;q=0.8";
					//request.UserAgent = "Mozilla/5.0 (Windows NT 6.1) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/53.0.2785.116 Safari/537.36";

					//using ( HttpWebResponse response = ( HttpWebResponse ) request.GetResponse( ) )
					//{
					//	using ( Stream stReadData = response.GetResponseStream( ) )
					//	{
					//		using ( MemoryStream ms = new MemoryStream( ) )
					//		{
					//			stReadData.CopyTo( ms );

					//			File.WriteAllBytes( dir, ms.ToArray( ) );

					//			return true;
					//		}
					//	}
					//}
				}
				catch ( WebException ex )
				{

					return false;
				}
				catch ( IOException ex )
				{

					return false;
				}
				catch ( UnauthorizedAccessException ex )
				{

					return false;
				}
				catch ( Exception ex )
				{

					return false;
				}
				finally
				{
					client.Dispose( );
				}
			}
		}

		private static readonly object locker2 = new object( );
		private static bool DownloadImageResourceCompress( string directURL, string dir, bool compress = false, long quality = 100L )
		{
			lock ( locker2 )
			{
				WebClient client = new WebClient( )
				{
					Headers = new WebHeaderCollection( )
				};

				client.Headers.Add( HttpRequestHeader.UserAgent, "Mozilla/5.0 (Windows NT 6.1) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/53.0.2785.116 Safari/537.36" );
				client.Headers.Add( HttpRequestHeader.Referer, "http://comic.naver.com" );
				client.Headers.Add( HttpRequestHeader.Accept, "image/webp,image/*,*/*;q=0.8" );

				try
				{
					byte[ ] data = client.DownloadData( directURL );

					//Bitmap newImage = Util.ImageCompress( new Bitmap( new MemoryStream( data ) ) );

					//newImage.Save( dir );

					return Util.ImageSave( dir, data, true, ( long ) GlobalVar.QualityOption );
					//File.WriteAllBytes( dir,  );
					//HttpWebRequest request = ( HttpWebRequest ) WebRequest.Create( directURL );
					//request.Method = "GET";
					//request.KeepAlive = true;
					//request.Referer = "http://comic.naver.com";
					//request.Accept = "image/webp,image/*,*/*;q=0.8";
					//request.UserAgent = "Mozilla/5.0 (Windows NT 6.1) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/53.0.2785.116 Safari/537.36";

					//using ( HttpWebResponse response = ( HttpWebResponse ) request.GetResponse( ) )
					//{
					//	using ( Stream stReadData = response.GetResponseStream( ) )
					//	{
					//		using ( MemoryStream ms = new MemoryStream( ) )
					//		{
					//			stReadData.CopyTo( ms );

					//			File.WriteAllBytes( dir, ms.ToArray( ) );

					//			return true;
					//		}
					//	}
					//}
				}
				catch ( WebException ex )
				{

					return false;
				}
				catch ( IOException ex )
				{

					return false;
				}
				catch ( UnauthorizedAccessException ex )
				{

					return false;
				}
				catch ( Exception ex )
				{

					return false;
				}
				finally
				{
					client.Dispose( );
				}
			}
		}

		public static void Download( WebtoonListPageInformations info, string baseDir, Action<string> MessageChangeCallBack, Action<WebtoonListSpecificPageInformations> DownloadPageChanged, Action<float, float> DownloadProgressChanged, Action<bool> WorkFinished, Action<string> ErrorHandler )
		{
			try
			{
				//	GlobalVar.DownloadErrorList = new List<string>( );

				int maxListPage = GetWebtoonListPageMaxPage( info.url );

				if ( maxListPage > 0 )
				{
					info.specificPageInformations = new List<WebtoonListSpecificPageInformations>( );

					int totalDownloadImageCount = 0;
					int currentDownloadImageCount = 0;

					for ( int currentListPage = 1; currentListPage <= maxListPage; currentListPage++ )
					{
						List<WebtoonListSpecificPageInformations> specificPageInformations = GetInternalWebtoonListPageInformations( info.url, currentListPage );

						if ( specificPageInformations != null )
						{
							info.specificPageInformations = info.specificPageInformations.Concat( specificPageInformations ).ToList( );
						}

						foreach ( WebtoonListSpecificPageInformations i in specificPageInformations )
						{
							if ( i.contents == null ) continue;

							totalDownloadImageCount += i.contents.Count;
						}

						MessageChangeCallBack.Invoke( "서버에서 기본적인 정보를 불러오는 중 ... [" + currentListPage + "/" + maxListPage + "] <총 " + totalDownloadImageCount + "개 이미지>" );
					}

					try
					{
						foreach ( WebtoonListSpecificPageInformations i in info.specificPageInformations )
						{
							if ( i.num >= GlobalVar.BeginDownloadDetailNum && i.num <= GlobalVar.EndDownloadDetailNum )
							{
								string path = baseDir + "\\" + ( i.num + " - " + Util.StripFolderName( i.title ) );

								DownloadPageChanged.Invoke( i );
								MessageChangeCallBack.Invoke( i.num + "화 다운로드 중 ..." );

								Directory.CreateDirectory( path );
								Directory.CreateDirectory( path + "\\데이터" );

								if ( !DownloadImageResourceCompress( i.thumbnail, path + @"\데이터\thumanail.jpg" ) )
								{
									ErrorHandler.Invoke( "썸네일 이미지를 다운로드 하지 못했습니다." );
								}
								//if ( !DownloadResource( i.thumbnail, path + @"\데이터\thumanail.jpg" ) )
								//{
								//	ErrorHandler.Invoke( "썸네일 이미지를 다운로드 하지 못했습니다." );
								//}

								if ( GlobalVar.BGMDownloadOption && !string.IsNullOrEmpty( i.bgm ) )
								{
									if ( !DownloadResource( i.bgm, path + @"\데이터\bgm.mp3" ) )
										ErrorHandler.Invoke( "BGM 데이터를 다운로드 하지 못했습니다." );
								}

								//WebtoonDetailPageInformations detail = GetDetailPageInformations( i.url );
								//specificPageData.contents = detail.contents;

								int count = 0;
								foreach ( string i2 in i.contents )
								{
									if ( !DownloadImageResourceCompress( i2, path + @"\데이터\" + ++count + "_image.jpg" ) )
										ErrorHandler.Invoke( "이미지 데이터를 다운로드 하지 못했습니다." );

									DownloadProgressChanged.Invoke( 0, ( float ) ++currentDownloadImageCount / ( float ) totalDownloadImageCount ); //( ( float ) count / ( float ) i.contents.Count ),
									Util.AppliactionDelay( 10 );
								}

								if ( GlobalVar.ViewerCreateOption )
									BrowserViewer.Create(
										info.title + " - " + i.title,
										path,
										i.url,
										count,
										!string.IsNullOrEmpty( i.bgm ),
										null
									);
							}
						}
					}
					catch
					{

					}
					finally
					{
						WorkFinished.Invoke( true );
					}
				}
				else
				{
					WorkFinished.Invoke( false );
				}
			}
			catch ( ThreadAbortException )
			{
				GC.Collect( 0, GCCollectionMode.Forced );
			}
		}

		private static List<WebtoonListSpecificPageInformations> GetInternalWebtoonListPageInformations( string url, int page )
		{
			List<WebtoonListSpecificPageInformations> specificPageInformations = new List<WebtoonListSpecificPageInformations>( );

			url += "&page=" + page;

			HttpWebRequestHelper.GetHttpRequest( url, GlobalVar.DefaultUserAgent, "http://comic.naver.com", null, ( HttpWebRequest request, Stream stream ) =>
			{
				HtmlDocument document = new HtmlDocument( );
				document.Load( stream, Encoding.UTF8 );

				int index = 1;

				while ( true ) // 위험할 수 있음 테스트가 필요함
				{
					HtmlNode checkIsBanner = document.DocumentNode.SelectSingleNode( "//tr[" + index + "]/td" );

					if ( checkIsBanner == null )
					{
						break;
					}

					if ( checkIsBanner != null && checkIsBanner.GetAttributeValue( "colspan", "" ) == "4" )
					{
						//ico_store2



						//http://nstore.naver.com/isService.json?productTypeCode=COMIC&originalProductId=143489
						//http://nstore.naver.com/comic/detail.nhn?originalProductId=

						//HtmlNode storeIconCheck = document.DocumentNode.SelectSingleNode( "//tr[" + index + "]/td/a/em[@class=\"ico_store2\"]" );


						//	System.Windows.Forms.MessageBox.Show( ( storeIconCheck != null ).ToString( ) );
						index++;
						continue;
					}

					WebtoonListSpecificPageInformations specificPageData = new WebtoonListSpecificPageInformations( );

					HtmlNode thumbnailImageNode = document.DocumentNode.SelectSingleNode( "//tr[" + index + "]/td/a/img" );
					HtmlNode thumbnailImageClickerANode = document.DocumentNode.SelectSingleNode( "//tr[" + index + "]/td/a" );

					//HtmlNode starRateNode = document.DocumentNode.SelectSingleNode( "//tr[" + index + "]/td/div[@class=\"rating_type\"]/strong" );
					//HtmlNode uploadDateNode = document.DocumentNode.SelectSingleNode( "//tr[" + index + "]/td[@class=\"num\"]" );
					HtmlNode starRateNode = document.DocumentNode.SelectSingleNode( "//tr[" + index + "]/td/div[@class=\"rating_type\"]/strong" );
					HtmlNode uploadDateNode = document.DocumentNode.SelectSingleNode( "//tr[" + index + "]/td[@class=\"num\"]" );

					HtmlNode bgmAvaliable = document.DocumentNode.SelectSingleNode( "//tr[" + index + "]/td[@class=\"title\"]/span[@class=\"ico_bgm\"]" );

					specificPageData.title = HttpUtility.HtmlDecode( thumbnailImageNode.GetAttributeValue( "title", "" ) );
					specificPageData.thumbnail = thumbnailImageNode.GetAttributeValue( "src", "" );
					specificPageData.starRate = double.Parse( starRateNode.InnerText );
					specificPageData.uploadDate = uploadDateNode.InnerText;
					specificPageData.url = "http://comic.naver.com" + thumbnailImageClickerANode.GetAttributeValue( "href", "" );
					specificPageData.num = int.Parse( HttpUtility.ParseQueryString( ( new Uri( specificPageData.url ) ).Query ).Get( "no" ) );
					specificPageData.contents = GetDetailPageImageContentsOnly( specificPageData.url );

					if ( bgmAvaliable != null )
						specificPageData.bgm = GetPageBGMUrl( specificPageData.url );
					else
						specificPageData.bgm = "";

					specificPageInformations.Add( specificPageData );

					index++;

					Thread.Sleep( 30 );
				}
			} );

			return specificPageInformations;
		}

		public static int GetWebtoonListCount( string url )
		{
			// 새로운 방식으로 변경 (맨 첫번째 페이지의 맨 위의 화의 숫자만 가져옴
			int latestWebtoonCount = -1;

			try
			{
				url += "&page=1";

				HttpWebRequest request = ( HttpWebRequest ) WebRequest.Create( url );
				request.Method = "GET";
				request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/57.0.2987.133 Safari/537.36";

				using ( HttpWebResponse response = ( HttpWebResponse ) request.GetResponse( ) )
				{
					using ( Stream responseStream = response.GetResponseStream( ) )
					{
						HtmlDocument document = new HtmlDocument( );
						document.Load( responseStream, Encoding.UTF8 );

						int index = 1;

						while ( true )
						{
							HtmlNode checkIsBanner = document.DocumentNode.SelectSingleNode( "//tr[" + index + "]/td" );

							if ( checkIsBanner == null )
							{
								break;
							}

							if ( checkIsBanner != null && checkIsBanner.GetAttributeValue( "colspan", "" ) == "4" ) // 스토어 또는 게임 웹툰 배너 node
							{
								index++;
								continue;
							}

							HtmlNode aNode = document.DocumentNode.SelectSingleNode( "//tr[" + index + "]/td[@class=\"title\"]/a" );

							if ( aNode != null )
							{
								Uri newURI = new Uri( "http://comic.naver.com" + aNode.GetAttributeValue( "href", "" ) );

								System.Collections.Specialized.NameValueCollection query = HttpUtility.ParseQueryString( newURI.Query );

								if ( !string.IsNullOrEmpty( query.Get( "no" ) ) )
								{
									latestWebtoonCount = int.Parse( query.Get( "no" ) );
									break;
								}
							}
						}

						return latestWebtoonCount;
					}
				}
			}
			catch ( Exception ex )
			{
				Util.WriteErrorLog( ex );

				return latestWebtoonCount;
			}

			//int count = 0;
			//int maxListPage = GetWebtoonListPageMaxPage( url );

			//if ( maxListPage > 0 )
			//{
			//	for ( int currentListPage = 1; currentListPage <= maxListPage; currentListPage++ )
			//	{
			//		string internalURL = url + "&page=" + currentListPage;

			//		HttpWebRequestHelper.GetHttpRequest( internalURL, GlobalVar.DefaultUserAgent, "http://comic.naver.com", null, ( HttpWebRequest request, Stream stream ) =>
			//		{
			//			HtmlDocument document = new HtmlDocument( );
			//			document.Load( stream, Encoding.UTF8 );

			//			int index = 1;

			//			while ( true )
			//			{
			//				HtmlNode checkIsBanner = document.DocumentNode.SelectSingleNode( "//tr[" + index + "]/td" );

			//				if ( checkIsBanner == null )
			//				{
			//					break;
			//				}

			//				if ( checkIsBanner != null && checkIsBanner.GetAttributeValue( "colspan", "" ) == "4" )
			//				{
			//					index++;
			//					continue;
			//				}

			//				count++;
			//				index++;
			//			}
			//		} );
			//	}
			//}

			//return count;
		}

		public static WebtoonDetailPageInformations? GetSpecificWebtoonDetailPageInformations( string url, int num )
		{
			try
			{
				url += "&no=" + num;

				HttpWebRequest request = ( HttpWebRequest ) WebRequest.Create( url );
				request.Method = "GET";
				request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/57.0.2987.133 Safari/537.36";

				using ( HttpWebResponse response = ( HttpWebResponse ) request.GetResponse( ) )
				{
					using ( Stream responseStream = response.GetResponseStream( ) )
					{
						HtmlDocument document = new HtmlDocument( );
						document.Load( responseStream, Encoding.UTF8 );

						WebtoonDetailPageInformations data = new WebtoonDetailPageInformations( );

						foreach ( HtmlNode i in document.DocumentNode.SelectNodes( "//meta" ) )
						{
							switch ( i.GetAttributeValue( "property", "" ) )
							{
								case "og:description":
									data.title = HttpUtility.HtmlDecode( i.GetAttributeValue( "content", "" ) );
									break;
								case "og:image":
									data.thumbnail = i.GetAttributeValue( "content", "" );
									break;
							}
						}

						return data;
					}
				}
			}
			catch ( Exception ex )
			{
				Util.WriteErrorLog( ex.Message, Util.LogSeverity.EXCEPTION );
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
								case "og:description": // 수정 필요
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
					}
				}
			}
			catch ( Exception ex )
			{
				Util.WriteErrorLog( ex.Message, Util.LogSeverity.EXCEPTION );
				return null;
			}
		}

		public static List<string> GetDetailPageImageContentsOnly( string url )
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

						HtmlNode webtoonDetailContentImagesDIV = document.DocumentNode.SelectSingleNode( "//div[@class=\"wt_viewer\"]" ); // 웹툰 이미지 콘텐츠 찾기 -> contents
						List<string> data = new List<string>( );

						if ( webtoonDetailContentImagesDIV != null )
						{
							foreach ( HtmlNode i in webtoonDetailContentImagesDIV.ChildNodes )
							{
								if ( i.Name == "img" )
									data.Add( i.GetAttributeValue( "src", "" ) );
							}
						}

						return data;
					}
				}
			}
			catch ( Exception ex )
			{
				Util.WriteErrorLog( ex.Message, Util.LogSeverity.EXCEPTION );
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
						HtmlDocument document = new HtmlDocument( );
						document.Load( responseStream, Encoding.UTF8 );

						WebtoonDetailPageInformations dataStruct = new WebtoonDetailPageInformations( );

						HtmlNode webtoonDetailPageTitle = document.DocumentNode.SelectSingleNode( "//meta[@property=\"og:title\"]" ); // 웹툰 화 제목 찾기 -> title
						HtmlNode webtoonDetailPageThumbnail = document.DocumentNode.SelectSingleNode( "//meta[@property=\"og:image\"]" ); // 웹툰 썸네일 찾기 -> thumbnail
						HtmlNode webtoonDetailContentImagesDIV = document.DocumentNode.SelectSingleNode( "//div[@class=\"wt_viewer\"]" ); // 웹툰 이미지 콘텐츠 찾기 -> contents
						HtmlNode webtoonCommentByAuthorDIV = document.DocumentNode.SelectSingleNode( "//div[@class=\"writer_info\"]" ); // 작가의 말 찾기 -> commentByAuthor

						if ( webtoonDetailPageTitle != null )
						{
							dataStruct.title = webtoonDetailPageTitle.GetAttributeValue( "content", "" ).Trim( );
						}

						if ( webtoonDetailPageThumbnail != null )
						{
							dataStruct.thumbnail = webtoonDetailPageThumbnail.GetAttributeValue( "content", "" ).Trim( );
						}

						if ( webtoonDetailContentImagesDIV != null )
						{
							dataStruct.contents = new List<string>( );

							foreach ( HtmlNode i in webtoonDetailContentImagesDIV.ChildNodes )
							{
								if ( i.Name == "img" )
									dataStruct.contents.Add( i.GetAttributeValue( "src", "" ) );
							}
						}

						if ( webtoonCommentByAuthorDIV != null )
						{
							foreach ( HtmlNode i in webtoonCommentByAuthorDIV.ChildNodes )
							{
								if ( i.Name == "p" )
								{
									dataStruct.commentByAuthor = i.InnerText.Trim( );
									break;
								}
							}
						}

						return dataStruct;
					}
				}
			}
			catch ( Exception ex )
			{
				Util.WriteErrorLog( ex.Message, Util.LogSeverity.EXCEPTION );
				return new WebtoonDetailPageInformations( );
			}
		}
	}
}
