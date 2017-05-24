namespace WebtoonDownloader_CapstoneProject.UI.Forms
{
	partial class WebtoonDownloadDetailSectionForm
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WebtoonDownloadDetailSectionForm));
			this.DotAnimationTimer = new System.Windows.Forms.Timer(this.components);
			this.TOOL_TIP = new System.Windows.Forms.ToolTip(this.components);
			this.SECTION_SET_BUTTON = new WebtoonDownloader_CapstoneProject.UI.FlatButton();
			this.WEBTOON_NUM_LIST = new System.Windows.Forms.FlowLayoutPanel();
			this.POPUP_INFO_TITLE = new System.Windows.Forms.Label();
			this.POPUP_INFO_NUM = new System.Windows.Forms.Label();
			this.POPUP_INFO_THUMBNAIL = new System.Windows.Forms.PictureBox();
			this.POPUP_INFO_PANEL = new System.Windows.Forms.Panel();
			this.HINT_LABEL = new System.Windows.Forms.Label();
			this.HINT_ICON = new System.Windows.Forms.PictureBox();
			this.NEXT_PAGE_ICON = new System.Windows.Forms.PictureBox();
			this.PREVIOUS_PAGE_ICON = new System.Windows.Forms.PictureBox();
			this.PAGE_INDEX_PANEL = new System.Windows.Forms.FlowLayoutPanel();
			this.APP_TITLE_BAR = new WebtoonDownloader_CapstoneProject.UI.APP_TITLE_BAR();
			this.LOADING_LABEL = new System.Windows.Forms.Label();
			this.LOADING_MASK = new System.Windows.Forms.Panel();
			this.LOADING_GIFIMAGE = new System.Windows.Forms.WebBrowser();
			this.DOT_LIST = new WebtoonDownloader_CapstoneProject.UI.DoubleBufferPanel();
			((System.ComponentModel.ISupportInitialize)(this.POPUP_INFO_THUMBNAIL)).BeginInit();
			this.POPUP_INFO_PANEL.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.HINT_ICON)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.NEXT_PAGE_ICON)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.PREVIOUS_PAGE_ICON)).BeginInit();
			this.LOADING_MASK.SuspendLayout();
			this.SuspendLayout();
			// 
			// DotAnimationTimer
			// 
			this.DotAnimationTimer.Tick += new System.EventHandler(this.DotAnimationTimer_Tick);
			// 
			// SECTION_SET_BUTTON
			// 
			this.SECTION_SET_BUTTON.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.SECTION_SET_BUTTON.AnimationLerpP = 0.8F;
			this.SECTION_SET_BUTTON.BackColor = System.Drawing.Color.Transparent;
			this.SECTION_SET_BUTTON.ButtonText = "구간 설정";
			this.SECTION_SET_BUTTON.ButtonTextColor = System.Drawing.Color.Black;
			this.SECTION_SET_BUTTON.Cursor = System.Windows.Forms.Cursors.Hand;
			this.SECTION_SET_BUTTON.EnterStateBackgroundColor = System.Drawing.Color.Gainsboro;
			this.SECTION_SET_BUTTON.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.SECTION_SET_BUTTON.Font = new System.Drawing.Font("나눔고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.SECTION_SET_BUTTON.Location = new System.Drawing.Point(931, 76);
			this.SECTION_SET_BUTTON.Name = "SECTION_SET_BUTTON";
			this.SECTION_SET_BUTTON.NormalStateBackgroundColor = System.Drawing.Color.WhiteSmoke;
			this.SECTION_SET_BUTTON.Size = new System.Drawing.Size(200, 50);
			this.SECTION_SET_BUTTON.TabIndex = 5;
			this.SECTION_SET_BUTTON.TabStop = false;
			this.SECTION_SET_BUTTON.Text = "구간 설정";
			this.TOOL_TIP.SetToolTip(this.SECTION_SET_BUTTON, "설정한 구간을 적용합니다.");
			this.SECTION_SET_BUTTON.UseVisualStyleBackColor = false;
			this.SECTION_SET_BUTTON.Click += new System.EventHandler(this.SECTION_SET_BUTTON_Click);
			// 
			// WEBTOON_NUM_LIST
			// 
			this.WEBTOON_NUM_LIST.BackColor = System.Drawing.Color.Transparent;
			this.WEBTOON_NUM_LIST.Location = new System.Drawing.Point(12, 527);
			this.WEBTOON_NUM_LIST.Name = "WEBTOON_NUM_LIST";
			this.WEBTOON_NUM_LIST.Size = new System.Drawing.Size(1119, 75);
			this.WEBTOON_NUM_LIST.TabIndex = 0;
			this.WEBTOON_NUM_LIST.Paint += new System.Windows.Forms.PaintEventHandler(this.WEBTOON_NUM_LIST_Paint);
			this.WEBTOON_NUM_LIST.MouseMove += new System.Windows.Forms.MouseEventHandler(this.WEBTOON_NUM_LIST_MouseMove);
			// 
			// POPUP_INFO_TITLE
			// 
			this.POPUP_INFO_TITLE.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.POPUP_INFO_TITLE.AutoEllipsis = true;
			this.POPUP_INFO_TITLE.BackColor = System.Drawing.Color.Transparent;
			this.POPUP_INFO_TITLE.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.POPUP_INFO_TITLE.Location = new System.Drawing.Point(0, 156);
			this.POPUP_INFO_TITLE.Name = "POPUP_INFO_TITLE";
			this.POPUP_INFO_TITLE.Size = new System.Drawing.Size(379, 22);
			this.POPUP_INFO_TITLE.TabIndex = 17;
			this.POPUP_INFO_TITLE.Text = "서버에서 정보를 불러오고 있습니다 ";
			this.POPUP_INFO_TITLE.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// POPUP_INFO_NUM
			// 
			this.POPUP_INFO_NUM.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.POPUP_INFO_NUM.AutoEllipsis = true;
			this.POPUP_INFO_NUM.BackColor = System.Drawing.Color.Transparent;
			this.POPUP_INFO_NUM.Font = new System.Drawing.Font("나눔고딕", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.POPUP_INFO_NUM.Location = new System.Drawing.Point(0, 134);
			this.POPUP_INFO_NUM.Name = "POPUP_INFO_NUM";
			this.POPUP_INFO_NUM.Size = new System.Drawing.Size(74, 21);
			this.POPUP_INFO_NUM.TabIndex = 18;
			this.POPUP_INFO_NUM.Text = "0 화";
			this.POPUP_INFO_NUM.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// POPUP_INFO_THUMBNAIL
			// 
			this.POPUP_INFO_THUMBNAIL.BackColor = System.Drawing.Color.Transparent;
			this.POPUP_INFO_THUMBNAIL.Location = new System.Drawing.Point(80, 1);
			this.POPUP_INFO_THUMBNAIL.Name = "POPUP_INFO_THUMBNAIL";
			this.POPUP_INFO_THUMBNAIL.Size = new System.Drawing.Size(300, 155);
			this.POPUP_INFO_THUMBNAIL.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.POPUP_INFO_THUMBNAIL.TabIndex = 19;
			this.POPUP_INFO_THUMBNAIL.TabStop = false;
			// 
			// POPUP_INFO_PANEL
			// 
			this.POPUP_INFO_PANEL.Controls.Add(this.POPUP_INFO_THUMBNAIL);
			this.POPUP_INFO_PANEL.Controls.Add(this.POPUP_INFO_TITLE);
			this.POPUP_INFO_PANEL.Controls.Add(this.POPUP_INFO_NUM);
			this.POPUP_INFO_PANEL.Location = new System.Drawing.Point(12, 276);
			this.POPUP_INFO_PANEL.Name = "POPUP_INFO_PANEL";
			this.POPUP_INFO_PANEL.Size = new System.Drawing.Size(380, 180);
			this.POPUP_INFO_PANEL.TabIndex = 20;
			this.POPUP_INFO_PANEL.Paint += new System.Windows.Forms.PaintEventHandler(this.POPUP_INFO_PANEL_Paint);
			// 
			// HINT_LABEL
			// 
			this.HINT_LABEL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.HINT_LABEL.AutoEllipsis = true;
			this.HINT_LABEL.BackColor = System.Drawing.Color.Transparent;
			this.HINT_LABEL.Font = new System.Drawing.Font("나눔고딕", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.HINT_LABEL.Location = new System.Drawing.Point(65, 76);
			this.HINT_LABEL.Name = "HINT_LABEL";
			this.HINT_LABEL.Size = new System.Drawing.Size(575, 40);
			this.HINT_LABEL.TabIndex = 21;
			this.HINT_LABEL.Text = "다운로드 받으실 화의 시작 지점을 선택하세요!";
			this.HINT_LABEL.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// HINT_ICON
			// 
			this.HINT_ICON.BackColor = System.Drawing.Color.Transparent;
			this.HINT_ICON.Image = global::WebtoonDownloader_CapstoneProject.Properties.Resources.HINT;
			this.HINT_ICON.Location = new System.Drawing.Point(12, 76);
			this.HINT_ICON.Name = "HINT_ICON";
			this.HINT_ICON.Size = new System.Drawing.Size(40, 40);
			this.HINT_ICON.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.HINT_ICON.TabIndex = 22;
			this.HINT_ICON.TabStop = false;
			// 
			// NEXT_PAGE_ICON
			// 
			this.NEXT_PAGE_ICON.BackColor = System.Drawing.Color.Transparent;
			this.NEXT_PAGE_ICON.Cursor = System.Windows.Forms.Cursors.Hand;
			this.NEXT_PAGE_ICON.Image = global::WebtoonDownloader_CapstoneProject.Properties.Resources.NEXT_PAGE;
			this.NEXT_PAGE_ICON.Location = new System.Drawing.Point(1101, 608);
			this.NEXT_PAGE_ICON.Name = "NEXT_PAGE_ICON";
			this.NEXT_PAGE_ICON.Size = new System.Drawing.Size(30, 30);
			this.NEXT_PAGE_ICON.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.NEXT_PAGE_ICON.TabIndex = 23;
			this.NEXT_PAGE_ICON.TabStop = false;
			this.NEXT_PAGE_ICON.Click += new System.EventHandler(this.NEXT_PAGE_ICON_Click);
			// 
			// PREVIOUS_PAGE_ICON
			// 
			this.PREVIOUS_PAGE_ICON.BackColor = System.Drawing.Color.Transparent;
			this.PREVIOUS_PAGE_ICON.Cursor = System.Windows.Forms.Cursors.Hand;
			this.PREVIOUS_PAGE_ICON.Image = global::WebtoonDownloader_CapstoneProject.Properties.Resources.PREVIOUS_PAGE;
			this.PREVIOUS_PAGE_ICON.Location = new System.Drawing.Point(12, 608);
			this.PREVIOUS_PAGE_ICON.Name = "PREVIOUS_PAGE_ICON";
			this.PREVIOUS_PAGE_ICON.Size = new System.Drawing.Size(30, 30);
			this.PREVIOUS_PAGE_ICON.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.PREVIOUS_PAGE_ICON.TabIndex = 24;
			this.PREVIOUS_PAGE_ICON.TabStop = false;
			this.PREVIOUS_PAGE_ICON.Click += new System.EventHandler(this.PREVIOUS_PAGE_ICON_Click);
			// 
			// PAGE_INDEX_PANEL
			// 
			this.PAGE_INDEX_PANEL.AutoSize = true;
			this.PAGE_INDEX_PANEL.BackColor = System.Drawing.Color.Transparent;
			this.PAGE_INDEX_PANEL.Location = new System.Drawing.Point(566, 608);
			this.PAGE_INDEX_PANEL.Name = "PAGE_INDEX_PANEL";
			this.PAGE_INDEX_PANEL.Size = new System.Drawing.Size(10, 30);
			this.PAGE_INDEX_PANEL.TabIndex = 25;
			// 
			// APP_TITLE_BAR
			// 
			this.APP_TITLE_BAR.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.APP_TITLE_BAR.BackColor = System.Drawing.Color.Transparent;
			this.APP_TITLE_BAR.EnglishText = "Download Section";
			this.APP_TITLE_BAR.KoreanText = "다운로드 구간 세부 설정";
			this.APP_TITLE_BAR.Location = new System.Drawing.Point(0, 0);
			this.APP_TITLE_BAR.Name = "APP_TITLE_BAR";
			this.APP_TITLE_BAR.ShowClose = true;
			this.APP_TITLE_BAR.ShowHelp = false;
			this.APP_TITLE_BAR.ShowMinimize = false;
			this.APP_TITLE_BAR.Size = new System.Drawing.Size(1143, 70);
			this.APP_TITLE_BAR.TabIndex = 6;
			this.APP_TITLE_BAR.TextColor = System.Drawing.Color.Black;
			this.APP_TITLE_BAR.BeginClose += new System.Func<bool>(this.APP_TITLE_BAR_BeginClose);
			// 
			// LOADING_LABEL
			// 
			this.LOADING_LABEL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.LOADING_LABEL.BackColor = System.Drawing.Color.Transparent;
			this.LOADING_LABEL.Font = new System.Drawing.Font("나눔고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.LOADING_LABEL.Location = new System.Drawing.Point(485, 38);
			this.LOADING_LABEL.Name = "LOADING_LABEL";
			this.LOADING_LABEL.Size = new System.Drawing.Size(645, 20);
			this.LOADING_LABEL.TabIndex = 15;
			this.LOADING_LABEL.Text = "서버에서 정보를 불러오고 있습니다 ";
			this.LOADING_LABEL.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// LOADING_MASK
			// 
			this.LOADING_MASK.Controls.Add(this.LOADING_LABEL);
			this.LOADING_MASK.Controls.Add(this.LOADING_GIFIMAGE);
			this.LOADING_MASK.Location = new System.Drawing.Point(0, 280);
			this.LOADING_MASK.Name = "LOADING_MASK";
			this.LOADING_MASK.Size = new System.Drawing.Size(1143, 100);
			this.LOADING_MASK.TabIndex = 26;
			// 
			// LOADING_GIFIMAGE
			// 
			this.LOADING_GIFIMAGE.AllowNavigation = false;
			this.LOADING_GIFIMAGE.AllowWebBrowserDrop = false;
			this.LOADING_GIFIMAGE.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.LOADING_GIFIMAGE.IsWebBrowserContextMenuEnabled = false;
			this.LOADING_GIFIMAGE.Location = new System.Drawing.Point(410, 25);
			this.LOADING_GIFIMAGE.MinimumSize = new System.Drawing.Size(20, 20);
			this.LOADING_GIFIMAGE.Name = "LOADING_GIFIMAGE";
			this.LOADING_GIFIMAGE.ScriptErrorsSuppressed = true;
			this.LOADING_GIFIMAGE.ScrollBarsEnabled = false;
			this.LOADING_GIFIMAGE.Size = new System.Drawing.Size(50, 50);
			this.LOADING_GIFIMAGE.TabIndex = 16;
			this.LOADING_GIFIMAGE.WebBrowserShortcutsEnabled = false;
			// 
			// DOT_LIST
			// 
			this.DOT_LIST.Location = new System.Drawing.Point(12, 471);
			this.DOT_LIST.Name = "DOT_LIST";
			this.DOT_LIST.Size = new System.Drawing.Size(1119, 50);
			this.DOT_LIST.TabIndex = 0;
			this.DOT_LIST.Paint += new System.Windows.Forms.PaintEventHandler(this.DOT_LIST_Paint);
			this.DOT_LIST.MouseMove += new System.Windows.Forms.MouseEventHandler(this.DOT_LIST_MouseMove);
			// 
			// WebtoonDownloadDetailSectionForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(1143, 650);
			this.Controls.Add(this.DOT_LIST);
			this.Controls.Add(this.PAGE_INDEX_PANEL);
			this.Controls.Add(this.PREVIOUS_PAGE_ICON);
			this.Controls.Add(this.NEXT_PAGE_ICON);
			this.Controls.Add(this.HINT_ICON);
			this.Controls.Add(this.HINT_LABEL);
			this.Controls.Add(this.POPUP_INFO_PANEL);
			this.Controls.Add(this.WEBTOON_NUM_LIST);
			this.Controls.Add(this.APP_TITLE_BAR);
			this.Controls.Add(this.SECTION_SET_BUTTON);
			this.Controls.Add(this.LOADING_MASK);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "WebtoonDownloadDetailSectionForm";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "웹툰 다운로더";
			this.Load += new System.EventHandler(this.WebtoonDownloadDetailSectionForm_Load);
			this.Shown += new System.EventHandler(this.WebtoonDownloadOptionForm_Shown);
			this.Paint += new System.Windows.Forms.PaintEventHandler(this.WebtoonDownloadDetailSectionForm_Paint);
			((System.ComponentModel.ISupportInitialize)(this.POPUP_INFO_THUMBNAIL)).EndInit();
			this.POPUP_INFO_PANEL.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.HINT_ICON)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.NEXT_PAGE_ICON)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.PREVIOUS_PAGE_ICON)).EndInit();
			this.LOADING_MASK.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private FlatButton SECTION_SET_BUTTON;
		private APP_TITLE_BAR APP_TITLE_BAR;
		private System.Windows.Forms.Timer DotAnimationTimer;
		private System.Windows.Forms.ToolTip TOOL_TIP;
		private System.Windows.Forms.FlowLayoutPanel WEBTOON_NUM_LIST;
		private System.Windows.Forms.Label POPUP_INFO_TITLE;
		private System.Windows.Forms.Label POPUP_INFO_NUM;
		private System.Windows.Forms.PictureBox POPUP_INFO_THUMBNAIL;
		private System.Windows.Forms.Panel POPUP_INFO_PANEL;
		private System.Windows.Forms.Label HINT_LABEL;
		private System.Windows.Forms.PictureBox HINT_ICON;
		private System.Windows.Forms.PictureBox NEXT_PAGE_ICON;
		private System.Windows.Forms.PictureBox PREVIOUS_PAGE_ICON;
		private System.Windows.Forms.FlowLayoutPanel PAGE_INDEX_PANEL;
		private System.Windows.Forms.Label LOADING_LABEL;
		private System.Windows.Forms.Panel LOADING_MASK;
		private System.Windows.Forms.WebBrowser LOADING_GIFIMAGE;
		private DoubleBufferPanel DOT_LIST;
	}
}