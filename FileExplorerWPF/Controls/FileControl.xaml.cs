using System;
using System.Collections;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace FileExplorerWPF.Files
{
    public partial class FileControl : UserControl
    {
        public FileModel File
        {
            get => this.DataContext as FileModel;
            set => this.DataContext = value;
        }

        public Action<FileModel> NavigateToPathCallback { get; set; }

        public FileControl()
        {
            InitializeComponent();
            File = new FileModel();
        }
        public FileControl(FileModel fileModel)
        {
            InitializeComponent();
            File = fileModel;
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left && e.LeftButton == MouseButtonState.Pressed && e.ClickCount == 2)
            {
                NavigateToPathCallback?.Invoke(File);
            }
        }
        private void UserControl_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                NavigateToPathCallback?.Invoke(File);
            }   
        }
    }
}
