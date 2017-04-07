namespace WebtoonDownloader_CapstoneProject
{
	partial class MainForm
	{
		/// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 사용 중인 모든 리소스를 정리합니다.
		/// </summary>
		/// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
		protected override void Dispose( bool disposing )
		{
			if ( disposing && ( components != null ) )
			{
				components.Dispose( );
			}
			base.Dispose( disposing );
		}

		#region Windows Form 디자이너에서 생성한 코드

		/// <summary>
		/// 디자이너 지원에 필요한 메서드입니다. 
		/// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
		/// </summary>
		private void InitializeComponent( )
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.APP_TITLE_BAR = new WebtoonDownloader_CapstoneProject.UI.APP_TITLE_BAR();
			this.WEBTOON_SELECT_BUTTON = new WebtoonDownloader_CapstoneProject.UI.FlatButton();
			this.VERSION_LABEL = new System.Windows.Forms.Label();
			this.BACKGROUND_SPLASH = new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize)(this.BACKGROUND_SPLASH)).BeginInit();
			this.SuspendLayout();
			// 
			// APP_TITLE_BAR
			// 
			this.APP_TITLE_BAR.BackColor = System.Drawing.Color.Transparent;
			this.APP_TITLE_BAR.EnglishText = "Webtoon Downloader";
			this.APP_TITLE_BAR.KoreanText = "웹툰 다운로더";
			this.APP_TITLE_BAR.Location = new System.Drawing.Point(0, 0);
			this.APP_TITLE_BAR.Name = "APP_TITLE_BAR";
			this.APP_TITLE_BAR.ShowClose = true;
			this.APP_TITLE_BAR.ShowMinimize = true;
			this.APP_TITLE_BAR.Size = new System.Drawing.Size(650, 70);
			this.APP_TITLE_BAR.TabIndex = 0;
			this.APP_TITLE_BAR.TextColor = System.Drawing.Color.Black;
			this.APP_TITLE_BAR.BeginClose += new System.Func<bool>(this.APP_TITLE_BAR_BeginClose);
			// 
			// WEBTOON_SELECT_BUTTON
			// 
			this.WEBTOON_SELECT_BUTTON.AnimationLerpP = 0.8F;
			this.WEBTOON_SELECT_BUTTON.BackColor = System.Drawing.Color.Transparent;
			this.WEBTOON_SELECT_BUTTON.ButtonText = "웹툰 선택";
			this.WEBTOON_SELECT_BUTTON.ButtonTextColor = System.Drawing.Color.Black;
			this.WEBTOON_SELECT_BUTTON.Cursor = System.Windows.Forms.Cursors.Hand;
			this.WEBTOON_SELECT_BUTTON.EnterStateBackgroundColor = System.Drawing.Color.Gainsboro;
			this.WEBTOON_SELECT_BUTTON.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.WEBTOON_SELECT_BUTTON.Font = new System.Drawing.Font("나눔고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.WEBTOON_SELECT_BUTTON.Location = new System.Drawing.Point(438, 338);
			this.WEBTOON_SELECT_BUTTON.Name = "WEBTOON_SELECT_BUTTON";
			this.WEBTOON_SELECT_BUTTON.NormalStateBackgroundColor = System.Drawing.Color.WhiteSmoke;
			this.WEBTOON_SELECT_BUTTON.Size = new System.Drawing.Size(200, 50);
			this.WEBTOON_SELECT_BUTTON.TabIndex = 1;
			this.WEBTOON_SELECT_BUTTON.Text = "웹툰 선택";
			this.WEBTOON_SELECT_BUTTON.UseVisualStyleBackColor = false;
			this.WEBTOON_SELECT_BUTTON.Click += new System.EventHandler(this.WEBTOON_SELECT_BUTTON_Click);
			// 
			// VERSION_LABEL
			// 
			this.VERSION_LABEL.AutoSize = true;
			this.VERSION_LABEL.BackColor = System.Drawing.Color.Transparent;
			this.VERSION_LABEL.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.VERSION_LABEL.Location = new System.Drawing.Point(12, 373);
			this.VERSION_LABEL.Name = "VERSION_LABEL";
			this.VERSION_LABEL.Size = new System.Drawing.Size(72, 14);
			this.VERSION_LABEL.TabIndex = 2;
			this.VERSION_LABEL.Text = "버전 1.0.0.0";
			this.VERSION_LABEL.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// BACKGROUND_SPLASH
			// 
			this.BACKGROUND_SPLASH.BackColor = System.Drawing.Color.Transparent;
			this.BACKGROUND_SPLASH.Image = global::WebtoonDownloader_CapstoneProject.Properties.Resources.BACKGROUND_IMAGE;
			this.BACKGROUND_SPLASH.Location = new System.Drawing.Point(15, 70);
			this.BACKGROUND_SPLASH.Name = "BACKGROUND_SPLASH";
			this.BACKGROUND_SPLASH.Size = new System.Drawing.Size(350, 300);
			this.BACKGROUND_SPLASH.TabIndex = 3;
			this.BACKGROUND_SPLASH.TabStop = false;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(650, 400);
			this.Controls.Add(this.VERSION_LABEL);
			this.Controls.Add(this.WEBTOON_SELECT_BUTTON);
			this.Controls.Add(this.APP_TITLE_BAR);
			this.Controls.Add(this.BACKGROUND_SPLASH);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.MainForm_Load);
			this.Paint += new System.Windows.Forms.PaintEventHandler(this.MainForm_Paint);
			((System.ComponentModel.ISupportInitialize)(this.BACKGROUND_SPLASH)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private UI.APP_TITLE_BAR APP_TITLE_BAR;
		private UI.FlatButton WEBTOON_SELECT_BUTTON;
		private System.Windows.Forms.Label VERSION_LABEL;
		private System.Windows.Forms.PictureBox BACKGROUND_SPLASH;
	}
}