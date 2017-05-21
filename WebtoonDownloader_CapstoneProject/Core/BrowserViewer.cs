using System;
using System.IO;
using System.Text;

namespace WebtoonDownloader_CapstoneProject.Core
{
	static class BrowserViewer
	{
		private static readonly string HtmlBase = @"<!DOCTYPE html>
<html lang='ko'>
<head>
    <meta charset='utf-8'>
    <meta http-equiv='Content-Type' content='text/html; charset=utf-8' />
	<meta http-equiv='X-UA-Compatible' content='IE=edge'>
    <meta name='viewport' content='width=device-width, initial-scale=1'>
    <title>&title</title>
    <meta property='og:title' content='&title'>
    <link rel='shortcut icon' type='image/x-icon' href='http://www.naver.com/favicon.ico' />
    <link rel='icon' type='image/x-icon' href='http://www.naver.com/favicon.ico' />
	
    <link rel='stylesheet' href='https://maxcdn.bootstrapcdn.com/bootstrap/3.3.2/css/bootstrap.min.css'>
	<link rel='stylesheet' href='https://maxcdn.bootstrapcdn.com/bootstrap/3.3.2/css/bootstrap-theme.min.css'>
	
    <script type='text/javascript' src='https://ajax.googleapis.com/ajax/libs/jquery/1.12.4/jquery.min.js'></script>
    <script type='text/javascript' src='https://maxcdn.bootstrapcdn.com/bootstrap/3.3.2/js/bootstrap.min.js'></script>
	
    <style type='text/css'>
        @import url( 'http://fonts.googleapis.com/earlyaccess/nanumgothic.css' );

        body, table, div, p
		{
			font-family:  'Nanum Gothic', 'Malgun Gothic', '맑은 고딕', 'Arial';
			display: none;
		}

        #webtoonDownloader-content {
			width: 100% - 10px;
			padding: 20px;
			margin-bottom: 20px;
			float: center;
		}

        #webtoonDownloader-container {
			width: 940px;
			margin: 20px auto;
			padding: 10px;
			padding-top: 0px;
			border: 1px solid #ddd;
			border-radius: 4px;
			overflow: auto;
			clear: both;
		}
		
		#webtoonDownloader-thumbnail
		{
			position: absolute;
			right: 1px;
			top: -10px;
		}
		
		#header {
			padding: 20px;
			margin-left: auto;
			margin-right: auto;
			margin-top: 20px;
			position: relative;
			height: 120px;
			clear: both;
		}
		
		img
		{
			display: block;
			margin-left: auto;
			margin-right: auto;
		}
	</style>
    <script type='text/javascript'>
		var audioVolumeControlID;
		var currentAudioVolume = 0;
		var urlOriginal = '&url';

		$( document ).ready(function() {
			document.getElementById( 'bgmToggleButton' ).style.visibility = 'hidden';

			document.getElementById( 'topViewButton' ).onclick = function( )
			{
				$( 'html, body' ).animate( {
					scrollTop: 0
				}, 1000 );
			}
			
			document.getElementById( 'originalViewButton' ).onclick = function( )
			{
				location.href = urlOriginal;
			}
			
			document.getElementById( 'bgmToggleButton' ).onclick = function( )
			{
				toggleAudio( );
			}
			
			$( 'body' ).fadeIn( 1000 );
			$( 'div' ).fadeIn( 1000 );

			window.setTimeout( function( ) { $( '#warning-alert' ).alert( 'close' ); }, 8000 );
			
			var audio = document.getElementById( 'audioControl' );
			
			if ( audio != undefined )
			{
				audio.volume = 0;
				audio.loop = true;
				audio.play( );
				currentAudioVolume = 0;
				audioVolumeControlID = setInterval( 'fadeInAudio( )', 10 );
				document.getElementById( 'bgmToggleButton' ).style.visibility = 'visible';
				$( '#bgmToggleButton' ).text( 'BGM 정지' );
			}
		} );
		
		function toggleAudio( )
		{
			var audio = document.getElementById( 'audioControl' );
			
			if ( audio != undefined )
			{
				if ( audio.paused && audio.currentTime > 0 && !audio.ended )
				{
					currentAudioVolume = 0;
					audioVolumeControlID = setInterval( 'fadeInAudio( )', 10 );
					audio.play( );
					audio.currentTime = 0;
					
					$( '#bgmToggleButton' ).text( 'BGM 정지' );
				}
				else
				{
					audioVolumeControlID = setInterval( 'fadeOutAudio( )', 10 );
					
					$( '#bgmToggleButton' ).text( 'BGM 재생' );
				}
			}
		}

		function fadeInAudio( )
		{
			if ( currentAudioVolume >= 1 )
			{
				clearInterval( audioVolumeControlID );
				return;
			}
			
			var audio = document.getElementById( 'audioControl' );
			currentAudioVolume += 0.01;
			audio.volume = Math.min( currentAudioVolume, 1 );
		}
		
		function fadeOutAudio( )
		{
			if ( currentAudioVolume <= 0 )
			{
				var audio = document.getElementById( 'audioControl' );
				audio.pause( );
				
				clearInterval( audioVolumeControlID );
				return;
			}
			
			var audio = document.getElementById( 'audioControl' );

			currentAudioVolume -= 0.01;
			audio.volume = Math.max( currentAudioVolume, 0 );
		}
    </script>
</head>
<body>
    <div class='panel panel-default' id='webtoonDownloader-container'>
		<div class='page-header' id='header'>
			<img src='&thumbnail' id='webtoonDownloader-thumbnail' />
			<h3>웹툰 다운로더 <small>&title</small></h3>
		</div>
        <div class='alert alert-warning alert-dismissible fade in' style='display: none;' id='warning-alert'>
			<a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a>
			<strong>경고!</strong> 웹툰 뷰어는 로컬 디스크의 리소스를 불러옵니다, 데이터 폴더를 지우지 마십시오.
		</div>
        <div class='panel panel-default' id='webtoonDownloader-content'>
            <div class='panel-body'>
			&bgmPlayer
			<button type='button' style='margin:auto; display:block; margin-bottom: 10px;' id='bgmToggleButton' class='btn btn-info navbar-btn'>BGM 재생</button>
				&imageContent
				<button type='button' style='float: right;' id='topViewButton' class='btn btn-default navbar-btn'>위로가기</button>
				<button type='button' style='margin-right: 10px; float: right;' id='originalViewButton' class='btn btn-default navbar-btn'>원본 웹툰 보기</button>
				<small style='float: left;'>웹툰 다운로더에 의해 생성되었습니다.<br><strong>Copyright © '4조 Inventive' 2017</strong></small>
            </div>
        </div>
    </div>
</body>
</html>";

		public static bool Create( string title, string baseDir, string url, int maxImageCount, bool bgmAvaliable, Action<string> ExceptionCallback )
		{
			try
			{
				StringBuilder sb = new StringBuilder( HtmlBase );

				sb.Replace( "&title", title );
				sb.Replace( "&url", url );
				sb.Replace( "&thumbnail", "데이터/thumanail.jpg" );

				if ( bgmAvaliable )
				{
					sb.Replace( "&bgmPlayer", @"<audio id='audioControl'>
						<source src='데이터/bgm.mp3' type='audio/mpeg'>
						귀하의 웹 브라우저는 BGM 사운드를 지원하지 않습니다.
						</audio>"
					);
				}
				else
					sb.Replace( "&bgmPlayer", "" );

				StringBuilder contentSB = new StringBuilder( );

				for ( int i = 1; i <= maxImageCount; i++ )
				{
					contentSB.AppendLine( "<img src='데이터/" + i + "_image.jpg' alt='웹툰 이미지' />" );
				}

				sb.Replace( "&imageContent", contentSB.ToString( ) );

				File.WriteAllText( baseDir + "\\웹툰 뷰어.html", sb.ToString( ), Encoding.UTF8 );
				return true;
			}
			catch ( IOException ex )
			{

				ExceptionCallback.Invoke( "IOException:" + ex.Message + " - " + ex.StackTrace );

				return false;
			}
			catch ( UnauthorizedAccessException ex )
			{
				ExceptionCallback.Invoke( "UnauthorizedAccessException:" + ex.Message + " - " + ex.StackTrace );

				return false;
			}
			catch ( Exception ex )
			{
				ExceptionCallback.Invoke( ex.Message + " - " + ex.StackTrace );

				return false;
			}
		}
	}
}
