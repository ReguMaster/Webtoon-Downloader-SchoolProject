namespace WebtoonDownloader_CapstoneProject.UI
{
	partial class APP_TITLE_BAR
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

		#region 구성 요소 디자이너에서 생성한 코드

		/// <summary> 
		/// 디자이너 지원에 필요한 메서드입니다. 
		/// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
		/// </summary>
		private void InitializeComponent( )
		{
			this.MINIMIZE_BUTTON = new System.Windows.Forms.PictureBox();
			this.CLOSE_BUTTON = new System.Windows.Forms.PictureBox();
			this.APP_TITLE_ENG = new WebtoonDownloader_CapstoneProject.UI.CustomLabel();
			this.APP_TITLE_KO = new WebtoonDownloader_CapstoneProject.UI.CustomLabel();
			((System.ComponentModel.ISupportInitialize)(this.MINIMIZE_BUTTON)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.CLOSE_BUTTON)).BeginInit();
			this.SuspendLayout();
			// 
			// MINIMIZE_BUTTON
			// 
			this.MINIMIZE_BUTTON.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.MINIMIZE_BUTTON.BackColor = System.Drawing.Color.Transparent;
			this.MINIMIZE_BUTTON.Cursor = System.Windows.Forms.Cursors.Hand;
			this.MINIMIZE_BUTTON.Image = global::WebtoonDownloader_CapstoneProject.Properties.Resources.MINIMIZE;
			this.MINIMIZE_BUTTON.Location = new System.Drawing.Point(690, 18);
			this.MINIMIZE_BUTTON.Name = "MINIMIZE_BUTTON";
			this.MINIMIZE_BUTTON.Size = new System.Drawing.Size(35, 35);
			this.MINIMIZE_BUTTON.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.MINIMIZE_BUTTON.TabIndex = 3;
			this.MINIMIZE_BUTTON.TabStop = false;
			this.MINIMIZE_BUTTON.Click += new System.EventHandler(this.MINIMIZE_BUTTON_Click);
			// 
			// CLOSE_BUTTON
			// 
			this.CLOSE_BUTTON.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.CLOSE_BUTTON.BackColor = System.Drawing.Color.Transparent;
			this.CLOSE_BUTTON.Cursor = System.Windows.Forms.Cursors.Hand;
			this.CLOSE_BUTTON.Image = global::WebtoonDownloader_CapstoneProject.Properties.Resources.CLOSE;
			this.CLOSE_BUTTON.Location = new System.Drawing.Point(745, 18);
			this.CLOSE_BUTTON.Name = "CLOSE_BUTTON";
			this.CLOSE_BUTTON.Size = new System.Drawing.Size(35, 35);
			this.CLOSE_BUTTON.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.CLOSE_BUTTON.TabIndex = 2;
			this.CLOSE_BUTTON.TabStop = false;
			this.CLOSE_BUTTON.Click += new System.EventHandler(this.CLOSE_BUTTON_Click);
			// 
			// APP_TITLE_ENG
			// 
			this.APP_TITLE_ENG.AutoSize = true;
			this.APP_TITLE_ENG.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.APP_TITLE_ENG.Location = new System.Drawing.Point(15, 42);
			this.APP_TITLE_ENG.Name = "APP_TITLE_ENG";
			this.APP_TITLE_ENG.Size = new System.Drawing.Size(65, 15);
			this.APP_TITLE_ENG.TabIndex = 1;
			this.APP_TITLE_ENG.Text = "SUB TITLE";
			this.APP_TITLE_ENG.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.APP_TITLE_ENG.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
			// 
			// APP_TITLE_KO
			// 
			this.APP_TITLE_KO.AutoSize = true;
			this.APP_TITLE_KO.BackColor = System.Drawing.Color.Transparent;
			this.APP_TITLE_KO.Font = new System.Drawing.Font("나눔고딕", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.APP_TITLE_KO.Location = new System.Drawing.Point(12, 12);
			this.APP_TITLE_KO.Name = "APP_TITLE_KO";
			this.APP_TITLE_KO.Size = new System.Drawing.Size(70, 28);
			this.APP_TITLE_KO.TabIndex = 0;
			this.APP_TITLE_KO.Text = "TITLE";
			this.APP_TITLE_KO.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.APP_TITLE_KO.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
			// 
			// APP_TITLE_BAR
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Transparent;
			this.Controls.Add(this.MINIMIZE_BUTTON);
			this.Controls.Add(this.CLOSE_BUTTON);
			this.Controls.Add(this.APP_TITLE_ENG);
			this.Controls.Add(this.APP_TITLE_KO);
			this.Name = "APP_TITLE_BAR";
			this.Size = new System.Drawing.Size(800, 70);
			this.Load += new System.EventHandler(this.APP_TITLE_BAR_Load);
			this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.APP_TITLE_BAR_MouseDown);
			this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.APP_TITLE_BAR_MouseMove);
			((System.ComponentModel.ISupportInitialize)(this.MINIMIZE_BUTTON)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.CLOSE_BUTTON)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private CustomLabel APP_TITLE_KO;
		private CustomLabel APP_TITLE_ENG;
		private System.Windows.Forms.PictureBox CLOSE_BUTTON;
		private System.Windows.Forms.PictureBox MINIMIZE_BUTTON;
	}
}
