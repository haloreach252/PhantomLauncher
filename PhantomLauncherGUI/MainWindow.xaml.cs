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

		private IconTest page;

		public MainWindow(){
			InitializeComponent();
			iconTestFrame.Source = new Uri("pack://application:,,,/IconTest.xaml");
			ResizeComponents();
			Definitions.Initialize();
		}

		private void LoadedData(object sender, EventArgs e) {
			ResizeComponents();
		}

		private void ResizeComponents() {
			titleBarBackground.Width = Width;

			ResizeTitleButton(exitApplicationButton, 0);
			ResizeTitleButton(maximizeApplicationButton, 1);
			ResizeTitleButton(minimizeApplicationButton, 2);

			page = (IconTest)iconTestFrame.Content;
			if(page != null && page.loaded) {
				page.ResizePage(Width, Height);
			}
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
