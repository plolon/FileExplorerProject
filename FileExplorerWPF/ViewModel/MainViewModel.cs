using FileExplorerWPF.Explorer;
using FileExplorerWPF.Files;
using FileExplorerWPF.Util;
using FileExplorerWPF.Util.Helpers;
using FileExplorerWPF.Utils;
using REghZyFramework.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace FileExplorerWPF.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        public ObservableCollection<FileControl> FileItemsLeft { get; set; }
        public ObservableCollection<FileControl> FileItemsRight { get; set; }
        public List<string> DriveList { get; set; }

        public MainViewModel()
        {
            FileItemsLeft = new ObservableCollection<FileControl>();
            FileItemsRight = new ObservableCollection<FileControl>();
            DriveList = DriveHelper.AvailableDrives();
        }

        #region Navigation

        public void TryNavigateTo(string path, FileItemsType type)
        {
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
            }
            else
            {
                throw new System.Exception($"IDK what just happened {path}");
            }
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
            foreach(var file in files)
            {
                FileControl fileControl = new FileControl(file);
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
