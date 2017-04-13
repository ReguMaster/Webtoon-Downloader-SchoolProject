namespace WebtoonDownloader_CapstoneProject.UI.Forms
{
	partial class WebtoonSelectForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose( bool disposing )
		{
			if ( disposing && ( components != null ) )
			{
				components.Dispose( );
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent( )
		{
			this.URL_TEXTBOX = new System.Windows.Forms.TextBox();
			this.SEARCH_BUTTON = new WebtoonDownloader_CapstoneProject.UI.FlatButton();
			this.APP_TITLE_BAR = new WebtoonDownloader_CapstoneProject.UI.APP_TITLE_BAR();
			this.NAME_TEXTBOX = new System.Windows.Forms.TextBox();
			this.URL_TEXTBOX_TITLE = new System.Windows.Forms.Label();
			this.NAME_TEXTBOX_TITLE = new System.Windows.Forms.Label();
			this.SELECTED_WEBTOON_INFORMATION_PANEL = new WebtoonDownloader_CapstoneProject.UI.Forms.WebtoonDownloadInformationForWebtoonSelectForm();
			this.SELECTED_WEBTOON_INFORMATION_PANEL_TITLE = new System.Windows.Forms.Label();
			this.SELECT_CANCEL_BUTTON = new WebtoonDownloader_CapstoneProject.UI.FlatButton();
			this.SuspendLayout();
			// 
			// URL_TEXTBOX
			// 
			this.URL_TEXTBOX.BackColor = System.Drawing.Color.WhiteSmoke;
			this.URL_TEXTBOX.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.URL_TEXTBOX.Font = new System.Drawing.Font("나눔고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.URL_TEXTBOX.Location = new System.Drawing.Point(75, 286);
			this.URL_TEXTBOX.Name = "URL_TEXTBOX";
			this.URL_TEXTBOX.Size = new System.Drawing.Size(545, 18);
			this.URL_TEXTBOX.TabIndex = 0;
			this.URL_TEXTBOX.Text = "http://comic.naver.com/webtoon/list.nhn?titleId=570503&weekday=thu";
			// 
			// SEARCH_BUTTON
			// 
			this.SEARCH_BUTTON.AnimationLerpP = 0.8F;
			this.SEARCH_BUTTON.BackColor = System.Drawing.Color.Transparent;
			this.SEARCH_BUTTON.ButtonText = "웹툰 검색";
			this.SEARCH_BUTTON.ButtonTextColor = System.Drawing.Color.Black;
			this.SEARCH_BUTTON.Cursor = System.Windows.Forms.Cursors.Hand;
			this.SEARCH_BUTTON.EnterStateBackgroundColor = System.Drawing.Color.Gainsboro;
			this.SEARCH_BUTTON.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.SEARCH_BUTTON.Font = new System.Drawing.Font("나눔고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.SEARCH_BUTTON.Location = new System.Drawing.Point(488, 338);
			this.SEARCH_BUTTON.Name = "SEARCH_BUTTON";
			this.SEARCH_BUTTON.NormalStateBackgroundColor = System.Drawing.Color.WhiteSmoke;
			this.SEARCH_BUTTON.Size = new System.Drawing.Size(200, 50);
			this.SEARCH_BUTTON.TabIndex = 5;
			this.SEARCH_BUTTON.TabStop = false;
			this.SEARCH_BUTTON.Text = "웹툰 검색";
			this.SEARCH_BUTTON.UseVisualStyleBackColor = false;
			this.SEARCH_BUTTON.Click += new System.EventHandler(this.SEARCH_BUTTON_Click);
			// 
			// APP_TITLE_BAR
			// 
			this.APP_TITLE_BAR.BackColor = System.Drawing.Color.Transparent;
			this.APP_TITLE_BAR.EnglishText = "Webtoon Selection";
			this.APP_TITLE_BAR.KoreanText = "다운로드 할 웹툰 선택";
			this.APP_TITLE_BAR.Location = new System.Drawing.Point(0, 0);
			this.APP_TITLE_BAR.Name = "APP_TITLE_BAR";
			this.APP_TITLE_BAR.ShowClose = true;
			this.APP_TITLE_BAR.ShowMinimize = false;
			this.APP_TITLE_BAR.Size = new System.Drawing.Size(700, 70);
			this.APP_TITLE_BAR.TabIndex = 6;
			this.APP_TITLE_BAR.TextColor = System.Drawing.Color.Black;
			// 
			// NAME_TEXTBOX
			// 
			this.NAME_TEXTBOX.BackColor = System.Drawing.Color.WhiteSmoke;
			this.NAME_TEXTBOX.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.NAME_TEXTBOX.Enabled = false;
			this.NAME_TEXTBOX.Font = new System.Drawing.Font("나눔고딕", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.NAME_TEXTBOX.Location = new System.Drawing.Point(75, 145);
			this.NAME_TEXTBOX.Name = "NAME_TEXTBOX";
			this.NAME_TEXTBOX.Size = new System.Drawing.Size(545, 22);
			this.NAME_TEXTBOX.TabIndex = 7;
			// 
			// URL_TEXTBOX_TITLE
			// 
			this.URL_TEXTBOX_TITLE.AutoSize = true;
			this.URL_TEXTBOX_TITLE.BackColor = System.Drawing.Color.Transparent;
			this.URL_TEXTBOX_TITLE.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.URL_TEXTBOX_TITLE.Location = new System.Drawing.Point(75, 260);
			this.URL_TEXTBOX_TITLE.Name = "URL_TEXTBOX_TITLE";
			this.URL_TEXTBOX_TITLE.Size = new System.Drawing.Size(99, 15);
			this.URL_TEXTBOX_TITLE.TabIndex = 8;
			this.URL_TEXTBOX_TITLE.Text = "주소로 웹툰 선택";
			this.URL_TEXTBOX_TITLE.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// NAME_TEXTBOX_TITLE
			// 
			this.NAME_TEXTBOX_TITLE.AutoSize = true;
			this.NAME_TEXTBOX_TITLE.BackColor = System.Drawing.Color.Transparent;
			this.NAME_TEXTBOX_TITLE.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.NAME_TEXTBOX_TITLE.Location = new System.Drawing.Point(75, 115);
			this.NAME_TEXTBOX_TITLE.Name = "NAME_TEXTBOX_TITLE";
			this.NAME_TEXTBOX_TITLE.Size = new System.Drawing.Size(155, 15);
			this.NAME_TEXTBOX_TITLE.TabIndex = 9;
			this.NAME_TEXTBOX_TITLE.Text = "웹툰 이름으로 검색 후 선택";
			this.NAME_TEXTBOX_TITLE.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// SELECTED_WEBTOON_INFORMATION_PANEL
			// 
			this.SELECTED_WEBTOON_INFORMATION_PANEL.BackColor = System.Drawing.Color.Transparent;
			this.SELECTED_WEBTOON_INFORMATION_PANEL.Location = new System.Drawing.Point(25, 103);
			this.SELECTED_WEBTOON_INFORMATION_PANEL.Name = "SELECTED_WEBTOON_INFORMATION_PANEL";
			this.SELECTED_WEBTOON_INFORMATION_PANEL.Size = new System.Drawing.Size(650, 210);
			this.SELECTED_WEBTOON_INFORMATION_PANEL.TabIndex = 11;
			this.SELECTED_WEBTOON_INFORMATION_PANEL.Visible = false;
			// 
			// SELECTED_WEBTOON_INFORMATION_PANEL_TITLE
			// 
			this.SELECTED_WEBTOON_INFORMATION_PANEL_TITLE.AutoSize = true;
			this.SELECTED_WEBTOON_INFORMATION_PANEL_TITLE.BackColor = System.Drawing.Color.Transparent;
			this.SELECTED_WEBTOON_INFORMATION_PANEL_TITLE.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.SELECTED_WEBTOON_INFORMATION_PANEL_TITLE.Location = new System.Drawing.Point(22, 78);
			this.SELECTED_WEBTOON_INFORMATION_PANEL_TITLE.Name = "SELECTED_WEBTOON_INFORMATION_PANEL_TITLE";
			this.SELECTED_WEBTOON_INFORMATION_PANEL_TITLE.Size = new System.Drawing.Size(214, 15);
			this.SELECTED_WEBTOON_INFORMATION_PANEL_TITLE.TabIndex = 12;
			this.SELECTED_WEBTOON_INFORMATION_PANEL_TITLE.Text = "다운로드 하실 웹툰이 이 웹툰 입니까?";
			this.SELECTED_WEBTOON_INFORMATION_PANEL_TITLE.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.SELECTED_WEBTOON_INFORMATION_PANEL_TITLE.Visible = false;
			// 
			// SELECT_CANCEL_BUTTON
			// 
			this.SELECT_CANCEL_BUTTON.AnimationLerpP = 0.8F;
			this.SELECT_CANCEL_BUTTON.BackColor = System.Drawing.Color.Transparent;
			this.SELECT_CANCEL_BUTTON.ButtonText = "아닙니다.";
			this.SELECT_CANCEL_BUTTON.ButtonTextColor = System.Drawing.Color.White;
			this.SELECT_CANCEL_BUTTON.Cursor = System.Windows.Forms.Cursors.Hand;
			this.SELECT_CANCEL_BUTTON.EnterStateBackgroundColor = System.Drawing.Color.Red;
			this.SELECT_CANCEL_BUTTON.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.SELECT_CANCEL_BUTTON.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.SELECT_CANCEL_BUTTON.Location = new System.Drawing.Point(282, 363);
			this.SELECT_CANCEL_BUTTON.Name = "SELECT_CANCEL_BUTTON";
			this.SELECT_CANCEL_BUTTON.NormalStateBackgroundColor = System.Drawing.Color.Crimson;
			this.SELECT_CANCEL_BUTTON.Size = new System.Drawing.Size(200, 25);
			this.SELECT_CANCEL_BUTTON.TabIndex = 13;
			this.SELECT_CANCEL_BUTTON.TabStop = false;
			this.SELECT_CANCEL_BUTTON.Text = "아닙니다.";
			this.SELECT_CANCEL_BUTTON.UseVisualStyleBackColor = false;
			this.SELECT_CANCEL_BUTTON.Visible = false;
			this.SELECT_CANCEL_BUTTON.Click += new System.EventHandler(this.SELECT_CANCEL_BUTTON_Click);
			// 
			// WebtoonSelectForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(700, 400);
			this.Controls.Add(this.SELECT_CANCEL_BUTTON);
			this.Controls.Add(this.SELECTED_WEBTOON_INFORMATION_PANEL_TITLE);
			this.Controls.Add(this.NAME_TEXTBOX_TITLE);
			this.Controls.Add(this.URL_TEXTBOX_TITLE);
			this.Controls.Add(this.NAME_TEXTBOX);
			this.Controls.Add(this.APP_TITLE_BAR);
			this.Controls.Add(this.SEARCH_BUTTON);
			this.Controls.Add(this.URL_TEXTBOX);
			this.Controls.Add(this.SELECTED_WEBTOON_INFORMATION_PANEL);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "WebtoonSelectForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "웹툰 다운로더";
			this.Load += new System.EventHandler(this.WebtoonSelectForm_Load);
			this.Paint += new System.Windows.Forms.PaintEventHandler(this.WebtoonSelectForm_Paint);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox URL_TEXTBOX;
		private FlatButton SEARCH_BUTTON;
		private APP_TITLE_BAR APP_TITLE_BAR;
		private System.Windows.Forms.TextBox NAME_TEXTBOX;
		private System.Windows.Forms.Label URL_TEXTBOX_TITLE;
		private System.Windows.Forms.Label NAME_TEXTBOX_TITLE;
		private WebtoonDownloadInformationForWebtoonSelectForm SELECTED_WEBTOON_INFORMATION_PANEL;
		private System.Windows.Forms.Label SELECTED_WEBTOON_INFORMATION_PANEL_TITLE;
		private FlatButton SELECT_CANCEL_BUTTON;
	}
}