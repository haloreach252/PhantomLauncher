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
	/// Interaction logic for IconTest.xaml
	/// </summary>
	public partial class IconTest : Page {

		private List<Label> labels;
		public bool loaded = false;

		public IconTest() {
			InitializeComponent();
			labels = new List<Label>();
			loaded = false;
		}

		private void LoadLabels(object sender, EventArgs e) {
			foreach (Label label in FindVisualChildren<Label>(this)) {
				labels.Add(label);
				if ((string)label.Tag == "labelGrid") {
					label.Height = 150;
					label.Width = 150;
					label.FontSize = 128;
				}
				if (Definitions.instance.glyphDefinitions.ContainsKey(label.Content.ToString())) {
					label.Content = Definitions.instance.glyphDefinitions[label.Content.ToString()];
				} else {
					if(label.FontFamily.ToString() == "./Fonts/#Font Awesome 5 Free Solid") {
						label.Content = Definitions.instance.glyphDefinitions["ban"];
					} else if(label.FontFamily.ToString() == "./Fonts/#Font Awesome 5 Brands Regular") {
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

		public void ResizeLabels(double width) {
			int widthMod = 0;
			int heightMod = 0;
			if(double.IsNaN(width)) {
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
