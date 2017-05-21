namespace WebtoonDownloader_CapstoneProject.UI.Forms
{
	partial class ProgramInformationForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProgramInformationForm));
			this.TITLE_LABEL = new System.Windows.Forms.Label();
			this.APP_TITLE_BAR = new WebtoonDownloader_CapstoneProject.UI.APP_TITLE_BAR();
			this.TITLE_LABEL_ENG = new System.Windows.Forms.Label();
			this.VERSION_LABEL = new System.Windows.Forms.Label();
			this.ICON_ICON = new System.Windows.Forms.PictureBox();
			this.GIT_OPEN_BUTTON = new WebtoonDownloader_CapstoneProject.UI.FlatButton();
			this.COPYRIGHT_LABEL = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.ICON_ICON)).BeginInit();
			this.SuspendLayout();
			// 
			// TITLE_LABEL
			// 
			this.TITLE_LABEL.AutoSize = true;
			this.TITLE_LABEL.BackColor = System.Drawing.Color.Transparent;
			this.TITLE_LABEL.Font = new System.Drawing.Font("나눔고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.TITLE_LABEL.Location = new System.Drawing.Point(136, 76);
			this.TITLE_LABEL.Name = "TITLE_LABEL";
			this.TITLE_LABEL.Size = new System.Drawing.Size(103, 19);
			this.TITLE_LABEL.TabIndex = 12;
			this.TITLE_LABEL.Text = "웹툰 다운로더";
			this.TITLE_LABEL.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// APP_TITLE_BAR
			// 
			this.APP_TITLE_BAR.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.APP_TITLE_BAR.BackColor = System.Drawing.Color.Transparent;
			this.APP_TITLE_BAR.EnglishText = "Program Information";
			this.APP_TITLE_BAR.KoreanText = "프로그램 정보";
			this.APP_TITLE_BAR.Location = new System.Drawing.Point(0, 0);
			this.APP_TITLE_BAR.Name = "APP_TITLE_BAR";
			this.APP_TITLE_BAR.ShowClose = true;
			this.APP_TITLE_BAR.ShowHelp = false;
			this.APP_TITLE_BAR.ShowMinimize = false;
			this.APP_TITLE_BAR.Size = new System.Drawing.Size(392, 70);
			this.APP_TITLE_BAR.TabIndex = 6;
			this.APP_TITLE_BAR.TextColor = System.Drawing.Color.Black;
			// 
			// TITLE_LABEL_ENG
			// 
			this.TITLE_LABEL_ENG.AutoSize = true;
			this.TITLE_LABEL_ENG.BackColor = System.Drawing.Color.Transparent;
			this.TITLE_LABEL_ENG.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.TITLE_LABEL_ENG.Location = new System.Drawing.Point(137, 100);
			this.TITLE_LABEL_ENG.Name = "TITLE_LABEL_ENG";
			this.TITLE_LABEL_ENG.Size = new System.Drawing.Size(142, 15);
			this.TITLE_LABEL_ENG.TabIndex = 13;
			this.TITLE_LABEL_ENG.Text = "Webtoon Downloader";
			this.TITLE_LABEL_ENG.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// VERSION_LABEL
			// 
			this.VERSION_LABEL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.VERSION_LABEL.BackColor = System.Drawing.Color.Transparent;
			this.VERSION_LABEL.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.VERSION_LABEL.Location = new System.Drawing.Point(180, 203);
			this.VERSION_LABEL.Name = "VERSION_LABEL";
			this.VERSION_LABEL.Size = new System.Drawing.Size(200, 15);
			this.VERSION_LABEL.TabIndex = 14;
			this.VERSION_LABEL.Text = "버전 1.0.0.0";
			this.VERSION_LABEL.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// ICON_ICON
			// 
			this.ICON_ICON.BackColor = System.Drawing.Color.Transparent;
			this.ICON_ICON.Image = global::WebtoonDownloader_CapstoneProject.Properties.Resources.APP_ICON_v2_100x100;
			this.ICON_ICON.Location = new System.Drawing.Point(20, 76);
			this.ICON_ICON.Name = "ICON_ICON";
			this.ICON_ICON.Size = new System.Drawing.Size(100, 100);
			this.ICON_ICON.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.ICON_ICON.TabIndex = 19;
			this.ICON_ICON.TabStop = false;
			// 
			// GIT_OPEN_BUTTON
			// 
			this.GIT_OPEN_BUTTON.AnimationLerpP = 0.8F;
			this.GIT_OPEN_BUTTON.BackColor = System.Drawing.Color.Transparent;
			this.GIT_OPEN_BUTTON.ButtonText = "Git 리포지토리";
			this.GIT_OPEN_BUTTON.ButtonTextColor = System.Drawing.Color.Black;
			this.GIT_OPEN_BUTTON.Cursor = System.Windows.Forms.Cursors.Hand;
			this.GIT_OPEN_BUTTON.EnterStateBackgroundColor = System.Drawing.Color.Gainsboro;
			this.GIT_OPEN_BUTTON.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.GIT_OPEN_BUTTON.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.GIT_OPEN_BUTTON.Location = new System.Drawing.Point(20, 187);
			this.GIT_OPEN_BUTTON.Name = "GIT_OPEN_BUTTON";
			this.GIT_OPEN_BUTTON.NormalStateBackgroundColor = System.Drawing.Color.WhiteSmoke;
			this.GIT_OPEN_BUTTON.Size = new System.Drawing.Size(100, 31);
			this.GIT_OPEN_BUTTON.TabIndex = 20;
			this.GIT_OPEN_BUTTON.TabStop = false;
			this.GIT_OPEN_BUTTON.Text = "Git 리포지토리";
			this.GIT_OPEN_BUTTON.UseVisualStyleBackColor = false;
			this.GIT_OPEN_BUTTON.Click += new System.EventHandler(this.GIT_OPEN_BUTTON_Click);
			// 
			// COPYRIGHT_LABEL
			// 
			this.COPYRIGHT_LABEL.AutoSize = true;
			this.COPYRIGHT_LABEL.BackColor = System.Drawing.Color.Transparent;
			this.COPYRIGHT_LABEL.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.COPYRIGHT_LABEL.Location = new System.Drawing.Point(137, 162);
			this.COPYRIGHT_LABEL.Name = "COPYRIGHT_LABEL";
			this.COPYRIGHT_LABEL.Size = new System.Drawing.Size(130, 14);
			this.COPYRIGHT_LABEL.TabIndex = 21;
			this.COPYRIGHT_LABEL.Text = "© \'4조 Inventive\' 2017";
			this.COPYRIGHT_LABEL.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// ProgramInformationForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(392, 227);
			this.Controls.Add(this.COPYRIGHT_LABEL);
			this.Controls.Add(this.GIT_OPEN_BUTTON);
			this.Controls.Add(this.ICON_ICON);
			this.Controls.Add(this.VERSION_LABEL);
			this.Controls.Add(this.TITLE_LABEL_ENG);
			this.Controls.Add(this.TITLE_LABEL);
			this.Controls.Add(this.APP_TITLE_BAR);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "ProgramInformationForm";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "웹툰 다운로더";
			this.Load += new System.EventHandler(this.ProgramInformationForm_Load);
			this.Paint += new System.Windows.Forms.PaintEventHandler(this.ProgramInformationForm_Paint);
			((System.ComponentModel.ISupportInitialize)(this.ICON_ICON)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private APP_TITLE_BAR APP_TITLE_BAR;
		private System.Windows.Forms.Label TITLE_LABEL;
		private System.Windows.Forms.Label TITLE_LABEL_ENG;
		private System.Windows.Forms.Label VERSION_LABEL;
		private System.Windows.Forms.PictureBox ICON_ICON;
		private FlatButton GIT_OPEN_BUTTON;
		private System.Windows.Forms.Label COPYRIGHT_LABEL;
	}
}