using FileExplorerWPF.Util;
using System;
using System.Windows.Controls;

namespace FileExplorerWPF.Files
{
    /// <summary>
    /// Interaction logic for FileControl.xaml
    /// </summary>
    public partial class FileControl : UserControl
    {
        public FileModel File
        {
            get => this.DataContext as FileModel;
            set => this.DataContext = value;
        }

        /// <summary>
        /// A callback used for navigating to the path
        /// </summary>
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
    }
}
