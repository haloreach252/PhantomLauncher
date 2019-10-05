﻿using System;
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

		private Dictionary<string, string> fontAwesomeGlyphs = new Dictionary<string, string>();

		public MainWindow(){
			InitializeComponent();
			ResizeComponents();

			fontAwesomeGlyphs.Add("power-off","");
			powerOffLabel.Content = fontAwesomeGlyphs["power-off"];

			exitApplicationButton.Click += ExitApplication;
			minimizeApplicationButton.Click += MinimizeApplication;
			maximizeApplicationButton.Click += MaximizeApplication;
		}

		private void ResizeComponents() {
			titleBarBackground.Width = Width;
		}

		private void MinimizeApplication(object sender, EventArgs e) {
			WindowState = WindowState.Minimized;
		}

		private void MaximizeApplication(object sender, EventArgs e) {
			if(WindowState == WindowState.Maximized) {
				WindowState = WindowState.Normal;
			} else {
				WindowState = WindowState.Maximized;
			}

			ResizeComponents();

		}

		private void ExitApplication(object sender, EventArgs e){
			Application.Current.Shutdown();
		}

		private void OnSizeChanged(object sender, EventArgs e) {
			ResizeComponents();
		}

	}
}
