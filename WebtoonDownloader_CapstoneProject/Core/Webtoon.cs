using System;
using System.Collections.Generic;
using System.Collections.Specialized;
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
			public string title; // 제목
			public string description; // 설명
			public string thumbnail; // 썸네일
			public string author; // 작가
			public string genre; // 장르
			public int totalNum; // 전체 화의 수
			public string url; // 주소
			public bool[ ] metaData; // 메타 데이터 : [0] -> 스토어 웹툰 여부, [1] -> 미성년자 관람 불가 웹툰 여부
		}

		// 올바른 웹툰 주소인지 확인하는 메소드
		public static bool IsValidWebtoonListURL( ref string url )
		{
			try
			{
				Uri newURI = new Uri( url );
				NameValueCollection query = HttpUtility.ParseQueryString( newURI.Query );

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

		// 검색 결과 페이지의 끝 페이지의 수를 가져오는 메소드
		private static int GetMaxSpecificPageSearchPage( string url )
		{
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

		// 웹툰 검색용 내부 메소드
		private static string[ ] InternalSearchWebtoonDetailRequest( string url )
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

		// 웹툰 검색용 내부 메소드
		private static List<WebtoonSearchResultList> InternalSearchWebtoonRequest( string url, int page )
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

								HtmlNode aNode = document.DocumentNode.SelectSingleNode( "//ul[@class=\"resultList\"]/li[ " + i + "]/h5/a" ); // a 노드
								HtmlNode authorNode = document.DocumentNode.SelectSingleNode( "//ul[@class=\"resultList\"]/li[ " + i + "]/ul[1]/li[1]/em/a" ); // 작가 노드
								HtmlNode genreNode = document.DocumentNode.SelectSingleNode( "//ul[@class=\"resultList\"]/li[ " + i + "]/ul[1]/li[2]/em" ); // 장르 노드
								HtmlNode totalNumNode = document.DocumentNode.SelectSingleNode( "//ul[@class=\"resultList\"]/li[ " + i + "]/ul[1]/li[3]/em" ); // 전체 화 수를 가져오는 노드
								HtmlNode isStoreWebtoonNode = document.DocumentNode.SelectSingleNode( "//ul[@class=\"resultList\"]/li[ " + i + "]/h5/span[@class=\"ico_store\"]" ); // 스토어 웹툰 여부
								HtmlNode isAdultWebtoonNode = document.DocumentNode.SelectSingleNode( "//ul[@class=\"resultList\"]/li[ " + i + "]/h5/span[@class=\"mark_adult\"]" ); // 미성년자 관람 불가 웹툰 여부

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

		// 웹툰 이름으로 검색하는 메소드
		public static List<WebtoonSearchResultList> SearchWebtoonByTitle( string title )
		{
			string url = "http://comic.naver.com/search.nhn?m=webtoon&keyword=" + HttpUtility.UrlEncode( title, Encoding.UTF8 ) + "&type=title";
			int maxPage = GetMaxSpecificPageSearchPage( url ); // 전체 페이지를 가져온 다음 ...

			List<WebtoonSearchResultList> result = new List<WebtoonSearchResultList>( );

			if ( maxPage > 0 )
			{
				for ( int currentPage = 1; currentPage <= maxPage; currentPage++ ) // 1 페이지부터 끝 페이지까지 검색 결과를 전부 가져와서 파싱한다
				{
					List<WebtoonSearchResultList> newData = InternalSearchWebtoonRequest( url, currentPage );

					if ( newData != null )
						result = newData.Concat( result ).ToList( ); // 데이터 있으면 붙임
				}
			}

			return result;
		}

		// 웹툰 페이지의 BGM URL 을 가져오는 메소드
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

							if ( html.Contains( "showMusicPlayer(\"" ) ) // JavaScript 함수 검사
							{
								int startIndex = html.IndexOf( "showMusicPlayer(\"" ) + 17;

								return html.Substring(
									startIndex,
									html.IndexOf( "\");", startIndex ) - startIndex
								);
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

		// 웹툰 리스트 페이지의 끝 페이지의 수를 가져오는 메소드
		private static int GetWebtoonListPageMaxPage( string url )
		{
			try
			{
				url += "&page=999999999"; // URL Query String 뒤에 page=999999999 를 붙이면 네이버에서 자동으로 끝 페이지로 이동함

				HttpWebRequest request = ( HttpWebRequest ) WebRequest.Create( url );
				request.Method = "GET";
				request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/57.0.2987.133 Safari/537.36";

				using ( HttpWebResponse response = ( HttpWebResponse ) request.GetResponse( ) )
				{
					using ( Stream responseStream = response.GetResponseStream( ) )
					{
						HtmlDocument document = new HtmlDocument( );
						document.Load( responseStream, Encoding.UTF8 );

						HtmlNodeCollection pageHtmlNodes = document.DocumentNode.SelectNodes( "//em[@class=\"num_page\"]" );

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

		// 리소스를 다운로드해서 해당 지점에 저장하는 메소드
		private static readonly object locker = new object( );
		private static bool DownloadResource( string directURL, string dir )
		{
			lock ( locker ) // 쓰레드가 중첩 접근하지 않도록 락
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

					return true;
				}
				//catch ( WebException ex )
				//{

				//	return false;
				//}
				//catch ( IOException ex )
				//{

				//	return false;
				//}
				//catch ( UnauthorizedAccessException ex )
				//{

				//	return false;
				//}
				catch ( Exception ex )
				{
					Util.WriteErrorLog( ex );
					return false;
				}
				finally
				{
					client.Dispose( );
				}
			}
		}

		// 이미지를 다운로드해서 받은 설정으로 압축한 후 해당 지점에 저장하는 메소드
		private static readonly object locker2 = new object( );
		private static bool DownloadImageResourceCompress( string directURL, string dir, bool compress = false, long quality = 100L )
		{
			lock ( locker2 ) // 쓰레드가 중첩 접근하지 않도록 락
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

					return Util.ImageSave( dir, data, true, ( long ) GlobalVar.QualityOption );
				}
				//catch ( WebException ex )
				//{

				//	return false;
				//}
				//catch ( IOException ex )
				//{

				//	return false;
				//}
				//catch ( UnauthorizedAccessException ex )
				//{

				//	return false;
				//}
				catch ( Exception ex )
				{
					Util.WriteErrorLog( ex );
					return false;
				}
				finally
				{
					client.Dispose( );
				}
			}
		}

		// 웹툰을 다운로드 할 때 호출하는 메소드
		// <!> 위의 메소드들은 전부 이 메소드 안에서 호출됨
		public static void Download( WebtoonListPageInformations info, string baseDir, Action<string> MessageChangeCallBack, Action<WebtoonListSpecificPageInformations> DownloadPageChanged, Action<float, float> DownloadProgressChanged, Action<bool> WorkFinished, Action<string> ErrorHandler )
		{
			try
			{
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
						if ( GlobalVar.DownloadSections == null ) // 다운로드 구간 세부 설정이 없으면?
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

									if ( GlobalVar.BGMDownloadOption && !string.IsNullOrEmpty( i.bgm ) )
									{
										if ( !DownloadResource( i.bgm, path + @"\데이터\bgm.mp3" ) )
											ErrorHandler.Invoke( "BGM 데이터를 다운로드 하지 못했습니다." );
									}

									int count = 0;
									foreach ( string i2 in i.contents )
									{
										if ( !DownloadImageResourceCompress( i2, path + @"\데이터\" + ++count + "_image.jpg" ) )
											ErrorHandler.Invoke( "이미지 데이터를 다운로드 하지 못했습니다." );

										DownloadProgressChanged.Invoke( 0, ( float ) ++currentDownloadImageCount / ( float ) totalDownloadImageCount ); //( ( float ) count / ( float ) i.contents.Count ),
										Util.AppliactionDelay( 10 );
									}

									if ( GlobalVar.ViewerCreateOption ) // HTML 뷰어 생성
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
						else
						{
							foreach ( WebtoonListSpecificPageInformations i in info.specificPageInformations )
							{
								if ( GlobalVar.DownloadSections.IndexOf( i.num ) > -1 )
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

									if ( GlobalVar.BGMDownloadOption && !string.IsNullOrEmpty( i.bgm ) )
									{
										if ( !DownloadResource( i.bgm, path + @"\데이터\bgm.mp3" ) )
											ErrorHandler.Invoke( "BGM 데이터를 다운로드 하지 못했습니다." );
									}

									int count = 0;
									foreach ( string i2 in i.contents )
									{
										if ( !DownloadImageResourceCompress( i2, path + @"\데이터\" + ++count + "_image.jpg" ) )
											ErrorHandler.Invoke( "이미지 데이터를 다운로드 하지 못했습니다." );

										DownloadProgressChanged.Invoke( 0, ( float ) ++currentDownloadImageCount / ( float ) totalDownloadImageCount ); //( ( float ) count / ( float ) i.contents.Count ),
										Util.AppliactionDelay( 10 );
									}

									if ( GlobalVar.ViewerCreateOption ) // HTML 뷰어 생성
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
					}
					catch ( Exception ex )
					{
						Util.WriteErrorLog( ex );
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
				GC.Collect( 0, GCCollectionMode.Forced ); // 다운로드가 종료된 후 남은 리소스를 정리하기 위해 GC 강제 실행
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
					HtmlNode checkIsBanner = document.DocumentNode.SelectSingleNode( "//tr[" + index + "]/td" ); // 리스트가 없으면 전체를 탐색한 것

					if ( checkIsBanner == null )
					{
						break;
					}

					if ( checkIsBanner != null && checkIsBanner.GetAttributeValue( "colspan", "" ) == "4" ) // 게임 웹툰 또는 스토어 웹툰 배너 체크
					{
						index++;
						continue;
					}

					WebtoonListSpecificPageInformations specificPageData = new WebtoonListSpecificPageInformations( );

					HtmlNode thumbnailImageNode = document.DocumentNode.SelectSingleNode( "//tr[" + index + "]/td/a/img" ); // 썸네일 노드
					HtmlNode thumbnailImageClickerANode = document.DocumentNode.SelectSingleNode( "//tr[" + index + "]/td/a" ); // 썸네일 a 노드
					HtmlNode starRateNode = document.DocumentNode.SelectSingleNode( "//tr[" + index + "]/td/div[@class=\"rating_type\"]/strong" ); // 별점 노드
					HtmlNode uploadDateNode = document.DocumentNode.SelectSingleNode( "//tr[" + index + "]/td[@class=\"num\"]" ); // 업로드 일 노드
					HtmlNode bgmAvaliable = document.DocumentNode.SelectSingleNode( "//tr[" + index + "]/td[@class=\"title\"]/span[@class=\"ico_bgm\"]" ); // BGM 있음?

					specificPageData.title = HttpUtility.HtmlDecode( thumbnailImageNode.GetAttributeValue( "title", "" ) );
					specificPageData.thumbnail = thumbnailImageNode.GetAttributeValue( "src", "" );
					specificPageData.starRate = double.Parse( starRateNode.InnerText );
					specificPageData.uploadDate = uploadDateNode.InnerText;
					specificPageData.url = "http://comic.naver.com" + thumbnailImageClickerANode.GetAttributeValue( "href", "" );
					specificPageData.num = int.Parse( HttpUtility.ParseQueryString( ( new Uri( specificPageData.url ) ).Query ).Get( "no" ) );
					specificPageData.contents = GetDetailPageImageContentsOnly( specificPageData.url );

					if ( bgmAvaliable != null ) // BGM 있으면 BGM 주소 가져옴
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

		// 웹툰의 전체 화의 수를 가져오는 메소드
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

							if ( checkIsBanner == null ) // 배너가 있으면 현재 페이지 루프를 다 돌았음
								break;

							if ( checkIsBanner != null && checkIsBanner.GetAttributeValue( "colspan", "" ) == "4" ) // 스토어 또는 게임 웹툰 배너 node
							{
								index++;
								continue;
							}

							HtmlNode aNode = document.DocumentNode.SelectSingleNode( "//tr[" + index + "]/td[@class=\"title\"]/a" );

							if ( aNode != null )
							{
								Uri newURI = new Uri( "http://comic.naver.com" + aNode.GetAttributeValue( "href", "" ) );

								NameValueCollection query = HttpUtility.ParseQueryString( newURI.Query );

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

		// 특정 웹툰의 상세보기 페이지의 정보를 가져오는 메소드
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
								case "og:description": // 자세히 보기 페이지에서는 description 노드가 title 이 됨
									data.title = HttpUtility.HtmlDecode( i.GetAttributeValue( "content", "" ) );
									break;
								case "og:image": // 썸네일
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

		// 웹툰 리스트 페이지의 글로벌 정보를 가져오는 메소드
		// ex : http://comic.naver.com/webtoon/list.nhn?titleId=570503&weekday=thu
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
								case "og:title": // 웹툰 이름
									data.title = HttpUtility.HtmlDecode( i.GetAttributeValue( "content", "" ) );
									break;
								case "og:description": // 수정 필요
									data.description = HttpUtility.HtmlDecode( i.GetAttributeValue( "content", "" ) );
									break;
								case "og:image": // 웹툰 썸네일
									data.thumbnail = i.GetAttributeValue( "content", "" );
									break;
							}
						}

						HtmlNode webtoonAuthorLabel = document.DocumentNode.SelectSingleNode( "//span[@class=\"wrt_nm\"]" ); // 웹툰 작가 이름 찾기 -> author

						data.author = webtoonAuthorLabel.InnerText.Trim( );
						data.url = url;

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

		// 웹툰 자세히 보기 페이지에서 이미지만(만화 이미지) 가져오는 메소드
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

		// 왜 만들었지;
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
