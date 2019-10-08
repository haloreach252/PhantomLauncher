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
using System.Diagnostics;

namespace PhantomLauncherGUI
{
	public partial class MainWindow : Window
	{
		public static double DefaultWidth = 1280;

		private Uri currentTestUri = new Uri("pack://application:,,,/GameLibrary.xaml");

		private ContextBar contextBar;
		private GameLibrary gameLibraryContent;
		private Icons icons;
		//private HomePage homePageContent;
		//private IconTest iconTestPage;

		public MainWindow(){
			InitializeComponent();
			//currentTestFrame.Source = currentTestUri;
			contextBar = new ContextBar(this);
			gameLibraryContent = new GameLibrary();
			icons = new Icons();
			Definitions.Initialize();
		}

		private void LoadedData(object sender, EventArgs e) {
			ResizeComponents();

			SetIcons();

			//mainContentControl.Content = homePageContent;
			contextBarContent.Content = contextBar;
			mainContentControl.Content = icons;
		}

		private void ResizeComponents() {
			// TITLE BAR AREA //
			titleBarBackground.Width = Width;
			titleBarTitle.FontSize = titleBarBackground.Height - 5;

			ResizeTitleButton(exitApplicationButton, 0);
			ResizeTitleButton(maximizeApplicationButton, 1);
			ResizeTitleButton(minimizeApplicationButton, 2);

			// CONTEXT BAR AREA //
			contextBarContent.Width = Width;
			contextBar.Width = Width;

			// CURRENT CONTENT AREA //
			mainContentControl.Width = Width - 20;
			mainContentControl.Height = Height - 95;
			icons.Width = mainContentControl.Width;
			icons.Height = mainContentControl.Height;
			icons.ResizeLabels(mainContentControl.Width);
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

		public void AdjustWindowSize() {
			if (WindowState == WindowState.Maximized) {
				WindowState = WindowState.Normal;
			} else {
				WindowState = WindowState.Maximized;
			}
		}

		public void SetContent(string name) {
			if(name == "library") {
				mainContentControl.Content = gameLibraryContent;
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

		private void ExitApplication(object sender, EventArgs e) {
			Application.Current.Shutdown();
		}

		private void OnSizeChanged(object sender, EventArgs e) {
			ResizeComponents();
		}
		#endregion
	}
}
