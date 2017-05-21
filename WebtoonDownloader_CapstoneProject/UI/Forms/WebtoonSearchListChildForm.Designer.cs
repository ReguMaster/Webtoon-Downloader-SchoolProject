namespace WebtoonDownloader_CapstoneProject.UI.Forms
{
	partial class WebtoonSearchListChildForm
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
			this.components = new System.ComponentModel.Container();
			this.TITLE_LABEL = new System.Windows.Forms.Label();
			this.DESC_LABEL = new System.Windows.Forms.Label();
			this.SELECT_BUTTON = new WebtoonDownloader_CapstoneProject.UI.FlatButton();
			this.TOTAL_NUM_LABEL = new System.Windows.Forms.Label();
			this.TOOL_TIP = new System.Windows.Forms.ToolTip(this.components);
			this.STORE_ICON = new System.Windows.Forms.PictureBox();
			this.ADULT_ICON = new System.Windows.Forms.PictureBox();
			this.THUMBNAIL_IMAGE = new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize)(this.STORE_ICON)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.ADULT_ICON)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.THUMBNAIL_IMAGE)).BeginInit();
			this.SuspendLayout();
			// 
			// TITLE_LABEL
			// 
			this.TITLE_LABEL.AutoEllipsis = true;
			this.TITLE_LABEL.BackColor = System.Drawing.Color.Transparent;
			this.TITLE_LABEL.Font = new System.Drawing.Font("나눔고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.TITLE_LABEL.Location = new System.Drawing.Point(164, 3);
			this.TITLE_LABEL.Name = "TITLE_LABEL";
			this.TITLE_LABEL.Size = new System.Drawing.Size(377, 26);
			this.TITLE_LABEL.TabIndex = 11;
			this.TITLE_LABEL.Text = "웹툰 이름";
			this.TITLE_LABEL.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.TITLE_LABEL.Click += new System.EventHandler(this.TITLE_LABEL_Click);
			// 
			// DESC_LABEL
			// 
			this.DESC_LABEL.AutoEllipsis = true;
			this.DESC_LABEL.BackColor = System.Drawing.Color.Transparent;
			this.DESC_LABEL.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.DESC_LABEL.Location = new System.Drawing.Point(164, 31);
			this.DESC_LABEL.Name = "DESC_LABEL";
			this.DESC_LABEL.Size = new System.Drawing.Size(483, 75);
			this.DESC_LABEL.TabIndex = 13;
			this.DESC_LABEL.Text = "웹툰 설명";
			// 
			// SELECT_BUTTON
			// 
			this.SELECT_BUTTON.AnimationLerpP = 0.8F;
			this.SELECT_BUTTON.BackColor = System.Drawing.Color.Transparent;
			this.SELECT_BUTTON.ButtonText = "이 웹툰 선택";
			this.SELECT_BUTTON.ButtonTextColor = System.Drawing.Color.Black;
			this.SELECT_BUTTON.Cursor = System.Windows.Forms.Cursors.Hand;
			this.SELECT_BUTTON.EnterStateBackgroundColor = System.Drawing.Color.Gainsboro;
			this.SELECT_BUTTON.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.SELECT_BUTTON.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.SELECT_BUTTON.Location = new System.Drawing.Point(502, 115);
			this.SELECT_BUTTON.Name = "SELECT_BUTTON";
			this.SELECT_BUTTON.NormalStateBackgroundColor = System.Drawing.Color.WhiteSmoke;
			this.SELECT_BUTTON.Size = new System.Drawing.Size(145, 30);
			this.SELECT_BUTTON.TabIndex = 14;
			this.SELECT_BUTTON.TabStop = false;
			this.SELECT_BUTTON.Text = "이 웹툰 선택";
			this.SELECT_BUTTON.UseVisualStyleBackColor = false;
			this.SELECT_BUTTON.Click += new System.EventHandler(this.SELECT_BUTTON_Click);
			// 
			// TOTAL_NUM_LABEL
			// 
			this.TOTAL_NUM_LABEL.AutoEllipsis = true;
			this.TOTAL_NUM_LABEL.BackColor = System.Drawing.Color.Transparent;
			this.TOTAL_NUM_LABEL.Font = new System.Drawing.Font("나눔고딕", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.TOTAL_NUM_LABEL.Location = new System.Drawing.Point(547, 2);
			this.TOTAL_NUM_LABEL.Name = "TOTAL_NUM_LABEL";
			this.TOTAL_NUM_LABEL.Size = new System.Drawing.Size(100, 26);
			this.TOTAL_NUM_LABEL.TabIndex = 15;
			this.TOTAL_NUM_LABEL.Text = "총 1000화";
			this.TOTAL_NUM_LABEL.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// STORE_ICON
			// 
			this.STORE_ICON.BackColor = System.Drawing.Color.Transparent;
			this.STORE_ICON.Image = global::WebtoonDownloader_CapstoneProject.Properties.Resources.storeIcon;
			this.STORE_ICON.Location = new System.Drawing.Point(200, 117);
			this.STORE_ICON.Name = "STORE_ICON";
			this.STORE_ICON.Size = new System.Drawing.Size(30, 30);
			this.STORE_ICON.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.STORE_ICON.TabIndex = 17;
			this.STORE_ICON.TabStop = false;
			this.TOOL_TIP.SetToolTip(this.STORE_ICON, "스토어 웹툰");
			// 
			// ADULT_ICON
			// 
			this.ADULT_ICON.BackColor = System.Drawing.Color.Transparent;
			this.ADULT_ICON.Image = global::WebtoonDownloader_CapstoneProject.Properties.Resources.adultIcon;
			this.ADULT_ICON.Location = new System.Drawing.Point(164, 117);
			this.ADULT_ICON.Name = "ADULT_ICON";
			this.ADULT_ICON.Size = new System.Drawing.Size(30, 30);
			this.ADULT_ICON.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.ADULT_ICON.TabIndex = 16;
			this.ADULT_ICON.TabStop = false;
			this.TOOL_TIP.SetToolTip(this.ADULT_ICON, "미성년자 관람 불가 웹툰");
			// 
			// THUMBNAIL_IMAGE
			// 
			this.THUMBNAIL_IMAGE.BackColor = System.Drawing.Color.Transparent;
			this.THUMBNAIL_IMAGE.Location = new System.Drawing.Point(3, 3);
			this.THUMBNAIL_IMAGE.Name = "THUMBNAIL_IMAGE";
			this.THUMBNAIL_IMAGE.Size = new System.Drawing.Size(155, 144);
			this.THUMBNAIL_IMAGE.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.THUMBNAIL_IMAGE.TabIndex = 12;
			this.THUMBNAIL_IMAGE.TabStop = false;
			// 
			// WebtoonSearchListChildForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.Controls.Add(this.STORE_ICON);
			this.Controls.Add(this.ADULT_ICON);
			this.Controls.Add(this.TOTAL_NUM_LABEL);
			this.Controls.Add(this.SELECT_BUTTON);
			this.Controls.Add(this.DESC_LABEL);
			this.Controls.Add(this.THUMBNAIL_IMAGE);
			this.Controls.Add(this.TITLE_LABEL);
			this.Name = "WebtoonSearchListChildForm";
			this.Size = new System.Drawing.Size(650, 150);
			this.Load += new System.EventHandler(this.WebtoonSearchListChildForm_Load);
			this.Paint += new System.Windows.Forms.PaintEventHandler(this.WebtoonSearchListChildForm_Paint);
			((System.ComponentModel.ISupportInitialize)(this.STORE_ICON)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.ADULT_ICON)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.THUMBNAIL_IMAGE)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Label TITLE_LABEL;
		private System.Windows.Forms.PictureBox THUMBNAIL_IMAGE;
		private System.Windows.Forms.Label DESC_LABEL;
		private FlatButton SELECT_BUTTON;
		private System.Windows.Forms.Label TOTAL_NUM_LABEL;
		private System.Windows.Forms.PictureBox ADULT_ICON;
		private System.Windows.Forms.ToolTip TOOL_TIP;
		private System.Windows.Forms.PictureBox STORE_ICON;
	}
}
