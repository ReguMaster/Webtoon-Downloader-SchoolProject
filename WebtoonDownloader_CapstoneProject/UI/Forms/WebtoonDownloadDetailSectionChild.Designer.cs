namespace WebtoonDownloader_CapstoneProject.UI.Forms
{
	partial class WebtoonDownloadDetailSectionChild
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
			this.NUM_LABEL = new System.Windows.Forms.Label();
			this.THUMBNAIL_ICON = new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize)(this.THUMBNAIL_ICON)).BeginInit();
			this.SuspendLayout();
			// 
			// NUM_LABEL
			// 
			this.NUM_LABEL.BackColor = System.Drawing.Color.Transparent;
			this.NUM_LABEL.Font = new System.Drawing.Font("나눔고딕", 8.249999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.NUM_LABEL.ForeColor = System.Drawing.Color.Black;
			this.NUM_LABEL.Location = new System.Drawing.Point(0, 45);
			this.NUM_LABEL.Name = "NUM_LABEL";
			this.NUM_LABEL.Size = new System.Drawing.Size(35, 30);
			this.NUM_LABEL.TabIndex = 1;
			this.NUM_LABEL.Text = "0";
			this.NUM_LABEL.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.NUM_LABEL.MouseDown += new System.Windows.Forms.MouseEventHandler(this.WebtoonDownloadDetailSectionChild_MouseDown);
			this.NUM_LABEL.MouseEnter += new System.EventHandler(this.WebtoonDownloadDetailSectionChild_MouseEnter);
			this.NUM_LABEL.MouseLeave += new System.EventHandler(this.WebtoonDownloadDetailSectionChild_MouseLeave);
			// 
			// THUMBNAIL_ICON
			// 
			this.THUMBNAIL_ICON.BackColor = System.Drawing.Color.White;
			this.THUMBNAIL_ICON.Location = new System.Drawing.Point(0, 0);
			this.THUMBNAIL_ICON.Name = "THUMBNAIL_ICON";
			this.THUMBNAIL_ICON.Size = new System.Drawing.Size(35, 45);
			this.THUMBNAIL_ICON.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.THUMBNAIL_ICON.TabIndex = 0;
			this.THUMBNAIL_ICON.TabStop = false;
			this.THUMBNAIL_ICON.MouseDown += new System.Windows.Forms.MouseEventHandler(this.WebtoonDownloadDetailSectionChild_MouseDown);
			this.THUMBNAIL_ICON.MouseEnter += new System.EventHandler(this.WebtoonDownloadDetailSectionChild_MouseEnter);
			this.THUMBNAIL_ICON.MouseLeave += new System.EventHandler(this.WebtoonDownloadDetailSectionChild_MouseLeave);
			// 
			// WebtoonDownloadDetailSectionChild
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Transparent;
			this.Controls.Add(this.NUM_LABEL);
			this.Controls.Add(this.THUMBNAIL_ICON);
			this.Name = "WebtoonDownloadDetailSectionChild";
			this.Size = new System.Drawing.Size(35, 75);
			this.Load += new System.EventHandler(this.WebtoonDownloadDetailSectionChild_Load);
			this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.WebtoonDownloadDetailSectionChild_MouseDown);
			this.MouseEnter += new System.EventHandler(this.WebtoonDownloadDetailSectionChild_MouseEnter);
			this.MouseLeave += new System.EventHandler(this.WebtoonDownloadDetailSectionChild_MouseLeave);
			((System.ComponentModel.ISupportInitialize)(this.THUMBNAIL_ICON)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.PictureBox THUMBNAIL_ICON;
		private System.Windows.Forms.Label NUM_LABEL;
	}
}
