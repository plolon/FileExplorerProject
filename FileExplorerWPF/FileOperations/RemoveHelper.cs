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
            try
            {
                if (file.IsFile())
                    File.Delete(file);
                else if (file.IsDirectory())
                    Directory.Delete(file);
            }
            catch (IOException e)
            {
                MessageBox.Show($"{e.Message}",$"{e.GetType()}");
            }
        }
    }
}
