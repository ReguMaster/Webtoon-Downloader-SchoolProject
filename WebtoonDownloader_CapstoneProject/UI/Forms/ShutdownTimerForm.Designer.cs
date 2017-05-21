namespace WebtoonDownloader_CapstoneProject.UI.Forms
{
	partial class ShutdownTimerForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ShutdownTimerForm));
			this.CANCEL_SYSTEM_SHUTDOWN_BUTTON = new WebtoonDownloader_CapstoneProject.UI.FlatButton();
			this.COUNTDOWN_LABEL = new System.Windows.Forms.Label();
			this.CountDownTimer = new System.Windows.Forms.Timer(this.components);
			this.COUNTDOWN_WARNING_IMAGE = new System.Windows.Forms.PictureBox();
			this.TOOL_TIP = new System.Windows.Forms.ToolTip(this.components);
			((System.ComponentModel.ISupportInitialize)(this.COUNTDOWN_WARNING_IMAGE)).BeginInit();
			this.SuspendLayout();
			// 
			// CANCEL_SYSTEM_SHUTDOWN_BUTTON
			// 
			this.CANCEL_SYSTEM_SHUTDOWN_BUTTON.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.CANCEL_SYSTEM_SHUTDOWN_BUTTON.AnimationLerpP = 0.8F;
			this.CANCEL_SYSTEM_SHUTDOWN_BUTTON.BackColor = System.Drawing.Color.Transparent;
			this.CANCEL_SYSTEM_SHUTDOWN_BUTTON.ButtonText = "시스템 종료 취소";
			this.CANCEL_SYSTEM_SHUTDOWN_BUTTON.ButtonTextColor = System.Drawing.Color.White;
			this.CANCEL_SYSTEM_SHUTDOWN_BUTTON.Cursor = System.Windows.Forms.Cursors.Hand;
			this.CANCEL_SYSTEM_SHUTDOWN_BUTTON.EnterStateBackgroundColor = System.Drawing.Color.Red;
			this.CANCEL_SYSTEM_SHUTDOWN_BUTTON.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.CANCEL_SYSTEM_SHUTDOWN_BUTTON.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.CANCEL_SYSTEM_SHUTDOWN_BUTTON.Location = new System.Drawing.Point(206, 129);
			this.CANCEL_SYSTEM_SHUTDOWN_BUTTON.Name = "CANCEL_SYSTEM_SHUTDOWN_BUTTON";
			this.CANCEL_SYSTEM_SHUTDOWN_BUTTON.NormalStateBackgroundColor = System.Drawing.Color.Crimson;
			this.CANCEL_SYSTEM_SHUTDOWN_BUTTON.Size = new System.Drawing.Size(200, 35);
			this.CANCEL_SYSTEM_SHUTDOWN_BUTTON.TabIndex = 8;
			this.CANCEL_SYSTEM_SHUTDOWN_BUTTON.Text = "시스템 종료 취소";
			this.TOOL_TIP.SetToolTip(this.CANCEL_SYSTEM_SHUTDOWN_BUTTON, "시스템 종료를 취소합니다.");
			this.CANCEL_SYSTEM_SHUTDOWN_BUTTON.UseVisualStyleBackColor = false;
			this.CANCEL_SYSTEM_SHUTDOWN_BUTTON.Click += new System.EventHandler(this.CANCEL_SYSTEM_SHUTDOWN_BUTTON_Click);
			// 
			// COUNTDOWN_LABEL
			// 
			this.COUNTDOWN_LABEL.BackColor = System.Drawing.Color.Transparent;
			this.COUNTDOWN_LABEL.Font = new System.Drawing.Font("나눔고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.COUNTDOWN_LABEL.Location = new System.Drawing.Point(0, 80);
			this.COUNTDOWN_LABEL.Name = "COUNTDOWN_LABEL";
			this.COUNTDOWN_LABEL.Size = new System.Drawing.Size(612, 20);
			this.COUNTDOWN_LABEL.TabIndex = 11;
			this.COUNTDOWN_LABEL.Text = "웹툰을 모두 다운로드 했습니다, 30초 후 시스템이 종료됩니다.";
			this.COUNTDOWN_LABEL.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// CountDownTimer
			// 
			this.CountDownTimer.Interval = 1000;
			this.CountDownTimer.Tick += new System.EventHandler(this.CountDownTimer_Tick);
			// 
			// COUNTDOWN_WARNING_IMAGE
			// 
			this.COUNTDOWN_WARNING_IMAGE.BackColor = System.Drawing.Color.Transparent;
			this.COUNTDOWN_WARNING_IMAGE.Image = global::WebtoonDownloader_CapstoneProject.Properties.Resources.SYSTEM_SHUTDOWN_WARNING;
			this.COUNTDOWN_WARNING_IMAGE.Location = new System.Drawing.Point(281, 10);
			this.COUNTDOWN_WARNING_IMAGE.Name = "COUNTDOWN_WARNING_IMAGE";
			this.COUNTDOWN_WARNING_IMAGE.Size = new System.Drawing.Size(50, 50);
			this.COUNTDOWN_WARNING_IMAGE.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.COUNTDOWN_WARNING_IMAGE.TabIndex = 21;
			this.COUNTDOWN_WARNING_IMAGE.TabStop = false;
			// 
			// ShutdownTimerForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(612, 176);
			this.Controls.Add(this.COUNTDOWN_WARNING_IMAGE);
			this.Controls.Add(this.COUNTDOWN_LABEL);
			this.Controls.Add(this.CANCEL_SYSTEM_SHUTDOWN_BUTTON);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "ShutdownTimerForm";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "웹툰 다운로더";
			this.TopMost = true;
			this.Shown += new System.EventHandler(this.ShutdownTimerForm_Shown);
			((System.ComponentModel.ISupportInitialize)(this.COUNTDOWN_WARNING_IMAGE)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private FlatButton CANCEL_SYSTEM_SHUTDOWN_BUTTON;
		private System.Windows.Forms.Label COUNTDOWN_LABEL;
		private System.Windows.Forms.Timer CountDownTimer;
		private System.Windows.Forms.PictureBox COUNTDOWN_WARNING_IMAGE;
		private System.Windows.Forms.ToolTip TOOL_TIP;
	}
}