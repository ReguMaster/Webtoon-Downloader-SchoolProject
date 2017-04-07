namespace WebtoonDownloader_CapstoneProject.UI.Forms
{
	partial class NotifyBoxForm
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
			this.MESSAGE_LABEL = new System.Windows.Forms.Label();
			this.OK_BUTTON = new WebtoonDownloader_CapstoneProject.UI.FlatButton();
			this.APP_TITLE_BAR = new WebtoonDownloader_CapstoneProject.UI.APP_TITLE_BAR();
			this.YES_BUTTON = new WebtoonDownloader_CapstoneProject.UI.FlatButton();
			this.NO_BUTTON = new WebtoonDownloader_CapstoneProject.UI.FlatButton();
			this.SuspendLayout();
			// 
			// MESSAGE_LABEL
			// 
			this.MESSAGE_LABEL.BackColor = System.Drawing.Color.Transparent;
			this.MESSAGE_LABEL.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.MESSAGE_LABEL.Location = new System.Drawing.Point(12, 73);
			this.MESSAGE_LABEL.Name = "MESSAGE_LABEL";
			this.MESSAGE_LABEL.Size = new System.Drawing.Size(576, 132);
			this.MESSAGE_LABEL.TabIndex = 1;
			this.MESSAGE_LABEL.Text = "MESSAGE";
			this.MESSAGE_LABEL.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// OK_BUTTON
			// 
			this.OK_BUTTON.AnimationLerpP = 0.8F;
			this.OK_BUTTON.BackColor = System.Drawing.Color.Transparent;
			this.OK_BUTTON.ButtonText = "확인";
			this.OK_BUTTON.ButtonTextColor = System.Drawing.Color.Black;
			this.OK_BUTTON.Cursor = System.Windows.Forms.Cursors.Hand;
			this.OK_BUTTON.EnterStateBackgroundColor = System.Drawing.Color.Gainsboro;
			this.OK_BUTTON.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.OK_BUTTON.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.OK_BUTTON.Location = new System.Drawing.Point(388, 208);
			this.OK_BUTTON.Name = "OK_BUTTON";
			this.OK_BUTTON.NormalStateBackgroundColor = System.Drawing.Color.WhiteSmoke;
			this.OK_BUTTON.Size = new System.Drawing.Size(200, 30);
			this.OK_BUTTON.TabIndex = 3;
			this.OK_BUTTON.Text = "확인";
			this.OK_BUTTON.UseVisualStyleBackColor = false;
			this.OK_BUTTON.Click += new System.EventHandler(this.OK_BUTTON_Click);
			// 
			// APP_TITLE_BAR
			// 
			this.APP_TITLE_BAR.BackColor = System.Drawing.Color.Gray;
			this.APP_TITLE_BAR.EnglishText = "Warning";
			this.APP_TITLE_BAR.KoreanText = "경고";
			this.APP_TITLE_BAR.Location = new System.Drawing.Point(0, 0);
			this.APP_TITLE_BAR.Name = "APP_TITLE_BAR";
			this.APP_TITLE_BAR.ShowClose = false;
			this.APP_TITLE_BAR.ShowMinimize = false;
			this.APP_TITLE_BAR.Size = new System.Drawing.Size(600, 70);
			this.APP_TITLE_BAR.TabIndex = 0;
			this.APP_TITLE_BAR.TextColor = System.Drawing.Color.White;
			// 
			// YES_BUTTON
			// 
			this.YES_BUTTON.AnimationLerpP = 0.8F;
			this.YES_BUTTON.BackColor = System.Drawing.Color.Transparent;
			this.YES_BUTTON.ButtonText = "네";
			this.YES_BUTTON.ButtonTextColor = System.Drawing.Color.Black;
			this.YES_BUTTON.Cursor = System.Windows.Forms.Cursors.Hand;
			this.YES_BUTTON.EnterStateBackgroundColor = System.Drawing.Color.Gainsboro;
			this.YES_BUTTON.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.YES_BUTTON.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.YES_BUTTON.Location = new System.Drawing.Point(388, 208);
			this.YES_BUTTON.Name = "YES_BUTTON";
			this.YES_BUTTON.NormalStateBackgroundColor = System.Drawing.Color.WhiteSmoke;
			this.YES_BUTTON.Size = new System.Drawing.Size(200, 30);
			this.YES_BUTTON.TabIndex = 4;
			this.YES_BUTTON.Text = "네";
			this.YES_BUTTON.UseVisualStyleBackColor = false;
			this.YES_BUTTON.Click += new System.EventHandler(this.YES_BUTTON_Click);
			// 
			// NO_BUTTON
			// 
			this.NO_BUTTON.AnimationLerpP = 0.8F;
			this.NO_BUTTON.BackColor = System.Drawing.Color.Transparent;
			this.NO_BUTTON.ButtonText = "아니오";
			this.NO_BUTTON.ButtonTextColor = System.Drawing.Color.Black;
			this.NO_BUTTON.Cursor = System.Windows.Forms.Cursors.Hand;
			this.NO_BUTTON.EnterStateBackgroundColor = System.Drawing.Color.Gainsboro;
			this.NO_BUTTON.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.NO_BUTTON.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.NO_BUTTON.Location = new System.Drawing.Point(262, 208);
			this.NO_BUTTON.Name = "NO_BUTTON";
			this.NO_BUTTON.NormalStateBackgroundColor = System.Drawing.Color.WhiteSmoke;
			this.NO_BUTTON.Size = new System.Drawing.Size(120, 30);
			this.NO_BUTTON.TabIndex = 5;
			this.NO_BUTTON.Text = "아니오";
			this.NO_BUTTON.UseVisualStyleBackColor = false;
			this.NO_BUTTON.Click += new System.EventHandler(this.NO_BUTTON_Click);
			// 
			// NotifyBoxForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(600, 250);
			this.Controls.Add(this.NO_BUTTON);
			this.Controls.Add(this.YES_BUTTON);
			this.Controls.Add(this.OK_BUTTON);
			this.Controls.Add(this.MESSAGE_LABEL);
			this.Controls.Add(this.APP_TITLE_BAR);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "NotifyBoxForm";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "NotifyBoxForm";
			this.Load += new System.EventHandler(this.NotifyBoxForm_Load);
			this.Paint += new System.Windows.Forms.PaintEventHandler(this.NotifyBoxForm_Paint);
			this.ResumeLayout(false);

		}

		#endregion

		private APP_TITLE_BAR APP_TITLE_BAR;
		private System.Windows.Forms.Label MESSAGE_LABEL;
		private FlatButton OK_BUTTON;
		private FlatButton YES_BUTTON;
		private FlatButton NO_BUTTON;
	}
}