namespace WebtoonDownloader_CapstoneProject.UI.Forms
{
	partial class WebtoonSearchForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WebtoonSearchForm));
			this.SEARCH_TEXTBOX = new System.Windows.Forms.TextBox();
			this.SEARCH_BUTTON = new WebtoonDownloader_CapstoneProject.UI.FlatButton();
			this.APP_TITLE_BAR = new WebtoonDownloader_CapstoneProject.UI.APP_TITLE_BAR();
			this.SEARCH_TEXTBOX_TITLE = new System.Windows.Forms.Label();
			this.SEARCH_RESULT_LIST = new WebtoonDownloader_CapstoneProject.UI.DoubleBufferPanel();
			this.SEARCH_LOADING_LABEL = new System.Windows.Forms.Label();
			this.LOADING_GIFIMAGE = new System.Windows.Forms.WebBrowser();
			this.NO_RESULT_TITLE = new System.Windows.Forms.Label();
			this.NO_RESULT_DESC = new System.Windows.Forms.Label();
			this.NO_RESULT_ICON = new System.Windows.Forms.PictureBox();
			this.WEBTOON_SEARCH_COUNT_LABEL = new WebtoonDownloader_CapstoneProject.UI.CustomLabel();
			((System.ComponentModel.ISupportInitialize)(this.NO_RESULT_ICON)).BeginInit();
			this.SuspendLayout();
			// 
			// SEARCH_TEXTBOX
			// 
			this.SEARCH_TEXTBOX.BackColor = System.Drawing.Color.White;
			this.SEARCH_TEXTBOX.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.SEARCH_TEXTBOX.Font = new System.Drawing.Font("나눔고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.SEARCH_TEXTBOX.Location = new System.Drawing.Point(15, 92);
			this.SEARCH_TEXTBOX.Name = "SEARCH_TEXTBOX";
			this.SEARCH_TEXTBOX.Size = new System.Drawing.Size(517, 25);
			this.SEARCH_TEXTBOX.TabIndex = 0;
			this.SEARCH_TEXTBOX.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SEARCH_TEXTBOX_KeyPress);
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
			this.SEARCH_BUTTON.Location = new System.Drawing.Point(538, 79);
			this.SEARCH_BUTTON.Name = "SEARCH_BUTTON";
			this.SEARCH_BUTTON.NormalStateBackgroundColor = System.Drawing.Color.WhiteSmoke;
			this.SEARCH_BUTTON.Size = new System.Drawing.Size(150, 50);
			this.SEARCH_BUTTON.TabIndex = 5;
			this.SEARCH_BUTTON.TabStop = false;
			this.SEARCH_BUTTON.Text = "웹툰 검색";
			this.SEARCH_BUTTON.UseVisualStyleBackColor = false;
			this.SEARCH_BUTTON.Click += new System.EventHandler(this.SEARCH_BUTTON_Click);
			// 
			// APP_TITLE_BAR
			// 
			this.APP_TITLE_BAR.BackColor = System.Drawing.Color.Transparent;
			this.APP_TITLE_BAR.EnglishText = "Webtoon Search";
			this.APP_TITLE_BAR.KoreanText = "웹툰 검색";
			this.APP_TITLE_BAR.Location = new System.Drawing.Point(0, 0);
			this.APP_TITLE_BAR.Name = "APP_TITLE_BAR";
			this.APP_TITLE_BAR.ShowClose = true;
			this.APP_TITLE_BAR.ShowHelp = false;
			this.APP_TITLE_BAR.ShowMinimize = false;
			this.APP_TITLE_BAR.Size = new System.Drawing.Size(700, 70);
			this.APP_TITLE_BAR.TabIndex = 6;
			this.APP_TITLE_BAR.TextColor = System.Drawing.Color.Black;
			this.APP_TITLE_BAR.BeginClose += new System.Func<bool>(this.APP_TITLE_BAR_BeginClose);
			// 
			// SEARCH_TEXTBOX_TITLE
			// 
			this.SEARCH_TEXTBOX_TITLE.AutoSize = true;
			this.SEARCH_TEXTBOX_TITLE.BackColor = System.Drawing.Color.Transparent;
			this.SEARCH_TEXTBOX_TITLE.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.SEARCH_TEXTBOX_TITLE.Location = new System.Drawing.Point(12, 70);
			this.SEARCH_TEXTBOX_TITLE.Name = "SEARCH_TEXTBOX_TITLE";
			this.SEARCH_TEXTBOX_TITLE.Size = new System.Drawing.Size(111, 15);
			this.SEARCH_TEXTBOX_TITLE.TabIndex = 10;
			this.SEARCH_TEXTBOX_TITLE.Text = "웹툰 이름으로 검색";
			this.SEARCH_TEXTBOX_TITLE.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// SEARCH_RESULT_LIST
			// 
			this.SEARCH_RESULT_LIST.AutoScroll = true;
			this.SEARCH_RESULT_LIST.BackColor = System.Drawing.Color.Transparent;
			this.SEARCH_RESULT_LIST.Location = new System.Drawing.Point(15, 140);
			this.SEARCH_RESULT_LIST.Name = "SEARCH_RESULT_LIST";
			this.SEARCH_RESULT_LIST.Size = new System.Drawing.Size(673, 498);
			this.SEARCH_RESULT_LIST.TabIndex = 11;
			this.SEARCH_RESULT_LIST.Scroll += new System.Windows.Forms.ScrollEventHandler(this.SEARCH_RESULT_LIST_Scroll);
			this.SEARCH_RESULT_LIST.Paint += new System.Windows.Forms.PaintEventHandler(this.SEARCH_RESULT_LIST_Paint);
			// 
			// SEARCH_LOADING_LABEL
			// 
			this.SEARCH_LOADING_LABEL.BackColor = System.Drawing.Color.Transparent;
			this.SEARCH_LOADING_LABEL.Font = new System.Drawing.Font("나눔고딕", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.SEARCH_LOADING_LABEL.Location = new System.Drawing.Point(75, 89);
			this.SEARCH_LOADING_LABEL.Name = "SEARCH_LOADING_LABEL";
			this.SEARCH_LOADING_LABEL.Size = new System.Drawing.Size(457, 26);
			this.SEARCH_LOADING_LABEL.TabIndex = 12;
			this.SEARCH_LOADING_LABEL.Text = "\'웹툰 이름\'을 포함하는 웹툰을 검색하고 있습니다 ...";
			this.SEARCH_LOADING_LABEL.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.SEARCH_LOADING_LABEL.Visible = false;
			// 
			// LOADING_GIFIMAGE
			// 
			this.LOADING_GIFIMAGE.AllowNavigation = false;
			this.LOADING_GIFIMAGE.AllowWebBrowserDrop = false;
			this.LOADING_GIFIMAGE.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.LOADING_GIFIMAGE.IsWebBrowserContextMenuEnabled = false;
			this.LOADING_GIFIMAGE.Location = new System.Drawing.Point(15, 79);
			this.LOADING_GIFIMAGE.MinimumSize = new System.Drawing.Size(20, 20);
			this.LOADING_GIFIMAGE.Name = "LOADING_GIFIMAGE";
			this.LOADING_GIFIMAGE.ScriptErrorsSuppressed = true;
			this.LOADING_GIFIMAGE.ScrollBarsEnabled = false;
			this.LOADING_GIFIMAGE.Size = new System.Drawing.Size(50, 50);
			this.LOADING_GIFIMAGE.TabIndex = 15;
			this.LOADING_GIFIMAGE.Visible = false;
			this.LOADING_GIFIMAGE.WebBrowserShortcutsEnabled = false;
			// 
			// NO_RESULT_TITLE
			// 
			this.NO_RESULT_TITLE.AutoSize = true;
			this.NO_RESULT_TITLE.BackColor = System.Drawing.Color.Transparent;
			this.NO_RESULT_TITLE.Font = new System.Drawing.Font("나눔고딕", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.NO_RESULT_TITLE.Location = new System.Drawing.Point(300, 389);
			this.NO_RESULT_TITLE.Name = "NO_RESULT_TITLE";
			this.NO_RESULT_TITLE.Size = new System.Drawing.Size(100, 17);
			this.NO_RESULT_TITLE.TabIndex = 16;
			this.NO_RESULT_TITLE.Text = "검색 결과 없음";
			this.NO_RESULT_TITLE.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.NO_RESULT_TITLE.Visible = false;
			// 
			// NO_RESULT_DESC
			// 
			this.NO_RESULT_DESC.AutoEllipsis = true;
			this.NO_RESULT_DESC.BackColor = System.Drawing.Color.Transparent;
			this.NO_RESULT_DESC.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.NO_RESULT_DESC.Location = new System.Drawing.Point(0, 417);
			this.NO_RESULT_DESC.Name = "NO_RESULT_DESC";
			this.NO_RESULT_DESC.Size = new System.Drawing.Size(700, 17);
			this.NO_RESULT_DESC.TabIndex = 17;
			this.NO_RESULT_DESC.Text = "검색 결과 없음";
			this.NO_RESULT_DESC.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.NO_RESULT_DESC.Visible = false;
			// 
			// NO_RESULT_ICON
			// 
			this.NO_RESULT_ICON.BackColor = System.Drawing.Color.Transparent;
			this.NO_RESULT_ICON.Image = global::WebtoonDownloader_CapstoneProject.Properties.Resources.SEARCH;
			this.NO_RESULT_ICON.Location = new System.Drawing.Point(300, 270);
			this.NO_RESULT_ICON.Name = "NO_RESULT_ICON";
			this.NO_RESULT_ICON.Size = new System.Drawing.Size(100, 100);
			this.NO_RESULT_ICON.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.NO_RESULT_ICON.TabIndex = 18;
			this.NO_RESULT_ICON.TabStop = false;
			// 
			// WEBTOON_SEARCH_COUNT_LABEL
			// 
			this.WEBTOON_SEARCH_COUNT_LABEL.BackColor = System.Drawing.Color.Transparent;
			this.WEBTOON_SEARCH_COUNT_LABEL.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.WEBTOON_SEARCH_COUNT_LABEL.Location = new System.Drawing.Point(254, 23);
			this.WEBTOON_SEARCH_COUNT_LABEL.Name = "WEBTOON_SEARCH_COUNT_LABEL";
			this.WEBTOON_SEARCH_COUNT_LABEL.Size = new System.Drawing.Size(375, 25);
			this.WEBTOON_SEARCH_COUNT_LABEL.TabIndex = 19;
			this.WEBTOON_SEARCH_COUNT_LABEL.Text = "\'웹툰 이름\'을 포함하는 웹툰을 검색하고 있습니다 ...";
			this.WEBTOON_SEARCH_COUNT_LABEL.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.WEBTOON_SEARCH_COUNT_LABEL.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
			this.WEBTOON_SEARCH_COUNT_LABEL.Visible = false;
			// 
			// WebtoonSearchForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(700, 650);
			this.Controls.Add(this.WEBTOON_SEARCH_COUNT_LABEL);
			this.Controls.Add(this.NO_RESULT_ICON);
			this.Controls.Add(this.NO_RESULT_DESC);
			this.Controls.Add(this.NO_RESULT_TITLE);
			this.Controls.Add(this.LOADING_GIFIMAGE);
			this.Controls.Add(this.SEARCH_LOADING_LABEL);
			this.Controls.Add(this.SEARCH_RESULT_LIST);
			this.Controls.Add(this.SEARCH_TEXTBOX_TITLE);
			this.Controls.Add(this.APP_TITLE_BAR);
			this.Controls.Add(this.SEARCH_BUTTON);
			this.Controls.Add(this.SEARCH_TEXTBOX);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "WebtoonSearchForm";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "웹툰 다운로더";
			this.Load += new System.EventHandler(this.WebtoonSearchForm_Load);
			this.Paint += new System.Windows.Forms.PaintEventHandler(this.WebtoonSearchForm_Paint);
			((System.ComponentModel.ISupportInitialize)(this.NO_RESULT_ICON)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox SEARCH_TEXTBOX;
		private FlatButton SEARCH_BUTTON;
		private APP_TITLE_BAR APP_TITLE_BAR;
		private System.Windows.Forms.Label SEARCH_TEXTBOX_TITLE;
		private DoubleBufferPanel SEARCH_RESULT_LIST;
		private System.Windows.Forms.Label SEARCH_LOADING_LABEL;
		private System.Windows.Forms.WebBrowser LOADING_GIFIMAGE;
		private System.Windows.Forms.Label NO_RESULT_TITLE;
		private System.Windows.Forms.Label NO_RESULT_DESC;
		private System.Windows.Forms.PictureBox NO_RESULT_ICON;
		private CustomLabel WEBTOON_SEARCH_COUNT_LABEL;
	}
}