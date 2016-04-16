using System.Runtime.InteropServices;
using Microsoft.VisualStudio.Shell;
using OpenInNotepadPlusPlus.Commands;
using OpenInNotepadPlusPlus.Helpers;

namespace OpenInNotepadPlusPlus
{
    [PackageRegistration(UseManagedResourcesOnly = true)]
    [InstalledProductRegistration("#110", "#112", Vsix.Version, IconResourceID = 400)]
    [ProvideOptionPage(typeof(Settings), "Open in Notepad++", "General", 101, 111, true, new string[0], ProvidesLocalizedCategoryName = false)]
    [ProvideMenuResource("Menus.ctmenu", 1)]
    [Guid(PackageGuids.guidPackageString)]
    public sealed class VsPackage : Package
    {
        public static Settings Settings;

        protected override void Initialize()
        {
            Settings = (Settings)GetDialogPage(typeof(Settings));

            Logger.Initialize(this, Vsix.Name);
            OpenNotepadPlusPlusCommand.Initialize(this);

            base.Initialize();
        }
    }
}
