using FileExplorerWPF.Utils;
using FileExplorerWPF.Windows;
using System.IO;

namespace FileExplorerWPF.FileOperations
{
    public static class CreateHelper
    {
        public static void CreateFolder(string path)
        {
            string folderName = "";
            if (!path.IsFile())
            {
                if (ShowDialog(out folderName))
                {
                    Directory.CreateDirectory($@"{path}\{folderName}");
                }
            }
        }

        private static bool ShowDialog(out string name)
        {
            NewFolder newfolder = new NewFolder();
            name = "";
            if (newfolder.ShowDialog() == true)
            {
                return false;
            }
            if (newfolder.Create)
            {
                name = newfolder.DirectoryName;
                return true;
            }
            return false;
        }
    }
}
