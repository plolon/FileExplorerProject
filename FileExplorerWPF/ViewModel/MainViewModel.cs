using FileExplorerWPF.Explorer;
using FileExplorerWPF.Files;
using FileExplorerWPF.Util.Helpers;
using FileExplorerWPF.Utils;
using REghZyFramework.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;

namespace FileExplorerWPF.ViewModel
{
    public class MainViewModel : BaseViewModel, INotifyPropertyChanged
    {
        public ObservableCollection<FileControl> FileItemsLeft { get; set; }
        public ObservableCollection<FileControl> FileItemsRight { get; set; }
        public string CurrentPathLeft { get; set; }
        public string CurrentPathRight { get; set; }
        public List<string> DriveListLeft { get; set; }
        public List<string> DriveListRight { get; set; }

        #pragma warning disable CS0108
        public event PropertyChangedEventHandler PropertyChanged;
        #pragma warning restore CS0108

        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (null != handler)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private string currentDiskL;
        private string currentDiskR;
        public string CurrentDiskL
        {
            get { return currentDiskL; }
            set { currentDiskL = value; NotifyPropertyChanged("CurrentDiskL"); }
        }
        public string CurrentDiskR
        {
            get { return currentDiskR; }
            set { currentDiskR = value; NotifyPropertyChanged("CurrentDiskR"); }
        }

        public MainViewModel()
        {
            FileItemsLeft = new ObservableCollection<FileControl>();
            FileItemsRight = new ObservableCollection<FileControl>();
            DriveListLeft = DriveHelper.AvailableDrives();
            DriveListRight = DriveHelper.AvailableDrives();
        }

        #region Navigation

        public void TryNavigateTo(string path, FileItemsType type)
        {
            if (type == FileItemsType.Left)
                CurrentPathLeft = path;
            else
                CurrentPathRight = path;

            // drive
            if (string.IsNullOrEmpty(path))
            {
                ClearFiles(type);
                foreach (var drive in Fetcher.GetDrives(type))
                {
                    FileControl fileControl = CreateFileControl(drive);
                    AddFile(fileControl, type);
                }
            }
            else if (path.IsFile())
            {
                //open file
                MessageBox.Show($"Opening {path}");
            }
            else if (path.IsDirectory())
            {
                ClearFiles(type);
                AddGoBack(path, type);

                //get existing files
                foreach (var file in Fetcher.GetFiles(path, type))
                {
                    FileControl fileControl = CreateFileControl(file);
                    AddFile(fileControl, type);
                }

                foreach (var dir in Fetcher.GetDirectories(path, type))
                {
                    FileControl fileControl = CreateFileControl(dir);
                    AddFile(fileControl, type);
                }
                if (path.IsDrive())
                {
                    updateDriveList(path, type);
                }
            }
            else
            {
                throw new System.Exception($"IDK what just happened {path}");
            }
        }

        private void updateDriveList(string path, FileItemsType type)
        {
            switch (type)
            {
                case FileItemsType.Left:
                    CurrentDiskL = DriveListLeft.FirstOrDefault(x => x.Equals(path));
                    break;
                case FileItemsType.Right:
                    CurrentDiskR = DriveListRight.FirstOrDefault(x => x.Equals(path));
                    break;
            }
        }

        internal void Refresh()
        {
            TryNavigateTo(CurrentPathLeft, FileItemsType.Left);
            TryNavigateTo(CurrentPathRight, FileItemsType.Right);
        }

        public void NavigateFrom(FileModel model)
        {
            TryNavigateTo(model.Path, model.FileItemsType);
        }

        public void AddGoBack(string path, FileItemsType type)
        {
            FileModel back = new FileModel()
            {
                Icon = new System.Drawing.Icon("parentW.ico"),
                Name = "..",
                Path = path.GetParentDirectory(),
                Type = null,
                FileItemsType = type
            };
            FileControl fileContro = CreateFileControl(back);
            AddFile(fileContro, type);
        }
        public void AddGoBack(FileModel model, FileItemsType type)
        {
            FileControl fileContro = CreateFileControl(model);
            AddFile(fileContro, type);
        }

        #endregion Nvigation

        #region Sorting

        public void Sort(SortBy sortBy, SortType sortType, FileItemsType type)
        {
            List<FileModel> files = new List<FileModel>();
            switch (sortBy)
            {
                case SortBy.Name:
                    files = GetFileItems(type).SortByName(sortType);
                    break;
                case SortBy.DateCreated:
                    files = GetFileItems(type).SortByDateCreated(sortType);
                    break;
                case SortBy.DateModified:
                    files = GetFileItems(type).SortByDateModified(sortType);
                    break;
                case SortBy.Type:
                    files = GetFileItems(type).SortByType(sortType);
                    break;
                case SortBy.Size:
                    files = GetFileItems(type).SortBySize(sortType);
                    break;
            }
            CreateControls(files, type);
        }

        private void CreateControls(List<FileModel> files, FileItemsType type)
        {
            var back = GetFileItems(type)[0].File;
            GetFileItems(type).Clear();
            AddGoBack(back, type);
            foreach (var file in files)
            {
                FileControl fileControl = CreateFileControl(file);
                AddFile(fileControl, type);
            }
        }

        #endregion Sorting

        public void AddFile(FileControl file, FileItemsType type)
        {
            GetFileItems(type).Add(file);
        }
        public void RemoveFile(FileControl file, FileItemsType type)
        {
            GetFileItems(type).Remove(file);
        }
        public void ClearFiles(FileItemsType type)
        {
            GetFileItems(type).Clear();
        }

        public ObservableCollection<FileControl> GetFileItems(FileItemsType type)
        {
            if (type == FileItemsType.Left)
                return FileItemsLeft;
            else
                return FileItemsRight;
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
