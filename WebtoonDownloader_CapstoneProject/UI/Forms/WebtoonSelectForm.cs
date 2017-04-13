using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebtoonDownloader_CapstoneProject.Core;

namespace WebtoonDownloader_CapstoneProject.UI.Forms
{
	public partial class WebtoonSelectForm : Form
	{
		private Pen lineDrawer = new Pen( GlobalVar.ThemeColor );

		public enum UIMode
		{
			NotSelected,
			QuestionIsRight,
			Selected,
			LoadingInformation
		}
		private UIMode UIModeVar_private;
		private UIMode UIModeVar
		{
			get
			{
				return UIModeVar_private;
			}
			set
			{
				UIModeVar_private = value;

				if ( this.InvokeRequired )
				{
					this.Invoke( new Action( ( ) =>
					{
						switch ( value )
						{
							case UIMode.NotSelected: // 선택되지 않은 환경
								this.SELECT_CANCEL_BUTTON.Visible = false;
								this.SELECTED_WEBTOON_INFORMATION_PANEL_TITLE.Visible = false;
								this.SELECTED_WEBTOON_INFORMATION_PANEL.Visible = false;

								this.NAME_TEXTBOX_TITLE.Visible = true;
								this.NAME_TEXTBOX.Visible = true;
								this.URL_TEXTBOX_TITLE.Visible = true;
								this.URL_TEXTBOX.Visible = true;
								this.URL_TEXTBOX.Enabled = true;
								this.URL_TEXTBOX.Clear( );

								this.SEARCH_BUTTON.Enabled = true;
								this.SEARCH_BUTTON.Text = "검색 & 선택";
								break;
							case UIMode.LoadingInformation:
								this.URL_TEXTBOX.Enabled = false;
								this.SEARCH_BUTTON.Enabled = false;
								this.SEARCH_BUTTON.Text = "잠시만 기다리세요 ...";
								break;
							case UIMode.QuestionIsRight:
								this.NAME_TEXTBOX_TITLE.Visible = false;
								this.NAME_TEXTBOX.Visible = false;
								this.URL_TEXTBOX_TITLE.Visible = false;
								this.URL_TEXTBOX.Visible = false;

								this.SEARCH_BUTTON.Enabled = true;
								this.SEARCH_BUTTON.Text = "맞습니다!";

								this.SELECT_CANCEL_BUTTON.Visible = true;
								this.SELECTED_WEBTOON_INFORMATION_PANEL_TITLE.Visible = true;
								this.SELECTED_WEBTOON_INFORMATION_PANEL.Visible = true;
								break;
						}
					} ) );
				}
				else
				{
					switch ( value )
					{
						case UIMode.NotSelected: // 선택되지 않은 환경
							this.SELECT_CANCEL_BUTTON.Visible = false;
							this.SELECTED_WEBTOON_INFORMATION_PANEL_TITLE.Visible = false;
							this.SELECTED_WEBTOON_INFORMATION_PANEL.Visible = false;

							this.NAME_TEXTBOX_TITLE.Visible = true;
							this.NAME_TEXTBOX.Visible = true;
							this.URL_TEXTBOX_TITLE.Visible = true;
							this.URL_TEXTBOX.Visible = true;
							this.URL_TEXTBOX.Enabled = true;
							this.URL_TEXTBOX.Clear( );

							this.SEARCH_BUTTON.Enabled = true;
							this.SEARCH_BUTTON.Text = "검색 & 선택";
							break;
						case UIMode.LoadingInformation:
							this.URL_TEXTBOX.Enabled = false;
							this.SEARCH_BUTTON.Enabled = false;
							this.SEARCH_BUTTON.Text = "잠시만 기다리세요 ...";
							break;
						case UIMode.QuestionIsRight:
							this.NAME_TEXTBOX_TITLE.Visible = false;
							this.NAME_TEXTBOX.Visible = false;
							this.URL_TEXTBOX_TITLE.Visible = false;
							this.URL_TEXTBOX.Visible = false;

							this.SEARCH_BUTTON.Enabled = true;
							this.SEARCH_BUTTON.Text = "맞습니다!";

							this.SELECT_CANCEL_BUTTON.Visible = true;
							this.SELECTED_WEBTOON_INFORMATION_PANEL_TITLE.Visible = true;
							this.SELECTED_WEBTOON_INFORMATION_PANEL.Visible = true;
							break;
					}
				}
			}
		}
		private NaverWebtoon.WebtoonListPageInformations? SelectedInformationBuffer;

		public WebtoonSelectForm( )
		{
			InitializeComponent( );

			this.SetStyle( ControlStyles.OptimizedDoubleBuffer, true );
			this.SetStyle( ControlStyles.ResizeRedraw, true );
			this.Opacity = 0;

			this.UIModeVar = UIMode.NotSelected;
		}

		private void WebtoonSelectForm_Load( object sender, EventArgs e )
		{
			Animation.UI.FadeIn( this );
		}

		private void SEARCH_BUTTON_Click( object sender, EventArgs e )
		{
			if ( UIModeVar == UIMode.QuestionIsRight )
			{
				GlobalVar.GlobalListPageInformations = this.SelectedInformationBuffer;
				this.Close( );
			}
			else
			{
				string url = this.URL_TEXTBOX.Text;

				if ( url.Length <= 0 )
				{
					NotifyBox.Show( this, "오류", "Error", "다운로드 할 웹툰의 주소를 입력하세요.", NotifyBox.NotifyBoxType.OK, NotifyBox.NotifyBoxIcon.Error );
					return;
				}

				if ( NaverWebtoon.IsValidWebtoonListURL( ref url ) )
				{
					this.UIModeVar = UIMode.LoadingInformation;

					Thread thread = new Thread( ( ) =>
					{
						NaverWebtoon.WebtoonListPageInformations? informations = NaverWebtoon.GetWebtoonListPageInformations( url );

						if ( informations.HasValue )
						{
							this.SelectedInformationBuffer = informations.Value;

							this.UIModeVar = UIMode.QuestionIsRight;
							this.SELECTED_WEBTOON_INFORMATION_PANEL.SetData( this.SelectedInformationBuffer.Value );
						//MessageBox.Show( informations.Value.title + Environment.NewLine + informations.Value.description );
					}
						else
						{
							NotifyBox.Show( this, "오류", "Error", "죄송합니다, 해당 웹툰의 정보를 가져올 수 없었습니다.", NotifyBox.NotifyBoxType.OK, NotifyBox.NotifyBoxIcon.Error );
						}
					} )
					{
						IsBackground = true
					};

					thread.Start( );
				}
				else
				{
					NotifyBox.Show( this, "오류", "Error", "올바른 웹툰의 주소를 입력하세요.", NotifyBox.NotifyBoxType.OK, NotifyBox.NotifyBoxIcon.Error );
				}
			}
		}

		private void WebtoonSelectForm_Paint( object sender, PaintEventArgs e )
		{
			int w = this.Width, h = this.Height;

			e.Graphics.DrawLine( lineDrawer, 0, 0, w, 0 ); // 위
			e.Graphics.DrawLine( lineDrawer, 0, 0, 0, h ); // 왼쪽
			e.Graphics.DrawLine( lineDrawer, w - lineDrawer.Width, 0, w - lineDrawer.Width, h ); // 오른쪽
			e.Graphics.DrawLine( lineDrawer, 0, h - lineDrawer.Width, w, h - lineDrawer.Width ); // 아래
		}

		private void SELECT_CANCEL_BUTTON_Click( object sender, EventArgs e )
		{
			if ( this.UIModeVar == UIMode.QuestionIsRight )
			{
				GlobalVar.GlobalListPageInformations = null;
				this.SelectedInformationBuffer = null;
				UIModeVar = UIMode.NotSelected;
			}
		}
	}
}
