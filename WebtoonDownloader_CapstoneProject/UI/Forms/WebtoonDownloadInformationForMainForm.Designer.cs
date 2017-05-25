namespace WebtoonDownloader_CapstoneProject.UI.Forms
{
	partial class WebtoonDownloadInformationForMainForm
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
			this.WEBTOON_DETAIL_UPLOAD_DATE_LABEL = new System.Windows.Forms.Label();
			this.WEBTOON_DETAIL_TITLE_LABEL = new System.Windows.Forms.Label();
			this.WEBTOON_DETAIL_STAR_RATE_LABEL = new System.Windows.Forms.Label();
			this.UPLOAD_DATE_IMAGE = new System.Windows.Forms.PictureBox();
			this.STAR_RATE_IMAGE = new System.Windows.Forms.PictureBox();
			this.THUMBNAIL_IMAGE = new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize)(this.UPLOAD_DATE_IMAGE)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.STAR_RATE_IMAGE)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.THUMBNAIL_IMAGE)).BeginInit();
			this.SuspendLayout();
			// 
			// WEBTOON_DETAIL_UPLOAD_DATE_LABEL
			// 
			this.WEBTOON_DETAIL_UPLOAD_DATE_LABEL.BackColor = System.Drawing.Color.Transparent;
			this.WEBTOON_DETAIL_UPLOAD_DATE_LABEL.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Bold);
			this.WEBTOON_DETAIL_UPLOAD_DATE_LABEL.Location = new System.Drawing.Point(270, 96);
			this.WEBTOON_DETAIL_UPLOAD_DATE_LABEL.Name = "WEBTOON_DETAIL_UPLOAD_DATE_LABEL";
			this.WEBTOON_DETAIL_UPLOAD_DATE_LABEL.Size = new System.Drawing.Size(94, 25);
			this.WEBTOON_DETAIL_UPLOAD_DATE_LABEL.TabIndex = 14;
			this.WEBTOON_DETAIL_UPLOAD_DATE_LABEL.Text = "업로드 일";
			this.WEBTOON_DETAIL_UPLOAD_DATE_LABEL.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// WEBTOON_DETAIL_TITLE_LABEL
			// 
			this.WEBTOON_DETAIL_TITLE_LABEL.AutoEllipsis = true;
			this.WEBTOON_DETAIL_TITLE_LABEL.BackColor = System.Drawing.Color.Transparent;
			this.WEBTOON_DETAIL_TITLE_LABEL.Font = new System.Drawing.Font("나눔고딕", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.WEBTOON_DETAIL_TITLE_LABEL.Location = new System.Drawing.Point(211, 3);
			this.WEBTOON_DETAIL_TITLE_LABEL.Name = "WEBTOON_DETAIL_TITLE_LABEL";
			this.WEBTOON_DETAIL_TITLE_LABEL.Size = new System.Drawing.Size(418, 30);
			this.WEBTOON_DETAIL_TITLE_LABEL.TabIndex = 12;
			this.WEBTOON_DETAIL_TITLE_LABEL.Text = "현재 화 이름";
			this.WEBTOON_DETAIL_TITLE_LABEL.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// WEBTOON_DETAIL_STAR_RATE_LABEL
			// 
			this.WEBTOON_DETAIL_STAR_RATE_LABEL.BackColor = System.Drawing.Color.Transparent;
			this.WEBTOON_DETAIL_STAR_RATE_LABEL.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.WEBTOON_DETAIL_STAR_RATE_LABEL.Location = new System.Drawing.Point(219, 96);
			this.WEBTOON_DETAIL_STAR_RATE_LABEL.Name = "WEBTOON_DETAIL_STAR_RATE_LABEL";
			this.WEBTOON_DETAIL_STAR_RATE_LABEL.Size = new System.Drawing.Size(45, 25);
			this.WEBTOON_DETAIL_STAR_RATE_LABEL.TabIndex = 16;
			this.WEBTOON_DETAIL_STAR_RATE_LABEL.Text = "10.0";
			this.WEBTOON_DETAIL_STAR_RATE_LABEL.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// UPLOAD_DATE_IMAGE
			// 
			this.UPLOAD_DATE_IMAGE.BackColor = System.Drawing.Color.Transparent;
			this.UPLOAD_DATE_IMAGE.Image = global::WebtoonDownloader_CapstoneProject.Properties.Resources.date;
			this.UPLOAD_DATE_IMAGE.Location = new System.Drawing.Point(302, 63);
			this.UPLOAD_DATE_IMAGE.Name = "UPLOAD_DATE_IMAGE";
			this.UPLOAD_DATE_IMAGE.Size = new System.Drawing.Size(30, 30);
			this.UPLOAD_DATE_IMAGE.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.UPLOAD_DATE_IMAGE.TabIndex = 17;
			this.UPLOAD_DATE_IMAGE.TabStop = false;
			// 
			// STAR_RATE_IMAGE
			// 
			this.STAR_RATE_IMAGE.BackColor = System.Drawing.Color.Transparent;
			this.STAR_RATE_IMAGE.Image = global::WebtoonDownloader_CapstoneProject.Properties.Resources.star;
			this.STAR_RATE_IMAGE.Location = new System.Drawing.Point(226, 63);
			this.STAR_RATE_IMAGE.Name = "STAR_RATE_IMAGE";
			this.STAR_RATE_IMAGE.Size = new System.Drawing.Size(30, 30);
			this.STAR_RATE_IMAGE.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.STAR_RATE_IMAGE.TabIndex = 15;
			this.STAR_RATE_IMAGE.TabStop = false;
			// 
			// THUMBNAIL_IMAGE
			// 
			this.THUMBNAIL_IMAGE.Location = new System.Drawing.Point(3, 3);
			this.THUMBNAIL_IMAGE.Name = "THUMBNAIL_IMAGE";
			this.THUMBNAIL_IMAGE.Size = new System.Drawing.Size(202, 120);
			this.THUMBNAIL_IMAGE.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.THUMBNAIL_IMAGE.TabIndex = 0;
			this.THUMBNAIL_IMAGE.TabStop = false;
			// 
			// WebtoonDownloadInformationForMainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.Controls.Add(this.UPLOAD_DATE_IMAGE);
			this.Controls.Add(this.WEBTOON_DETAIL_STAR_RATE_LABEL);
			this.Controls.Add(this.STAR_RATE_IMAGE);
			this.Controls.Add(this.WEBTOON_DETAIL_UPLOAD_DATE_LABEL);
			this.Controls.Add(this.WEBTOON_DETAIL_TITLE_LABEL);
			this.Controls.Add(this.THUMBNAIL_IMAGE);
			this.Name = "WebtoonDownloadInformationForMainForm";
			this.Size = new System.Drawing.Size(650, 125);
			((System.ComponentModel.ISupportInitialize)(this.UPLOAD_DATE_IMAGE)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.STAR_RATE_IMAGE)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.THUMBNAIL_IMAGE)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.PictureBox THUMBNAIL_IMAGE;
		private System.Windows.Forms.Label WEBTOON_DETAIL_UPLOAD_DATE_LABEL;
		private System.Windows.Forms.Label WEBTOON_DETAIL_TITLE_LABEL;
		private System.Windows.Forms.PictureBox STAR_RATE_IMAGE;
		private System.Windows.Forms.Label WEBTOON_DETAIL_STAR_RATE_LABEL;
		private System.Windows.Forms.PictureBox UPLOAD_DATE_IMAGE;
	}
}
