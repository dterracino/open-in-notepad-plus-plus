namespace OpenInNotepadPlusPlus
{
    using System;
    
    /// <summary>
    /// Helper class that exposes all GUIDs used across VS Package.
    /// </summary>
    internal sealed partial class PackageGuids
    {
        public const string guidPackageString = "a8d3f4b6-cd76-47ab-a0dc-4e42869cea9b";
        public const string guidOpenInVsCmdSetString = "f5e04065-ce59-4638-a312-e6eb6cc73dbc";
        public const string guidIconsString = "f5e04065-ce59-4638-a312-e6eb6cc73dbc";
        public static Guid guidPackage = new Guid(guidPackageString);
        public static Guid guidOpenInVsCmdSet = new Guid(guidOpenInVsCmdSetString);
        public static Guid guidIcons = new Guid(guidIconsString);
    }
    /// <summary>
    /// Helper class that encapsulates all CommandIDs uses across VS Package.
    /// </summary>
    internal sealed partial class PackageIds
    {
        public const int OpenInNotepadPlusPlus = 0x0100;
        public const int NotepadPlusPlus = 0x0001;
    }
}
