namespace WebtoonDownloader_CapstoneProject.UI.Forms
{
	partial class WebtoonDownloadDetailSectionDotForm
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
			this.SuspendLayout();
			// 
			// WebtoonDownloadDetailSectionDotForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Transparent;
			this.Cursor = System.Windows.Forms.Cursors.Hand;
			this.Name = "WebtoonDownloadDetailSectionDotForm";
			this.Size = new System.Drawing.Size(30, 30);
			this.Paint += new System.Windows.Forms.PaintEventHandler(this.WebtoonDownloadDetailSectionDotForm_Paint);
			this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.WebtoonDownloadDetailSectionDotForm_MouseDown);
			this.ResumeLayout(false);

		}

		#endregion
	}
}
