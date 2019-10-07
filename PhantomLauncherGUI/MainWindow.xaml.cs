using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PhantomLauncherGUI
{
	public partial class MainWindow : Window
	{
		public static double DefaultWidth = 1280;

		private Uri currentTestUri = new Uri("pack://application:,,,/GameLibrary.xaml");

		private ContextBar contextBar;
		//private IconTest iconTestPage;

		public MainWindow(){
			InitializeComponent();
			currentTestFrame.Source = currentTestUri;
			//iconTestFrame.Source = new Uri("pack://application:,,,/IconTest.xaml");
			Definitions.Initialize();

			contextBar = new ContextBar();

		}

		private void LoadedData(object sender, EventArgs e) {
			ResizeComponents();

			SetIcons();

			contextBarContent.Content = contextBar;
		}

		private void ResizeComponents() {
			// TITLE BAR AREA //
			titleBarBackground.Width = Width;
			titleBarTitle.FontSize = titleBarBackground.Height - 5;

			ResizeTitleButton(exitApplicationButton, 0);
			ResizeTitleButton(maximizeApplicationButton, 1);
			ResizeTitleButton(minimizeApplicationButton, 2);

			// CONTEXT BAR AREA //
			//contextBarBackground.Width = Width;

			// CURRENT CONTENT AREA //
			currentTestFrame.Width = Width - 20;
			currentTestFrame.Height = Height - 85;
			/*iconTestPage = (IconTest)iconTestFrame.Content;
			if(iconTestPage != null && iconTestPage.loaded) {
				iconTestPage.ResizePage(Width, Height);
			}*/
		}

		private void SetIcons() {
			exitApplicationButton.Content = Definitions.instance.GetTaggedGlyph(exitApplicationButton.Tag.ToString());
			maximizeApplicationButton.Content = Definitions.instance.GetTaggedGlyph(maximizeApplicationButton.Tag.ToString());
			minimizeApplicationButton.Content = Definitions.instance.GetTaggedGlyph(minimizeApplicationButton.Tag.ToString());
		}

		private void ResizeTitleButton(Button b, int thicknessModifier) {
			b.Height = titleBarBackground.Height;
			b.Width = b.Height;
			b.Margin = new Thickness(0, 0, b.Width * thicknessModifier, 0);
		}

		private void AdjustWindowSize() {
			if (WindowState == WindowState.Maximized) {
				WindowState = WindowState.Normal;
			} else {
				WindowState = WindowState.Maximized;
			}
		}

		#region Events
		private void OnMouseDown(object sender, MouseButtonEventArgs e) {
			if (e.ChangedButton == MouseButton.Left) {
				if (e.ClickCount == 2) {
					AdjustWindowSize();
				} else {
					Application.Current.MainWindow.DragMove();
				}
			}
		}

		private void MinimizeApplication(object sender, EventArgs e) {
			WindowState = WindowState.Minimized;
		}

		private void MaximizeApplication(object sender, EventArgs e) {
			AdjustWindowSize();
		}

		private void ExitApplication(object sender, EventArgs e){
			Application.Current.Shutdown();
		}

		private void OnSizeChanged(object sender, EventArgs e) {
			ResizeComponents();
		}
		#endregion
	}
}
