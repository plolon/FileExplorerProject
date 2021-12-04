using FileExplorerWPF.Explorer;
using FileExplorerWPF.Files;
using FileExplorerWPF.Utils;
using REghZyFramework.Utilities;
using System.Collections.ObjectModel;
using System.Windows;

namespace FileExplorerWPF.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        public ObservableCollection<FileControl> FileItems { get; set; }
        public MainViewModel()
        {
            FileItems = new ObservableCollection<FileControl>();
        }

        #region Navigation

        public void TryNavigateTo(string path)
        {
            // drive
            if(string.IsNullOrEmpty(path))
            {
                ClearFiles();

                foreach(var drive in Fetcher.GetDrives())
                {
                    FileControl fileControl = CreateFileControl(drive);
                    AddFile(fileControl);
                }
            }
            else if (path.IsFile())
            {
                //open file
                MessageBox.Show($"Opening {path}");
            }
            else if (path.IsDirectory())
            {
                ClearFiles();

                foreach(var file in Fetcher.GetFiles(path))
                {
                    FileControl fileControl = CreateFileControl(file);
                    AddFile(fileControl);
                }

                foreach(var dir in Fetcher.GetDirectories(path))
                {
                    FileControl fileControl = CreateFileControl(dir);
                    AddFile(fileControl);
                }
            }
            else
            {
                throw new System.Exception("IDK what just happened XD");
            }
        }

        public void NavigateFrom(FileModel model)
        {
            TryNavigateTo(model.Path);
        }

        #endregion Nvigation

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

        public FileControl CreateFileControl(FileModel model)
        {
            FileControl fileControl = new FileControl(model);
            SetupFileControlCallbacks(fileControl);
            return fileControl;
        }

        public void SetupFileControlCallbacks(FileControl fileControl)
        {
            fileControl.NavigateToPathCallback = NavigateFrom;
        }
    }
}
