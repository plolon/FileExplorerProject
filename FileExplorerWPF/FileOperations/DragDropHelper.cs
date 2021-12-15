using FileExplorerWPF.Files;
using FileExplorerWPF.Utils;
using System.Collections.Generic;
using System.IO;
using System.Windows;

namespace FileExplorerWPF.FileOperations
{
    public static class DragDropHelper
    {
        public static bool isDragging { get; set; }

        public static void Move(this string file, string destination)
        {
            if(file != destination)
            {
                string path = destination;
                if (destination.IsFile())
                {
                    path = destination.GetParentDirectory();
                }

                if (file.IsDirectory())
                {
                    string newPath = string.Format($@"{path}\{file.GetFileName()}");
                    Directory.Move(file, newPath);
                }
                else if (file.IsFile())
                {
                    string newPath = string.Format($@"{path}\{file.GetFileName()}");
                    File.Move(file, newPath);
                }
                else if (file.IsDrive())
                {
                    MessageBox.Show("You cannot move partition");
                }
                else
                {
                    throw new System.Exception("Something went wrong");
                }
            }
        }
    }
}
