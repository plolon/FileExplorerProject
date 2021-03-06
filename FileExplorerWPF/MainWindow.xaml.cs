using FileExplorerWPF.Explorer;
using FileExplorerWPF.FileOperations;
using FileExplorerWPF.Util.Helpers;
using FileExplorerWPF.Utils;
using FileExplorerWPF.ViewModel;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace FileExplorerWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainViewModel Model
        {
            get => this.DataContext as MainViewModel;
            set => this.DataContext = value;
        }

        public FileItemsType? Current = null;

        public MainWindow()
        {
            InitializeComponent();
            Model.TryNavigateTo(null, FileItemsType.Left);
            Model.TryNavigateTo(null, FileItemsType.Right);
            DragDropHelper.isDragging = false;
        }

        public void RemoveFiles()
        {
            if (Current == FileItemsType.Left)
            {
                leftListBox.SelectedItems.GetSelectedFiles().RemoveFiles();
                Model.Refresh();
            }
            else if (Current == FileItemsType.Right)
            {
                rightListBox.SelectedItems.GetSelectedFiles().RemoveFiles();
                Model.Refresh();
            }
        }

        public void CreateFolder()
        {
            if (Current == FileItemsType.Left)
            {
                string path = Model.CurrentPathLeft;
                if (!string.IsNullOrEmpty(path))
                {
                    CreateHelper.CreateFolder(path);
                    Model.Refresh();
                }
            }
            else if (Current == FileItemsType.Right)
            {
                string path = Model.CurrentPathRight;
                if (!string.IsNullOrEmpty(path))
                {
                    CreateHelper.CreateFolder(path);
                    Model.Refresh();
                }
            }
        }

        public void ChangeName()
        {
            if (Current == FileItemsType.Left)
            {
                MessageBox.Show("Changenameleft");
            }
            else if (Current == FileItemsType.Right)
            {
                MessageBox.Show("Changenameright");
            }
        }

        public void Copy()
        {
            if (Current == FileItemsType.Left)
            {
                List<string> files = leftListBox.SelectedItems.GetSelectedFiles();
                CopyHelper.ClipBoard = files;
            }
            else if (Current == FileItemsType.Right)
            {
                List<string> files = rightListBox.SelectedItems.GetSelectedFiles();
                CopyHelper.ClipBoard = files;
            }
        }

        public void Paste()
        {
            if (Current == FileItemsType.Left)
            {
                CopyHelper.CopyTo(Model.CurrentPathLeft);
                Model.Refresh();
            }
            else if (Current == FileItemsType.Right)
            {
                CopyHelper.CopyTo(Model.CurrentPathRight);
                Model.Refresh();
            }
        }

        #region Controls

        private void driveSelectorLeft_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            string path = driveSelectorLeft.SelectedItem.ToString();
            Model.TryNavigateTo(path, FileItemsType.Left);
        }

        private void driveSelectorRight_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            string path = driveSelectorRight.SelectedItem.ToString();
            Model.TryNavigateTo(path, FileItemsType.Right);
        }

        private void leftListBox_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (e.LeftButton == System.Windows.Input.MouseButtonState.Pressed)
            {
                ListBox parent = sender as ListBox;
                List<string> files = leftListBox.SelectedItems.GetSelectedFiles();
                if (files != null && CheckDragging(files))
                {
                    DragDropHelper.isDragging = true;
                    DragDrop.DoDragDrop(parent, files, DragDropEffects.Copy);
                }
                DragDropHelper.isDragging = false;
            }
        }
        private void rightListBox_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (e.LeftButton == System.Windows.Input.MouseButtonState.Pressed)
            {
                ListBox parent = sender as ListBox;
                List<string> files = rightListBox.SelectedItems.GetSelectedFiles();
                if (files != null && CheckDragging(files))
                {
                    DragDropHelper.isDragging = true;
                    DragDrop.DoDragDrop(parent, files, DragDropEffects.Copy);
                }
                DragDropHelper.isDragging = false;
            }
        }

        private void leftListBox_Drop(object sender, DragEventArgs e)
        {
            if (DragDropHelper.isDragging)
            {
                bool needRefresh = false;
                DragDropHelper.isDragging = false;
                List<string> files = e.Data.GetData(typeof(List<string>)) as List<string>;

                foreach (string file in files)
                {
                    needRefresh = true;
                    file.Move(Model.CurrentPathLeft);
                }
                if (needRefresh)
                    Model.Refresh();
            }
        }

        private void rightListBox_Drop(object sender, DragEventArgs e)
        {
            if (DragDropHelper.isDragging)
            {
                bool needRefresh = false;
                DragDropHelper.isDragging = false;
                List<string> files = e.Data.GetData(typeof(List<string>)) as List<string>;

                foreach (string file in files)
                {
                    needRefresh = true;
                    file.Move(Model.CurrentPathRight);
                }
                if (needRefresh)
                    Model.Refresh();
            }
        }

        private bool CheckDragging(List<string> files)
        {
            foreach (var file in files)
            {
                if (file.IsDrive())
                    return false;
            }
            return true;
        }

        private void Window_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.F8)
            {
                RemoveFiles();
            }
            if (e.Key == Key.F9)
            {
                CreateFolder();
            }
        }

        #endregion Controls
    }
}