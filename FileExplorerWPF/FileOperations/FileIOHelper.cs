using System.Collections.Generic;
using System.IO;

namespace FileExplorerWPF.FileOperations
{
    public static class FileIOHelper
    {
        public static void Move(this string file, string destination, MoveType type)
        {

        }
        public static void Move(this List<string> files, string destination, MoveType type)
        {
            foreach(var file in files)
            {

            }
        }

        public static void Remove(this string file)
        {
            //remvoe file
        }

        public static string Create(string destination)
        {
            //create new file
            return "";
        }

        private static void Move(string file, string destination)
        {
            throw new System.NotImplementedException();
        }

        private static void Copy(string file, string destination)
        {
            throw new System.NotImplementedException();
        }

        private static void Cut(string file, string destination)
        {
            throw new System.NotImplementedException();
        }
    }
}
