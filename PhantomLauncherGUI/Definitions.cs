using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Diagnostics;

namespace PhantomLauncherGUI {
	public class Definitions {
		private string debuggerPath = Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory()));

		public enum DefinitionType {
			ICON, GLYPH
		}

		public Dictionary<string, string> iconDefinitions;
		public Dictionary<string, string> glyphDefinitions;

		public static Definitions instance;

		public static void Initialize() {
			instance = new Definitions();
		}

		public Definitions() {
			if(instance != null) {
				return;
			}

			iconDefinitions = new Dictionary<string, string>();
			glyphDefinitions = new Dictionary<string, string>();
			iconDefinitions = GetDefinition(DefinitionType.ICON);
			glyphDefinitions = GetDefinition(DefinitionType.GLYPH);
		}

		public string GetTaggedGlyph(string tag) {
			if (iconDefinitions.ContainsKey(tag)) {
				return glyphDefinitions[iconDefinitions[tag]];
			} else {
				return glyphDefinitions["ban"];
			}
		}

		private Dictionary<string, string> GetDefinition(DefinitionType type) {
			Dictionary<string, string> dic = new Dictionary<string, string>();
			string path = $"{AppDomain.CurrentDomain.BaseDirectory}/Definitions/";
			if (Debugger.IsAttached) path = $"{debuggerPath}/Definitions/";

			if (type == DefinitionType.ICON) {
				path += "IconDefinitions.json";
			} else if (type == DefinitionType.GLYPH) {
				path += "IconGlyphs.json";
			} else {
				Debug.Write("Type invalid, failed set");
				return null;
			}

			JObject o = JObject.Parse(File.ReadAllText(path));
			foreach (JProperty p in o.Properties()) {
				string name = p.Name;
				string val = (string)p.Value;
				dic.Add(name, val);
			}
			return dic;
		}
	}
}
