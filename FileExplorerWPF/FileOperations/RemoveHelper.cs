using FileExplorerWPF.Utils;
using System;
using System.IO;
using System.Windows;

namespace FileExplorerWPF.FileOperations
{
    public static class RemoveHelper
    {
        public static void RemoveFile(this string file)
        {

            if (file.IsFile())
            {
                File.Delete(file);
            }
            else if (file.IsDirectory())
            {
                try
                {
                    Directory.Delete(file);
                }
                catch (IOException e)
                {
                    MessageBoxResult result = MessageBox.Show($"Remove: {file.GetFileName()}, with everything inside?", $"{e.Message}", MessageBoxButton.YesNo);
                    if (result == MessageBoxResult.Yes)
                    {
                        Directory.Delete(file, true);
                    }
                    else { } //do nothing
                }
            }

        }
    }
}
