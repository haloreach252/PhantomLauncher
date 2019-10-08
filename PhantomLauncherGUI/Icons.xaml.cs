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

namespace PhantomLauncherGUI {
	/// <summary>
	/// Interaction logic for Icons.xaml
	/// </summary>
	public partial class Icons : UserControl {

		private List<Label> labels;
		public bool loaded = false;

		private int iconSize = 100;
		private int[] fontSize;

		public Icons() {
			InitializeComponent();
			labels = new List<Label>();
			loaded = false;
			fontSize = new int[] {32,64,96,128};
		}

		private void LoadLabels(object sender, EventArgs e) {
			for (int i = 0; i < 10; i++) {
				CreateLabel("tools", $"label{i}t");
				CreateLabel("mobile", $"label{i}m");
				CreateLabel("power-off", $"label{i}p");
			}
			foreach (Label label in FindVisualChildren<Label>(this)) {
				labels.Add(label);
				if ((string)label.Tag == "labelGrid") {
					label.Height = iconSize;
					label.Width = iconSize;
					label.FontSize = fontSize[1];
				}
				if (Definitions.instance.glyphDefinitions.ContainsKey(label.Content.ToString())) {
					label.Content = Definitions.instance.glyphDefinitions[label.Content.ToString()];
				} else {
					if (label.FontFamily.ToString() == "./Fonts/#Font Awesome 5 Free Solid") {
						label.Content = Definitions.instance.glyphDefinitions["ban"];
					} else if (label.FontFamily.ToString() == "./Fonts/#Font Awesome 5 Brands Regular") {
						label.Content = Definitions.instance.glyphDefinitions["slack"];
					} else {
						label.Content = "no";
						Debug.WriteLine($"Label: {label.Name} missing correct font definition. Family: {label.FontFamily.ToString()}");
					}
				}
			}
			ResizeLabels(Width);
			loaded = true;
		}

		private void CreateLabel(string content, string name) {
			Label l = new Label() {
				Width = 150, Height = 150, FontSize = 128,
				Foreground = Brushes.White,
				Name = name, Content = content, Tag = "labelGrid",
				HorizontalAlignment = HorizontalAlignment.Left, VerticalAlignment = VerticalAlignment.Top,
				HorizontalContentAlignment = HorizontalAlignment.Center, VerticalContentAlignment = VerticalAlignment.Center,
				FontFamily = new FontFamily(new Uri("pack://application:,,,/"), "./Fonts/#Font Awesome 5 Free Solid")
			};
			iconsGrid.Children.Add(l);
		}

		public void ResizePage(double width, double height) {
			if (double.IsNaN(width)) {
				width = MainWindow.DefaultWidth;
			}
			Height = height - 45;
			Width = width - 20;
			ResizeLabels(Width);
		}

		public void ResizeLabels(double width) {
			int widthMod = 0;
			int heightMod = 0;
			if (double.IsNaN(width)) {
				width = MainWindow.DefaultWidth;
			}
			for (int i = 0; i < labels.Count; i++) {
				if (10 + (labels[i].Width * (i - widthMod)) > width - labels[i].Width) {
					widthMod = i;
					heightMod++;
				}
				labels[i].Margin = new Thickness(10 + (labels[i].Width * (i - widthMod)), 10 + labels[i].Height * heightMod, 0, 0);
			}
		}

		public static IEnumerable<T> FindVisualChildren<T>(DependencyObject depObj) where T : DependencyObject {
			if (depObj != null) {
				for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++) {
					DependencyObject child = VisualTreeHelper.GetChild(depObj, i);
					if (child != null && child is T) {
						yield return (T)child;
					}

					foreach (T childOfChild in FindVisualChildren<T>(child)) {
						yield return childOfChild;
					}
				}
			}
		}
	}
}
