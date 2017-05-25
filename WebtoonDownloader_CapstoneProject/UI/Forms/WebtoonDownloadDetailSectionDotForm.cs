using System;
using System.Drawing;
using System.Windows.Forms;
using WebtoonDownloader_CapstoneProject.Core;

namespace WebtoonDownloader_CapstoneProject.UI.Forms
{
	public partial class WebtoonDownloadDetailSectionDotForm : UserControl
	{
		private Image image;
		private Brush maskBrush = new SolidBrush( Color.White );
		public event Action<int> DotMouseRightClicked; // 점을 마우스 오른쪽 클릭 했을 때

		public WebtoonDownloadDetailSectionDotForm( bool isStartDot )
		{
			InitializeComponent( );

			this.SetStyle( ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true );
			this.UpdateStyles( );
			
			if ( isStartDot )
				this.image = Properties.Resources.SECTION_START_DOT;
			else
				this.image = Properties.Resources.SECTION_END_DOT;

			Animation.NumberSmoothEffect( 255, 0, ( float alpha ) =>
			{
				if ( this == null || this.IsDisposed || this.Disposing ) return;

				this.maskBrush = new SolidBrush( Color.White )
				{
					Color = Color.FromArgb( ( int ) alpha, Color.White )
				};

				this.Invalidate( );
			}, ( float alpha ) =>
			{
				if ( this == null || this.IsDisposed || this.Disposing ) return;
				this.Invalidate( );
			} );
		}

		public void FadeRemove( Action callBack )
		{
			Animation.NumberSmoothEffect( 0, 255, ( float alpha ) =>
			{
				if ( this == null || this.IsDisposed || this.Disposing ) return;

				this.maskBrush = new SolidBrush( Color.White )
				{
					Color = Color.FromArgb( ( int ) alpha, Color.White )
				};

				this.Invalidate( );
			}, ( float alpha ) =>
			{
				if ( this == null || this.IsDisposed || this.Disposing ) return;

				this.Invalidate( );
				callBack.Invoke( );
			} );
		}

		private void WebtoonDownloadDetailSectionDotForm_Paint( object sender, PaintEventArgs e )
		{
			e.Graphics.DrawImage( image, e.ClipRectangle );
			e.Graphics.FillRectangle( maskBrush, e.ClipRectangle );
		}

		private void WebtoonDownloadDetailSectionDotForm_MouseDown( object sender, MouseEventArgs e )
		{
			if ( e.Button == MouseButtons.Right )
				DotMouseRightClicked.Invoke( this.Parent.Controls.GetChildIndex( this ) );
		}
	}
}
