using FileExplorerWPF.Files;
using System.Collections.Generic;

namespace FileExplorerWPF.FileOperations
{
    public static class DragDropHelper
    {
        public static bool isDragging { get; set; }

        public static void Move(this string file, string destination)
        {

        }

        public static List<string> GetSelectedFiles(this System.Collections.IList data)
        {
            List<string> files = new List<string>();
            foreach(var file in data)
            {
                var xd = (FileControl)file;
                files.Add(xd.File.Path);
            }
            return files;
        }
    }
}
