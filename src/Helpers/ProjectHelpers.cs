using System;
using EnvDTE;
using EnvDTE80;

namespace OpenInNotepadPlusPlus.Helpers {

    internal static class ProjectHelpers {

        public static string GetSelectedPath(DTE2 dte) {
            var items = (Array)dte.ToolWindows.SolutionExplorer.SelectedItems;

            foreach (UIHierarchyItem selItem in items)
            {
				var item = selItem.Object as ProjectItem;

	            if (item != null)
					//Document.FullName appears to only work for DTSX packages, whereas Properties handles everything else (so far...)
		            return item.Document?.FullName ?? item.Properties?.Item("FullPath").Value.ToString();

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
