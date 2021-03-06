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
                if (!acceptAll)
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
                        if (ShowDialog(fileModel, out acceptAll, "Are you sure you want to permamently delete this file?"))
                            File.Delete(file);
                    }
                    else if (file.IsDirectory())
                    {
                        try
                        {
                            Directory.Delete(file);
                        }
                        catch (IOException)
                        {
                            DirectoryInfo dInfo = new DirectoryInfo(file);
                            FileModel dModel = new FileModel()
                            {
                                Icon = IconHelper.GetIconOfFile(file, false, true),
                                Name = dInfo.Name,
                                Path = dInfo.FullName,
                                DateModified = dInfo.LastWriteTime,
                                SizeBytes = null
                            };
                            if (ShowDialog(dModel, out acceptAll, "Are you sure you want to permamently delete this directory?"))
                                Directory.Delete(file, true);
                        }
                    }
                }
                else
                {
                    if (file.IsFile())
                        File.Delete(file);
                    else if (file.IsDirectory())
                        Directory.Delete(file, true);
                }
            }
        }
        private static bool ShowDialog(FileModel model, out bool acceptAll, string message)
        {
            acceptAll = false;
            RemoveWindow inputDialog = new RemoveWindow(model, message);
            if (inputDialog.ShowDialog() == true)
            {
                return false;
            }
            switch (inputDialog.Response)
            {
                case RemoveWindow.Answer.Yes:
                    return true;
                case RemoveWindow.Answer.No:
                    return false;
                case RemoveWindow.Answer.YesToAll:
                    acceptAll = true;
                    return true;
            }
            return false;
        }
    }
}
