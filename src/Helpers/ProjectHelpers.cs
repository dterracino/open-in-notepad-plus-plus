using System;
using System.IO;
using EnvDTE;
using EnvDTE80;

namespace OpenInNotepadPlusPlus.Helpers {

    internal static class ProjectHelpers {

        public static string GetSelectedPath(DTE2 dte) {
            var items = (Array)dte.ToolWindows.SolutionExplorer.SelectedItems;

            foreach (UIHierarchyItem selItem in items) {
                var item = selItem.Object as ProjectItem;

                if (item != null)
                    return item.Properties.Item("FullPath").Value.ToString();

                var proj = selItem.Object as Project;

	            if (proj != null)
		            return proj.FullName;

                var sol = selItem.Object as Solution;

	            if (sol != null)
		            return sol.FullName;
            }

            return null;
        }
    }
}
