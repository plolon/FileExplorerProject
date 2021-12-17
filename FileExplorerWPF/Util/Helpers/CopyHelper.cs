using FileExplorerWPF.FileOperations;
using FileExplorerWPF.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileExplorerWPF.Util.Helpers
{
    public static class CopyHelper
    {
        public static bool HasClipBoard = false;

        private static List<string> clipBoard;
        public static List<string> ClipBoard
        {
            get
            {
                var buffer = clipBoard;
                HasClipBoard = false;
                clipBoard.Clear();
                return buffer;
            }
            set
            {
                HasClipBoard = true;
                clipBoard = value;
            }
        }

        public static void CopyTo(string path)
        {
            if (HasClipBoard)
            {
                foreach (var file in clipBoard)
                {
                    if (!file.IsDrive())
                        file.Move(path);
                }
            }
        }
    }
}
