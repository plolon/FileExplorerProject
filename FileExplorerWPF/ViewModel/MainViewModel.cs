using FileExplorerWPF.Files;
using REghZyFramework.Utilities;
using System.Collections.ObjectModel;

namespace FileExplorerWPF.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        public ObservableCollection<FileControl> FileItems { get; set; }
        public MainViewModel()
        {
            FileItems = new ObservableCollection<FileControl>();
        }
        public void AddFile(FileControl file)
        {
            FileItems.Add(file);
        }
        public void RemoveFile(FileControl file)
        {
            FileItems.Remove(file);
        }
        public void ClearFiles()
        {
            FileItems.Clear();
        }
    }
}
