using Microsoft.Win32;

namespace Libs.CSharp
{
    public class FileSelection
    {
        /// <summary>
        /// filters = "Excel (*.xlsx)|*.xlsx"
        /// filters = "Data (*.json)|*.json"
        /// </summary>
        public static string Save(string filter, string initialName = "")
        {
            string selectedPath = null;
            SaveFileDialog dialog = new SaveFileDialog
            {
                //Title = "Browse for ...",
                //CheckFileExists = true,
                //CheckPathExists = true,
                //DefaultExt = "json",
                //ReadOnlyChecked = true,
                //ShowReadOnly = true
                RestoreDirectory = true,
                Filter = filter,
                FileName = initialName
            };
            bool? rs = dialog.ShowDialog();
            if (rs.HasValue) if (rs.Value) selectedPath = dialog.FileName;
            return selectedPath;
        }

        /// <summary>
        /// filters = "Excel (*.xlsx)|*.xlsx",
        /// </summary>
        public static string Open(string filters)
        {
            string selectedPath = null;
            OpenFileDialog dialog = new OpenFileDialog
            {
                //Title = "Browse for ...",
                //CheckPathExists = true,
                //DefaultExt = "json",
                //ReadOnlyChecked = true,
                //ShowReadOnly = true
                RestoreDirectory = true,
                Filter = filters,
                CheckFileExists = true,
            };
            bool? rs = dialog.ShowDialog();
            if (rs.HasValue) if (rs.Value) selectedPath = dialog.FileName;
            return selectedPath;
        }
    }
}
