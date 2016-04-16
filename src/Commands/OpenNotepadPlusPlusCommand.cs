using System;
using System.ComponentModel.Design;
using System.IO;
using EnvDTE;
using EnvDTE80;
using Microsoft.VisualStudio.Shell;
using OpenInNotepadPlusPlus.Helpers;

namespace OpenInNotepadPlusPlus.Commands {

    internal sealed class OpenNotepadPlusPlusCommand {

        private readonly Package _package;

        private OpenNotepadPlusPlusCommand(Package package) {
            _package = package;

            var commandService = ServiceProvider.GetService(typeof(IMenuCommandService)) as OleMenuCommandService;

			if (commandService == null) return;

	        var menuCommandId = new CommandID(PackageGuids.guidOpenInVsCmdSet, PackageIds.OpenInNotepadPlusPlus);
	        var menuItem = new MenuCommand(OpenPath, menuCommandId);
	        commandService.AddCommand(menuItem);
        }

        public static OpenNotepadPlusPlusCommand Instance { get; private set; }

        private IServiceProvider ServiceProvider => _package;

	    public static void Initialize(Package package) {
            Instance = new OpenNotepadPlusPlusCommand(package);
        }

        private void OpenPath(object sender, EventArgs e) {
            var dte = (DTE2)ServiceProvider.GetService(typeof(DTE));

            try {
                var path = ProjectHelpers.GetSelectedPath(dte);
                var exe = VsPackage.Settings.FolderPath;

                if (!string.IsNullOrEmpty(path) && !string.IsNullOrEmpty(exe)){
					OpenNotepadPlusPlus(exe, path);
                }
                else{
                    System.Windows.Forms.MessageBox.Show("Couldn't resolve the folder");
                }
            }
            catch (Exception ex) {
                Logger.Log(ex);
            }
        }

        private static void OpenNotepadPlusPlus(string exe, string path) {
            var isDirectory = Directory.Exists(path);

            var start = new System.Diagnostics.ProcessStartInfo() {
                WorkingDirectory = path,
                FileName = $"\"{exe}\"",
                Arguments = isDirectory ? "." : $"\"{path}\"",
                CreateNoWindow = true,
                WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden
            };

            using (System.Diagnostics.Process.Start(start)) {}
        }
    }
}
