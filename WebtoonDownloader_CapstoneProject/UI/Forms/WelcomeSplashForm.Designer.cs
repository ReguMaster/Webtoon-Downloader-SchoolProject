namespace WebtoonDownloader_CapstoneProject.UI.Forms
{
	partial class WelcomeSplashForm
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
			this.SPLASH_BOTTOM_IMAGE = new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize)(this.SPLASH_BOTTOM_IMAGE)).BeginInit();
			this.SuspendLayout();
			// 
			// SPLASH_BOTTOM_IMAGE
			// 
			this.SPLASH_BOTTOM_IMAGE.BackColor = System.Drawing.Color.Transparent;
			this.SPLASH_BOTTOM_IMAGE.Image = global::WebtoonDownloader_CapstoneProject.Properties.Resources.WELCOME_SPLASH_BOTTOM;
			this.SPLASH_BOTTOM_IMAGE.Location = new System.Drawing.Point(0, 85);
			this.SPLASH_BOTTOM_IMAGE.Name = "SPLASH_BOTTOM_IMAGE";
			this.SPLASH_BOTTOM_IMAGE.Size = new System.Drawing.Size(612, 225);
			this.SPLASH_BOTTOM_IMAGE.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.SPLASH_BOTTOM_IMAGE.TabIndex = 0;
			this.SPLASH_BOTTOM_IMAGE.TabStop = false;
			// 
			// WelcomeSplashForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.BackgroundImage = global::WebtoonDownloader_CapstoneProject.Properties.Resources.WELCOME_SPLASH_TOP;
			this.ClientSize = new System.Drawing.Size(612, 312);
			this.Controls.Add(this.SPLASH_BOTTOM_IMAGE);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "WelcomeSplashForm";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "웹툰 다운로더";
			this.Load += new System.EventHandler(this.WelcomeSplashForm_Load);
			((System.ComponentModel.ISupportInitialize)(this.SPLASH_BOTTOM_IMAGE)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.PictureBox SPLASH_BOTTOM_IMAGE;
	}
}