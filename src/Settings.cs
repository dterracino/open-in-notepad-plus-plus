using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using Microsoft.VisualStudio.Shell;

namespace OpenInNotepadPlusPlus {

    public class Settings : DialogPage {
        [Category("General")]
        [DisplayName("Install path")]
        [Description("The absolute path to the \"notepad++.exe\" file.")]
        public string FolderPath { get; set; }

        public override void LoadSettingsFromStorage() {
            base.LoadSettingsFromStorage();

            if (string.IsNullOrEmpty(FolderPath)) {
                FolderPath = FindNotepadPlusPlus();
            }
        }

        private static string FindNotepadPlusPlus() {
            var programFiles = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles));
            var dirs = programFiles.Parent.GetDirectories(programFiles.Name.Replace(" (x86)", string.Empty) + "*");

	        foreach (var parent in dirs) {
		        foreach (var dir in parent.GetDirectories("Notepad++").Reverse()) {
			        var path = Path.Combine(dir.FullName, "notepad++.exe");

			        if (File.Exists(path))
				        return path;
		        }
	        }

	        return null;
        }
    }
}
