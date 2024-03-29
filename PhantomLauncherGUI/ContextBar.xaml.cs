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

namespace PhantomLauncherGUI {
	/// <summary>
	/// Interaction logic for ContextBar.xaml
	/// </summary>
	public partial class ContextBar : UserControl {

		private MainWindow parentWindow;

		public ContextBar(MainWindow parentWindow) {
			InitializeComponent();
			this.parentWindow = parentWindow;
		}

		private void ContextMenuClick(object sender, EventArgs e) {
			string pageName = ((Button)sender).Tag.ToString();
			parentWindow.SetContent(pageName);
		}

	}
}
