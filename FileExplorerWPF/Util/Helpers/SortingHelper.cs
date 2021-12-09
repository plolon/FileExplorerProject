using FileExplorerWPF.Files;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace FileExplorerWPF.Util.Helpers
{
    public static class SortingHelper
    {
        public static ObservableCollection<FileControl> SortByName(this ObservableCollection<FileControl> files)
        {
            var first = files.Where(x => x.File.Name == "..").FirstOrDefault();
            var rest = files.Where(x => x.File.Name != "..").OrderBy(x => x.File.Name).ToList();

            ObservableCollection<FileControl> result = new ObservableCollection<FileControl>() { first };
            foreach(var item in rest)
            {
                result.Add(item);
            }
            return result;
        }
    }
}
