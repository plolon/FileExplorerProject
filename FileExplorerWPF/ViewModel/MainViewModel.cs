using FileExplorerWPF.Explorer;
using FileExplorerWPF.Files;
using FileExplorerWPF.Util;
using FileExplorerWPF.Util.Helpers;
using FileExplorerWPF.Utils;
using REghZyFramework.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;

namespace FileExplorerWPF.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        public ObservableCollection<FileControl> FileItems { get; set; }
        public List<string> DriveList { get; set; }

        public MainViewModel()
        {
            FileItems = new ObservableCollection<FileControl>();
            DriveList = DriveHelper.AvailableDrives();
        }

        #region Navigation

        public void TryNavigateTo(string path)
        {
            // drive
            if (string.IsNullOrEmpty(path))
            {
                ClearFiles();
                    
                foreach (var drive in Fetcher.GetDrives())
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
                //create goBack file
                FileModel back = new FileModel()
                {
                    Icon = new System.Drawing.Icon("parentW.ico"),
                    Name = "..",
                    Path = path.GetParentDirectory()
                };
                FileControl fileContro = CreateFileControl(back);
                AddFile(fileContro);

                //get existing files
                foreach (var file in Fetcher.GetFiles(path))
                {
                    FileControl fileControl = CreateFileControl(file);
                    AddFile(fileControl);
                }

                foreach (var dir in Fetcher.GetDirectories(path))
                {
                    FileControl fileControl = CreateFileControl(dir);
                    AddFile(fileControl);
                }
            }
            else
            {
                throw new System.Exception($"IDK what just happened {path}");
            }
        }

        public void NavigateFrom(FileModel model)
        {
            TryNavigateTo(model.Path);
        }

        #endregion Nvigation

        #region Sorting

        public void Sort(SortBy sortBy, SortType sortType)
        {
            switch (sortBy)
            {
                case SortBy.Name:
                    break;
                case SortBy.DateCreated:
                    break;
                case SortBy.DateModified:
                    break;
                case SortBy.Type:
                    break;
                case SortBy.Size:
                    break;
            }
        }

        #endregion Sorting

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
