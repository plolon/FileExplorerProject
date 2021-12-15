using FileExplorerWPF.Files;
using FileExplorerWPF.Util;
using FileExplorerWPF.Utils;
using FileExplorerWPF.Windows;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;

namespace FileExplorerWPF.FileOperations
{
    public static class RemoveHelper
    {
        public static void RemoveFiles(this List<string> files)
        {
            bool acceptAll = false;

            foreach (string file in files)
            {
                if (file.IsFile())
                {
                    FileInfo fileInfo = new FileInfo(file);
                    FileModel fileModel = new FileModel()
                    {
                        Icon = IconHelper.GetIconOfFile(file, false, false),
                        Name = fileInfo.Name,
                        Path = fileInfo.FullName,
                        DateModified = fileInfo.LastWriteTime,
                        SizeBytes = fileInfo.Length,
                    };
                    using(StreamWriter f = new StreamWriter("pupki.txt"))
                    {
                        f.Write("{0} {1} {2} {3}", fileModel.Name, fileModel.Path, fileModel.DateModified, fileModel.SizeBytes);
                    }

                    if (!acceptAll)
                    {
                        ShowDialog(fileModel, out acceptAll);
                            //File.Delete(file);
                    }
                    
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
        private static bool ShowDialog(FileModel model, out bool acceptAll)
        {
            acceptAll = false;
            RemoveWindow inputDialog = new RemoveWindow(model);
            if (inputDialog.ShowDialog() == true)
            {
                return true;
            }
            return true;
        }
    }
    
}
