using FileExplorerWPF.Files;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace FileExplorerWPF.Util.Helpers
{
    public static class SortingHelper
    {
        public static List<FileModel> SortByName(this ObservableCollection<FileControl> files, SortType type)
        {
            List<FileModel> models = files.Select(x => x.File).ToList();
            if(type == SortType.Ascending)
                return models.Where(x => x.Name != ".." && x.DateCreated != null).OrderBy(x => x.Name).ToList();
            else
                return models.Where(x => x.Name != ".." && x.DateCreated != null).OrderByDescending(x => x.Name).ToList();
        }  
        public static List<FileModel> SortByDateCreated(this ObservableCollection<FileControl> files, SortType type)
        {
            List<FileModel> models = files.Select(x => x.File).ToList();
            if(type == SortType.Ascending)
                return models.Where(x => x.Name != ".." && x.DateCreated != null).OrderBy(x => x.DateCreated).ToList();
            else
                return models.Where(x => x.Name != ".." && x.DateCreated != null).OrderByDescending(x => x.DateCreated).ToList();
        }       
        public static List<FileModel> SortByDateModified(this ObservableCollection<FileControl> files, SortType type)
        {
            List<FileModel> models = files.Select(x => x.File).ToList();
            if(type == SortType.Ascending)
                return models.Where(x => x.Name != ".." && x.DateCreated != null).OrderBy(x => x.DateModified).ToList();
            else
                return models.Where(x => x.Name != ".." && x.DateCreated != null).OrderByDescending(x => x.DateModified).ToList();
        }     
        public static List<FileModel> SortByType(this ObservableCollection<FileControl> files, SortType type)
        {
            List<FileModel> models = files.Select(x => x.File).ToList();
            if(type == SortType.Ascending)
                return models.Where(x => x.Name != ".." && x.DateCreated != null).OrderBy(x => x.Type).ToList();
            else
                return models.Where(x => x.Name != ".." && x.DateCreated != null).OrderByDescending(x => x.Type).ToList();
        }     
        public static List<FileModel> SortBySize(this ObservableCollection<FileControl> files, SortType type)
        {
            List<FileModel> models = files.Select(x => x.File).ToList();
            if(type == SortType.Ascending)
                return models.Where(x => x.Name != ".." && x.DateCreated != null).OrderBy(x => x.SizeBytes).ToList();
            else
                return models.Where(x => x.Name != ".." && x.DateCreated != null).OrderByDescending(x => x.SizeBytes).ToList();
        }
    }
}
