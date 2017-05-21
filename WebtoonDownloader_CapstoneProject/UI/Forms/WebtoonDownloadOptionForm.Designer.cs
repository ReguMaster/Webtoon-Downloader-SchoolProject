namespace WebtoonDownloader_CapstoneProject.UI.Forms
{
	partial class WebtoonDownloadOptionForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WebtoonDownloadOptionForm));
			this.DOWNLOAD_OPTION_PANEL = new System.Windows.Forms.Panel();
			this.DOWNLOAD_READY_IMAGE = new System.Windows.Forms.PictureBox();
			this.LEFT_LABEL = new System.Windows.Forms.Label();
			this.END_TITLE_LABEL = new System.Windows.Forms.Label();
			this.END_THUMBNAIL_IMAGE = new System.Windows.Forms.PictureBox();
			this.BEGIN_TITLE_LABEL = new System.Windows.Forms.Label();
			this.BEGIN_THUMBNAIL_IMAGE = new System.Windows.Forms.PictureBox();
			this.DOWNLOAD_OPTION_TITLE = new System.Windows.Forms.Label();
			this.RIGHT_LABEL = new System.Windows.Forms.Label();
			this.CENTER_LABEL = new System.Windows.Forms.Label();
			this.WEBTOON_END_NUMBER = new System.Windows.Forms.NumericUpDown();
			this.WEBTOON_BEGIN_NUMBER = new System.Windows.Forms.NumericUpDown();
			this.LOADING_LABEL = new System.Windows.Forms.Label();
			this.DotAnimationTimer = new System.Windows.Forms.Timer(this.components);
			this.BGM_DOWNLOAD_LABEL = new System.Windows.Forms.Label();
			this.CREATE_VIEWER_LABEL = new System.Windows.Forms.Label();
			this.APP_TITLE_BAR = new WebtoonDownloader_CapstoneProject.UI.APP_TITLE_BAR();
			this.DOWNLOAD_BUTTON = new WebtoonDownloader_CapstoneProject.UI.FlatButton();
			this.QUALITY_OPTION_PANEL = new System.Windows.Forms.Panel();
			this.QUALITY_EXAMPLE_NOT_AVAILABLE = new System.Windows.Forms.Label();
			this.RANDOM_IMAGE_BUTTON = new System.Windows.Forms.PictureBox();
			this.QUALITY_EXAMPLE_TITLE = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.QUALITY_EXAMPLE_IMAGE = new System.Windows.Forms.PictureBox();
			this.QUALITY_VALUE_HINT = new System.Windows.Forms.Label();
			this.QUALITY_VALUE_BAR = new System.Windows.Forms.TrackBar();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.QUALITY_OPTION_TITLE = new System.Windows.Forms.Label();
			this.CREATE_VIEWER_CHECKBOX = new WebtoonDownloader_CapstoneProject.UI.FlatCheckBox();
			this.BGM_DOWNLOAD_CHECKBOX = new WebtoonDownloader_CapstoneProject.UI.FlatCheckBox();
			this.TOOL_TIP = new System.Windows.Forms.ToolTip(this.components);
			this.WARN_TOOLOW_LABEL = new System.Windows.Forms.Label();
			this.DOWNLOAD_OPTION_PANEL.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.DOWNLOAD_READY_IMAGE)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.END_THUMBNAIL_IMAGE)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.BEGIN_THUMBNAIL_IMAGE)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.WEBTOON_END_NUMBER)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.WEBTOON_BEGIN_NUMBER)).BeginInit();
			this.QUALITY_OPTION_PANEL.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.RANDOM_IMAGE_BUTTON)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.QUALITY_EXAMPLE_IMAGE)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.QUALITY_VALUE_BAR)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.CREATE_VIEWER_CHECKBOX)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.BGM_DOWNLOAD_CHECKBOX)).BeginInit();
			this.SuspendLayout();
			// 
			// DOWNLOAD_OPTION_PANEL
			// 
			this.DOWNLOAD_OPTION_PANEL.AutoScroll = true;
			this.DOWNLOAD_OPTION_PANEL.Controls.Add(this.DOWNLOAD_READY_IMAGE);
			this.DOWNLOAD_OPTION_PANEL.Controls.Add(this.LEFT_LABEL);
			this.DOWNLOAD_OPTION_PANEL.Controls.Add(this.END_TITLE_LABEL);
			this.DOWNLOAD_OPTION_PANEL.Controls.Add(this.END_THUMBNAIL_IMAGE);
			this.DOWNLOAD_OPTION_PANEL.Controls.Add(this.BEGIN_TITLE_LABEL);
			this.DOWNLOAD_OPTION_PANEL.Controls.Add(this.BEGIN_THUMBNAIL_IMAGE);
			this.DOWNLOAD_OPTION_PANEL.Controls.Add(this.DOWNLOAD_OPTION_TITLE);
			this.DOWNLOAD_OPTION_PANEL.Controls.Add(this.RIGHT_LABEL);
			this.DOWNLOAD_OPTION_PANEL.Controls.Add(this.CENTER_LABEL);
			this.DOWNLOAD_OPTION_PANEL.Controls.Add(this.WEBTOON_END_NUMBER);
			this.DOWNLOAD_OPTION_PANEL.Controls.Add(this.WEBTOON_BEGIN_NUMBER);
			this.DOWNLOAD_OPTION_PANEL.Location = new System.Drawing.Point(12, 75);
			this.DOWNLOAD_OPTION_PANEL.Name = "DOWNLOAD_OPTION_PANEL";
			this.DOWNLOAD_OPTION_PANEL.Size = new System.Drawing.Size(676, 306);
			this.DOWNLOAD_OPTION_PANEL.TabIndex = 14;
			this.DOWNLOAD_OPTION_PANEL.Visible = false;
			this.DOWNLOAD_OPTION_PANEL.Paint += new System.Windows.Forms.PaintEventHandler(this.DOWNLOAD_OPTION_PANEL_Paint);
			// 
			// DOWNLOAD_READY_IMAGE
			// 
			this.DOWNLOAD_READY_IMAGE.BackColor = System.Drawing.Color.Transparent;
			this.DOWNLOAD_READY_IMAGE.Image = global::WebtoonDownloader_CapstoneProject.Properties.Resources.DOWN;
			this.DOWNLOAD_READY_IMAGE.Location = new System.Drawing.Point(4, 2);
			this.DOWNLOAD_READY_IMAGE.Name = "DOWNLOAD_READY_IMAGE";
			this.DOWNLOAD_READY_IMAGE.Size = new System.Drawing.Size(40, 40);
			this.DOWNLOAD_READY_IMAGE.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.DOWNLOAD_READY_IMAGE.TabIndex = 20;
			this.DOWNLOAD_READY_IMAGE.TabStop = false;
			// 
			// LEFT_LABEL
			// 
			this.LEFT_LABEL.AutoSize = true;
			this.LEFT_LABEL.BackColor = System.Drawing.Color.Transparent;
			this.LEFT_LABEL.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.LEFT_LABEL.Location = new System.Drawing.Point(136, 277);
			this.LEFT_LABEL.Name = "LEFT_LABEL";
			this.LEFT_LABEL.Size = new System.Drawing.Size(43, 14);
			this.LEFT_LABEL.TabIndex = 16;
			this.LEFT_LABEL.Text = "시작 화";
			this.LEFT_LABEL.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// END_TITLE_LABEL
			// 
			this.END_TITLE_LABEL.BackColor = System.Drawing.Color.Transparent;
			this.END_TITLE_LABEL.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.END_TITLE_LABEL.Location = new System.Drawing.Point(373, 211);
			this.END_TITLE_LABEL.Name = "END_TITLE_LABEL";
			this.END_TITLE_LABEL.Size = new System.Drawing.Size(300, 51);
			this.END_TITLE_LABEL.TabIndex = 19;
			this.END_TITLE_LABEL.Text = "0. START";
			this.END_TITLE_LABEL.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// END_THUMBNAIL_IMAGE
			// 
			this.END_THUMBNAIL_IMAGE.Location = new System.Drawing.Point(373, 50);
			this.END_THUMBNAIL_IMAGE.Name = "END_THUMBNAIL_IMAGE";
			this.END_THUMBNAIL_IMAGE.Size = new System.Drawing.Size(300, 157);
			this.END_THUMBNAIL_IMAGE.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.END_THUMBNAIL_IMAGE.TabIndex = 18;
			this.END_THUMBNAIL_IMAGE.TabStop = false;
			this.END_THUMBNAIL_IMAGE.Paint += new System.Windows.Forms.PaintEventHandler(this.END_THUMBNAIL_IMAGE_Paint);
			// 
			// BEGIN_TITLE_LABEL
			// 
			this.BEGIN_TITLE_LABEL.BackColor = System.Drawing.Color.Transparent;
			this.BEGIN_TITLE_LABEL.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.BEGIN_TITLE_LABEL.Location = new System.Drawing.Point(4, 210);
			this.BEGIN_TITLE_LABEL.Name = "BEGIN_TITLE_LABEL";
			this.BEGIN_TITLE_LABEL.Size = new System.Drawing.Size(300, 51);
			this.BEGIN_TITLE_LABEL.TabIndex = 17;
			this.BEGIN_TITLE_LABEL.Text = "0. START";
			this.BEGIN_TITLE_LABEL.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// BEGIN_THUMBNAIL_IMAGE
			// 
			this.BEGIN_THUMBNAIL_IMAGE.Location = new System.Drawing.Point(4, 50);
			this.BEGIN_THUMBNAIL_IMAGE.Name = "BEGIN_THUMBNAIL_IMAGE";
			this.BEGIN_THUMBNAIL_IMAGE.Size = new System.Drawing.Size(300, 157);
			this.BEGIN_THUMBNAIL_IMAGE.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.BEGIN_THUMBNAIL_IMAGE.TabIndex = 16;
			this.BEGIN_THUMBNAIL_IMAGE.TabStop = false;
			this.BEGIN_THUMBNAIL_IMAGE.Paint += new System.Windows.Forms.PaintEventHandler(this.BEGIN_THUMBNAIL_IMAGE_Paint);
			// 
			// DOWNLOAD_OPTION_TITLE
			// 
			this.DOWNLOAD_OPTION_TITLE.AutoSize = true;
			this.DOWNLOAD_OPTION_TITLE.BackColor = System.Drawing.Color.Transparent;
			this.DOWNLOAD_OPTION_TITLE.Font = new System.Drawing.Font("나눔고딕", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.DOWNLOAD_OPTION_TITLE.Location = new System.Drawing.Point(51, 14);
			this.DOWNLOAD_OPTION_TITLE.Name = "DOWNLOAD_OPTION_TITLE";
			this.DOWNLOAD_OPTION_TITLE.Size = new System.Drawing.Size(96, 17);
			this.DOWNLOAD_OPTION_TITLE.TabIndex = 15;
			this.DOWNLOAD_OPTION_TITLE.Text = "다운로드 구간";
			this.DOWNLOAD_OPTION_TITLE.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// RIGHT_LABEL
			// 
			this.RIGHT_LABEL.AutoSize = true;
			this.RIGHT_LABEL.BackColor = System.Drawing.Color.Transparent;
			this.RIGHT_LABEL.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.RIGHT_LABEL.Location = new System.Drawing.Point(446, 277);
			this.RIGHT_LABEL.Name = "RIGHT_LABEL";
			this.RIGHT_LABEL.Size = new System.Drawing.Size(123, 14);
			this.RIGHT_LABEL.TabIndex = 14;
			this.RIGHT_LABEL.Text = "화까지 다운로드 합니다";
			this.RIGHT_LABEL.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// CENTER_LABEL
			// 
			this.CENTER_LABEL.AutoSize = true;
			this.CENTER_LABEL.BackColor = System.Drawing.Color.Transparent;
			this.CENTER_LABEL.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.CENTER_LABEL.Location = new System.Drawing.Point(291, 277);
			this.CENTER_LABEL.Name = "CENTER_LABEL";
			this.CENTER_LABEL.Size = new System.Drawing.Size(43, 14);
			this.CENTER_LABEL.TabIndex = 13;
			this.CENTER_LABEL.Text = "화 부터";
			this.CENTER_LABEL.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// WEBTOON_END_NUMBER
			// 
			this.WEBTOON_END_NUMBER.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.WEBTOON_END_NUMBER.Font = new System.Drawing.Font("맑은 고딕", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.WEBTOON_END_NUMBER.Location = new System.Drawing.Point(340, 267);
			this.WEBTOON_END_NUMBER.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
			this.WEBTOON_END_NUMBER.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.WEBTOON_END_NUMBER.Name = "WEBTOON_END_NUMBER";
			this.WEBTOON_END_NUMBER.Size = new System.Drawing.Size(100, 35);
			this.WEBTOON_END_NUMBER.TabIndex = 1;
			this.WEBTOON_END_NUMBER.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.WEBTOON_END_NUMBER.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.WEBTOON_END_NUMBER.ValueChanged += new System.EventHandler(this.WEBTOON_END_NUMBER_ValueChanged);
			this.WEBTOON_END_NUMBER.Enter += new System.EventHandler(this.WEBTOON_END_NUMBER_Enter);
			this.WEBTOON_END_NUMBER.Leave += new System.EventHandler(this.WEBTOON_END_NUMBER_Leave);
			// 
			// WEBTOON_BEGIN_NUMBER
			// 
			this.WEBTOON_BEGIN_NUMBER.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.WEBTOON_BEGIN_NUMBER.Font = new System.Drawing.Font("맑은 고딕", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.WEBTOON_BEGIN_NUMBER.Location = new System.Drawing.Point(185, 267);
			this.WEBTOON_BEGIN_NUMBER.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
			this.WEBTOON_BEGIN_NUMBER.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.WEBTOON_BEGIN_NUMBER.Name = "WEBTOON_BEGIN_NUMBER";
			this.WEBTOON_BEGIN_NUMBER.Size = new System.Drawing.Size(100, 35);
			this.WEBTOON_BEGIN_NUMBER.TabIndex = 0;
			this.WEBTOON_BEGIN_NUMBER.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.WEBTOON_BEGIN_NUMBER.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.WEBTOON_BEGIN_NUMBER.ValueChanged += new System.EventHandler(this.WEBTOON_BEGIN_NUMBER_ValueChanged);
			this.WEBTOON_BEGIN_NUMBER.Enter += new System.EventHandler(this.WEBTOON_BEGIN_NUMBER_Enter);
			this.WEBTOON_BEGIN_NUMBER.Leave += new System.EventHandler(this.WEBTOON_BEGIN_NUMBER_Leave);
			// 
			// LOADING_LABEL
			// 
			this.LOADING_LABEL.BackColor = System.Drawing.Color.Transparent;
			this.LOADING_LABEL.Font = new System.Drawing.Font("나눔고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.LOADING_LABEL.Location = new System.Drawing.Point(0, 325);
			this.LOADING_LABEL.Name = "LOADING_LABEL";
			this.LOADING_LABEL.Size = new System.Drawing.Size(700, 20);
			this.LOADING_LABEL.TabIndex = 15;
			this.LOADING_LABEL.Text = "서버에서 정보를 불러오고 있습니다 ";
			this.LOADING_LABEL.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// DotAnimationTimer
			// 
			this.DotAnimationTimer.Tick += new System.EventHandler(this.DotAnimationTimer_Tick);
			// 
			// BGM_DOWNLOAD_LABEL
			// 
			this.BGM_DOWNLOAD_LABEL.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.BGM_DOWNLOAD_LABEL.AutoSize = true;
			this.BGM_DOWNLOAD_LABEL.BackColor = System.Drawing.Color.Transparent;
			this.BGM_DOWNLOAD_LABEL.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.BGM_DOWNLOAD_LABEL.Location = new System.Drawing.Point(50, 616);
			this.BGM_DOWNLOAD_LABEL.Name = "BGM_DOWNLOAD_LABEL";
			this.BGM_DOWNLOAD_LABEL.Size = new System.Drawing.Size(136, 15);
			this.BGM_DOWNLOAD_LABEL.TabIndex = 16;
			this.BGM_DOWNLOAD_LABEL.Text = "BGM(사운드) 다운로드";
			this.BGM_DOWNLOAD_LABEL.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// CREATE_VIEWER_LABEL
			// 
			this.CREATE_VIEWER_LABEL.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.CREATE_VIEWER_LABEL.AutoSize = true;
			this.CREATE_VIEWER_LABEL.BackColor = System.Drawing.Color.Transparent;
			this.CREATE_VIEWER_LABEL.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.CREATE_VIEWER_LABEL.Location = new System.Drawing.Point(233, 616);
			this.CREATE_VIEWER_LABEL.Name = "CREATE_VIEWER_LABEL";
			this.CREATE_VIEWER_LABEL.Size = new System.Drawing.Size(115, 15);
			this.CREATE_VIEWER_LABEL.TabIndex = 18;
			this.CREATE_VIEWER_LABEL.Text = "웹툰 뷰어 파일 생성";
			this.CREATE_VIEWER_LABEL.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// APP_TITLE_BAR
			// 
			this.APP_TITLE_BAR.BackColor = System.Drawing.Color.Transparent;
			this.APP_TITLE_BAR.EnglishText = "Download Option";
			this.APP_TITLE_BAR.KoreanText = "다운로드 옵션";
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
			// DOWNLOAD_BUTTON
			// 
			this.DOWNLOAD_BUTTON.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.DOWNLOAD_BUTTON.AnimationLerpP = 0.8F;
			this.DOWNLOAD_BUTTON.BackColor = System.Drawing.Color.Transparent;
			this.DOWNLOAD_BUTTON.ButtonText = "다운로드 시작!";
			this.DOWNLOAD_BUTTON.ButtonTextColor = System.Drawing.Color.White;
			this.DOWNLOAD_BUTTON.Cursor = System.Windows.Forms.Cursors.Hand;
			this.DOWNLOAD_BUTTON.EnterStateBackgroundColor = System.Drawing.Color.Red;
			this.DOWNLOAD_BUTTON.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.DOWNLOAD_BUTTON.Font = new System.Drawing.Font("나눔고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.DOWNLOAD_BUTTON.Location = new System.Drawing.Point(488, 588);
			this.DOWNLOAD_BUTTON.Name = "DOWNLOAD_BUTTON";
			this.DOWNLOAD_BUTTON.NormalStateBackgroundColor = System.Drawing.Color.Crimson;
			this.DOWNLOAD_BUTTON.Size = new System.Drawing.Size(200, 50);
			this.DOWNLOAD_BUTTON.TabIndex = 5;
			this.DOWNLOAD_BUTTON.TabStop = false;
			this.DOWNLOAD_BUTTON.Text = "다운로드 시작!";
			this.TOOL_TIP.SetToolTip(this.DOWNLOAD_BUTTON, "설정한 옵션으로 다운로드를 시작합니다.");
			this.DOWNLOAD_BUTTON.UseVisualStyleBackColor = false;
			this.DOWNLOAD_BUTTON.Click += new System.EventHandler(this.DOWNLOAD_BUTTON_Click);
			// 
			// QUALITY_OPTION_PANEL
			// 
			this.QUALITY_OPTION_PANEL.AutoScroll = true;
			this.QUALITY_OPTION_PANEL.Controls.Add(this.WARN_TOOLOW_LABEL);
			this.QUALITY_OPTION_PANEL.Controls.Add(this.QUALITY_EXAMPLE_NOT_AVAILABLE);
			this.QUALITY_OPTION_PANEL.Controls.Add(this.RANDOM_IMAGE_BUTTON);
			this.QUALITY_OPTION_PANEL.Controls.Add(this.QUALITY_EXAMPLE_TITLE);
			this.QUALITY_OPTION_PANEL.Controls.Add(this.label1);
			this.QUALITY_OPTION_PANEL.Controls.Add(this.QUALITY_EXAMPLE_IMAGE);
			this.QUALITY_OPTION_PANEL.Controls.Add(this.QUALITY_VALUE_HINT);
			this.QUALITY_OPTION_PANEL.Controls.Add(this.QUALITY_VALUE_BAR);
			this.QUALITY_OPTION_PANEL.Controls.Add(this.pictureBox1);
			this.QUALITY_OPTION_PANEL.Controls.Add(this.QUALITY_OPTION_TITLE);
			this.QUALITY_OPTION_PANEL.Location = new System.Drawing.Point(12, 394);
			this.QUALITY_OPTION_PANEL.Name = "QUALITY_OPTION_PANEL";
			this.QUALITY_OPTION_PANEL.Size = new System.Drawing.Size(676, 180);
			this.QUALITY_OPTION_PANEL.TabIndex = 20;
			this.QUALITY_OPTION_PANEL.Visible = false;
			this.QUALITY_OPTION_PANEL.Paint += new System.Windows.Forms.PaintEventHandler(this.QUALITY_OPTION_PANEL_Paint);
			// 
			// QUALITY_EXAMPLE_NOT_AVAILABLE
			// 
			this.QUALITY_EXAMPLE_NOT_AVAILABLE.AutoSize = true;
			this.QUALITY_EXAMPLE_NOT_AVAILABLE.BackColor = System.Drawing.Color.Transparent;
			this.QUALITY_EXAMPLE_NOT_AVAILABLE.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.QUALITY_EXAMPLE_NOT_AVAILABLE.Location = new System.Drawing.Point(399, 95);
			this.QUALITY_EXAMPLE_NOT_AVAILABLE.Name = "QUALITY_EXAMPLE_NOT_AVAILABLE";
			this.QUALITY_EXAMPLE_NOT_AVAILABLE.Size = new System.Drawing.Size(199, 14);
			this.QUALITY_EXAMPLE_NOT_AVAILABLE.TabIndex = 27;
			this.QUALITY_EXAMPLE_NOT_AVAILABLE.Text = "미리보기 이미지를 사용할 수 없습니다.";
			this.QUALITY_EXAMPLE_NOT_AVAILABLE.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// RANDOM_IMAGE_BUTTON
			// 
			this.RANDOM_IMAGE_BUTTON.BackColor = System.Drawing.Color.Transparent;
			this.RANDOM_IMAGE_BUTTON.Cursor = System.Windows.Forms.Cursors.Hand;
			this.RANDOM_IMAGE_BUTTON.Image = global::WebtoonDownloader_CapstoneProject.Properties.Resources.RANDOM;
			this.RANDOM_IMAGE_BUTTON.Location = new System.Drawing.Point(653, 4);
			this.RANDOM_IMAGE_BUTTON.Name = "RANDOM_IMAGE_BUTTON";
			this.RANDOM_IMAGE_BUTTON.Size = new System.Drawing.Size(20, 20);
			this.RANDOM_IMAGE_BUTTON.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.RANDOM_IMAGE_BUTTON.TabIndex = 26;
			this.RANDOM_IMAGE_BUTTON.TabStop = false;
			this.RANDOM_IMAGE_BUTTON.Click += new System.EventHandler(this.RANDOM_IMAGE_BUTTON_Click);
			// 
			// QUALITY_EXAMPLE_TITLE
			// 
			this.QUALITY_EXAMPLE_TITLE.AutoSize = true;
			this.QUALITY_EXAMPLE_TITLE.BackColor = System.Drawing.Color.Transparent;
			this.QUALITY_EXAMPLE_TITLE.Font = new System.Drawing.Font("나눔고딕", 8.249999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.QUALITY_EXAMPLE_TITLE.Location = new System.Drawing.Point(320, 7);
			this.QUALITY_EXAMPLE_TITLE.Name = "QUALITY_EXAMPLE_TITLE";
			this.QUALITY_EXAMPLE_TITLE.Size = new System.Drawing.Size(80, 13);
			this.QUALITY_EXAMPLE_TITLE.TabIndex = 25;
			this.QUALITY_EXAMPLE_TITLE.Text = "미리보기 이미지";
			this.QUALITY_EXAMPLE_TITLE.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label1
			// 
			this.label1.BackColor = System.Drawing.Color.Transparent;
			this.label1.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.label1.Location = new System.Drawing.Point(16, 105);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(295, 46);
			this.label1.TabIndex = 24;
			this.label1.Text = "품질이 높아지면 용량이 커지고 품질이 낮아지면 용량이 작아집니다\r\n품질 조정에 따라 최대 1/3 까지 용량을 줄일 수 있습니다.";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// QUALITY_EXAMPLE_IMAGE
			// 
			this.QUALITY_EXAMPLE_IMAGE.BackColor = System.Drawing.Color.Transparent;
			this.QUALITY_EXAMPLE_IMAGE.Image = global::WebtoonDownloader_CapstoneProject.Properties.Resources.QUALITY_SAMPLE01;
			this.QUALITY_EXAMPLE_IMAGE.Location = new System.Drawing.Point(323, 27);
			this.QUALITY_EXAMPLE_IMAGE.Name = "QUALITY_EXAMPLE_IMAGE";
			this.QUALITY_EXAMPLE_IMAGE.Size = new System.Drawing.Size(350, 150);
			this.QUALITY_EXAMPLE_IMAGE.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.QUALITY_EXAMPLE_IMAGE.TabIndex = 23;
			this.QUALITY_EXAMPLE_IMAGE.TabStop = false;
			this.QUALITY_EXAMPLE_IMAGE.Paint += new System.Windows.Forms.PaintEventHandler(this.QUALITY_EXAMPLE_IMAGE_Paint);
			// 
			// QUALITY_VALUE_HINT
			// 
			this.QUALITY_VALUE_HINT.BackColor = System.Drawing.Color.Transparent;
			this.QUALITY_VALUE_HINT.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.QUALITY_VALUE_HINT.Location = new System.Drawing.Point(211, 75);
			this.QUALITY_VALUE_HINT.Name = "QUALITY_VALUE_HINT";
			this.QUALITY_VALUE_HINT.Size = new System.Drawing.Size(86, 17);
			this.QUALITY_VALUE_HINT.TabIndex = 22;
			this.QUALITY_VALUE_HINT.Text = "매우 좋음";
			this.QUALITY_VALUE_HINT.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// QUALITY_VALUE_BAR
			// 
			this.QUALITY_VALUE_BAR.Location = new System.Drawing.Point(19, 73);
			this.QUALITY_VALUE_BAR.Maximum = 100;
			this.QUALITY_VALUE_BAR.Name = "QUALITY_VALUE_BAR";
			this.QUALITY_VALUE_BAR.Size = new System.Drawing.Size(191, 45);
			this.QUALITY_VALUE_BAR.TabIndex = 21;
			this.QUALITY_VALUE_BAR.TickStyle = System.Windows.Forms.TickStyle.None;
			this.QUALITY_VALUE_BAR.Value = 90;
			this.QUALITY_VALUE_BAR.ValueChanged += new System.EventHandler(this.QUALITY_VALUE_BAR_ValueChanged);
			// 
			// pictureBox1
			// 
			this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
			this.pictureBox1.Image = global::WebtoonDownloader_CapstoneProject.Properties.Resources.HD;
			this.pictureBox1.Location = new System.Drawing.Point(4, 2);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(40, 40);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox1.TabIndex = 20;
			this.pictureBox1.TabStop = false;
			// 
			// QUALITY_OPTION_TITLE
			// 
			this.QUALITY_OPTION_TITLE.AutoSize = true;
			this.QUALITY_OPTION_TITLE.BackColor = System.Drawing.Color.Transparent;
			this.QUALITY_OPTION_TITLE.Font = new System.Drawing.Font("나눔고딕", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.QUALITY_OPTION_TITLE.Location = new System.Drawing.Point(51, 14);
			this.QUALITY_OPTION_TITLE.Name = "QUALITY_OPTION_TITLE";
			this.QUALITY_OPTION_TITLE.Size = new System.Drawing.Size(82, 17);
			this.QUALITY_OPTION_TITLE.TabIndex = 15;
			this.QUALITY_OPTION_TITLE.Text = "이미지 품질";
			this.QUALITY_OPTION_TITLE.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// CREATE_VIEWER_CHECKBOX
			// 
			this.CREATE_VIEWER_CHECKBOX.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.CREATE_VIEWER_CHECKBOX.BackColor = System.Drawing.Color.Transparent;
			this.CREATE_VIEWER_CHECKBOX.Cursor = System.Windows.Forms.Cursors.Hand;
			this.CREATE_VIEWER_CHECKBOX.Image = ((System.Drawing.Image)(resources.GetObject("CREATE_VIEWER_CHECKBOX.Image")));
			this.CREATE_VIEWER_CHECKBOX.Location = new System.Drawing.Point(195, 608);
			this.CREATE_VIEWER_CHECKBOX.Name = "CREATE_VIEWER_CHECKBOX";
			this.CREATE_VIEWER_CHECKBOX.Size = new System.Drawing.Size(30, 30);
			this.CREATE_VIEWER_CHECKBOX.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.CREATE_VIEWER_CHECKBOX.Status = true;
			this.CREATE_VIEWER_CHECKBOX.TabIndex = 19;
			this.CREATE_VIEWER_CHECKBOX.TabStop = false;
			this.TOOL_TIP.SetToolTip(this.CREATE_VIEWER_CHECKBOX, "웹툰을 편하게 볼 수 있게 HTML(Hyper Text Markup Language) 파일을 생성합니다.");
			// 
			// BGM_DOWNLOAD_CHECKBOX
			// 
			this.BGM_DOWNLOAD_CHECKBOX.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.BGM_DOWNLOAD_CHECKBOX.BackColor = System.Drawing.Color.Transparent;
			this.BGM_DOWNLOAD_CHECKBOX.Cursor = System.Windows.Forms.Cursors.Hand;
			this.BGM_DOWNLOAD_CHECKBOX.Image = ((System.Drawing.Image)(resources.GetObject("BGM_DOWNLOAD_CHECKBOX.Image")));
			this.BGM_DOWNLOAD_CHECKBOX.Location = new System.Drawing.Point(12, 608);
			this.BGM_DOWNLOAD_CHECKBOX.Name = "BGM_DOWNLOAD_CHECKBOX";
			this.BGM_DOWNLOAD_CHECKBOX.Size = new System.Drawing.Size(30, 30);
			this.BGM_DOWNLOAD_CHECKBOX.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.BGM_DOWNLOAD_CHECKBOX.Status = true;
			this.BGM_DOWNLOAD_CHECKBOX.TabIndex = 17;
			this.BGM_DOWNLOAD_CHECKBOX.TabStop = false;
			this.TOOL_TIP.SetToolTip(this.BGM_DOWNLOAD_CHECKBOX, "웹툰 화에 포함된 BGM(사운드) 파일을 다운로드 합니다.");
			// 
			// WARN_TOOLOW_LABEL
			// 
			this.WARN_TOOLOW_LABEL.BackColor = System.Drawing.Color.Transparent;
			this.WARN_TOOLOW_LABEL.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.WARN_TOOLOW_LABEL.ForeColor = System.Drawing.Color.Red;
			this.WARN_TOOLOW_LABEL.Location = new System.Drawing.Point(16, 154);
			this.WARN_TOOLOW_LABEL.Name = "WARN_TOOLOW_LABEL";
			this.WARN_TOOLOW_LABEL.Size = new System.Drawing.Size(295, 22);
			this.WARN_TOOLOW_LABEL.TabIndex = 28;
			this.WARN_TOOLOW_LABEL.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// WebtoonDownloadOptionForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(700, 650);
			this.Controls.Add(this.QUALITY_OPTION_PANEL);
			this.Controls.Add(this.CREATE_VIEWER_CHECKBOX);
			this.Controls.Add(this.CREATE_VIEWER_LABEL);
			this.Controls.Add(this.BGM_DOWNLOAD_CHECKBOX);
			this.Controls.Add(this.BGM_DOWNLOAD_LABEL);
			this.Controls.Add(this.LOADING_LABEL);
			this.Controls.Add(this.APP_TITLE_BAR);
			this.Controls.Add(this.DOWNLOAD_BUTTON);
			this.Controls.Add(this.DOWNLOAD_OPTION_PANEL);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "WebtoonDownloadOptionForm";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "웹툰 다운로더";
			this.Load += new System.EventHandler(this.WebtoonDownloadOptionForm_Load);
			this.Shown += new System.EventHandler(this.WebtoonDownloadOptionForm_Shown);
			this.Paint += new System.Windows.Forms.PaintEventHandler(this.WebtoonDownloadOptionForm_Paint);
			this.DOWNLOAD_OPTION_PANEL.ResumeLayout(false);
			this.DOWNLOAD_OPTION_PANEL.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.DOWNLOAD_READY_IMAGE)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.END_THUMBNAIL_IMAGE)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.BEGIN_THUMBNAIL_IMAGE)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.WEBTOON_END_NUMBER)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.WEBTOON_BEGIN_NUMBER)).EndInit();
			this.QUALITY_OPTION_PANEL.ResumeLayout(false);
			this.QUALITY_OPTION_PANEL.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.RANDOM_IMAGE_BUTTON)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.QUALITY_EXAMPLE_IMAGE)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.QUALITY_VALUE_BAR)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.CREATE_VIEWER_CHECKBOX)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.BGM_DOWNLOAD_CHECKBOX)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private FlatButton DOWNLOAD_BUTTON;
		private APP_TITLE_BAR APP_TITLE_BAR;
		private System.Windows.Forms.Panel DOWNLOAD_OPTION_PANEL;
		private System.Windows.Forms.NumericUpDown WEBTOON_BEGIN_NUMBER;
		private System.Windows.Forms.NumericUpDown WEBTOON_END_NUMBER;
		private System.Windows.Forms.Label RIGHT_LABEL;
		private System.Windows.Forms.Label CENTER_LABEL;
		private System.Windows.Forms.Label DOWNLOAD_OPTION_TITLE;
		private System.Windows.Forms.PictureBox BEGIN_THUMBNAIL_IMAGE;
		private System.Windows.Forms.Label BEGIN_TITLE_LABEL;
		private System.Windows.Forms.PictureBox END_THUMBNAIL_IMAGE;
		private System.Windows.Forms.Label END_TITLE_LABEL;
		private System.Windows.Forms.Label LOADING_LABEL;
		private System.Windows.Forms.Label LEFT_LABEL;
		private System.Windows.Forms.Timer DotAnimationTimer;
		private FlatCheckBox BGM_DOWNLOAD_CHECKBOX;
		private System.Windows.Forms.Label BGM_DOWNLOAD_LABEL;
		private FlatCheckBox CREATE_VIEWER_CHECKBOX;
		private System.Windows.Forms.Label CREATE_VIEWER_LABEL;
		private System.Windows.Forms.PictureBox DOWNLOAD_READY_IMAGE;
		private System.Windows.Forms.Panel QUALITY_OPTION_PANEL;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Label QUALITY_OPTION_TITLE;
		private System.Windows.Forms.TrackBar QUALITY_VALUE_BAR;
		private System.Windows.Forms.Label QUALITY_VALUE_HINT;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.PictureBox QUALITY_EXAMPLE_IMAGE;
		private System.Windows.Forms.PictureBox RANDOM_IMAGE_BUTTON;
		private System.Windows.Forms.Label QUALITY_EXAMPLE_NOT_AVAILABLE;
		private System.Windows.Forms.Label QUALITY_EXAMPLE_TITLE;
		private System.Windows.Forms.ToolTip TOOL_TIP;
		private System.Windows.Forms.Label WARN_TOOLOW_LABEL;
	}
}