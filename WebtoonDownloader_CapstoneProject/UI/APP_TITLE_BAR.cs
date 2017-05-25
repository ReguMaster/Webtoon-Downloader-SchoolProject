using System;
using System.Drawing;
using System.Windows.Forms;
using WebtoonDownloader_CapstoneProject.Core;

namespace WebtoonDownloader_CapstoneProject.UI
{
	public partial class APP_TITLE_BAR : UserControl
	{
		private Point startPoint;
		private new Form ParentForm;
		private string KoreanText_private;
		public string KoreanText
		{
			get
			{
				return KoreanText_private;
			}
			set
			{
				KoreanText_private = value;
				this.APP_TITLE_KO.Text = value;
			}
		}

		private string EnglishText_private;
		public string EnglishText
		{
			get
			{
				return EnglishText_private;
			}
			set
			{
				EnglishText_private = value;
				this.APP_TITLE_ENG.Text = value;
			}
		}

		private bool ShowMinimize_private = true;
		public bool ShowMinimize
		{
			get
			{
				return ShowMinimize_private;
			}
			set
			{
				ShowMinimize_private = value;
				this.MINIMIZE_BUTTON.Visible = value;
			}
		}

		private bool ShowClose_private = true;
		public bool ShowClose
		{
			get
			{
				return ShowClose_private;
			}
			set
			{
				ShowClose_private = value;
				this.CLOSE_BUTTON.Visible = value;
			}
		}

		private bool ShowHelp_private = false;
		public bool ShowHelp
		{
			get
			{
				return ShowHelp_private;
			}
			set
			{
				ShowHelp_private = value;
				this.HELP_BUTTON.Visible = value;
			}
		}

		private Color TextColor_private = Color.Black;
		public Color TextColor
		{
			get
			{
				return TextColor_private;
			}
			set
			{
				TextColor_private = value;
				this.APP_TITLE_KO.ForeColor = value;
				this.APP_TITLE_ENG.ForeColor = value;
			}
		}

		public event Func<bool> BeginClose;
		public event Action HelpButtonClicked;

		public APP_TITLE_BAR( )
		{
			InitializeComponent( );

			this.SetStyle( ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw, true );
			this.UpdateStyles( );

			this.ShowHelp = false;
		}

		private void APP_TITLE_BAR_Load( object sender, EventArgs e )
		{
			this.ParentForm = this.Parent as Form;

			this.APP_TITLE_KO.BackColor = Color.Transparent;
			this.APP_TITLE_ENG.BackColor = Color.Transparent;
			this.APP_TITLE_KO.Parent = this;
			this.APP_TITLE_ENG.Parent = this;
		}

		private void CLOSE_BUTTON_Click( object sender, EventArgs e )
		{
			if ( BeginClose?.Invoke( ) == false ) return;

			Animation.UI.FadeOut( this.ParentForm, true );
		}

		private void MINIMIZE_BUTTON_Click( object sender, EventArgs e )
		{
			this.ParentForm.WindowState = FormWindowState.Minimized;
		}

		private void HELP_BUTTON_Click( object sender, EventArgs e )
		{
			HelpButtonClicked?.Invoke( );
		}

		private void APP_TITLE_BAR_MouseDown( object sender, MouseEventArgs e )
		{
			if ( e.Button == MouseButtons.Left )
				startPoint = e.Location;
		}

		private void APP_TITLE_BAR_MouseMove( object sender, MouseEventArgs e )
		{
			if ( e.Button == MouseButtons.Left )
			{
				this.ParentForm.Location = new Point(
					this.ParentForm.Left - ( startPoint.X - e.X ),
					Math.Max( this.ParentForm.Top - ( startPoint.Y - e.Y ), Screen.FromHandle( this.ParentForm.Handle ).WorkingArea.Top )
				);
			}
		}
	}
}
