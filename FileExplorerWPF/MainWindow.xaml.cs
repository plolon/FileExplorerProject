using FileExplorerWPF.Explorer;
using FileExplorerWPF.Files;
using FileExplorerWPF.ViewModel;
using System;
using System.Windows;

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
        public MainWindow()
        {
            InitializeComponent();
            // test file
            //FileModel fileModel = new FileModel()
            //{
            //    Name = "testName.txt",
            //    Path = "testPath",
            //    DateCreated = DateTime.Now,
            //    DateModified = DateTime.Now,
            //    Type = FileType.File,
            //    SizeBytes = 2194242,
            //};
            //FileControl fileControl = new FileControl(fileModel);
            //Model.AddFile(fileControl);
            Model.TryNavigateTo("");
        }

        private void ComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            string path = driveSelector.SelectedItem.ToString();
            Model.TryNavigateTo(path);
        }

        private void TextBlock_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            MessageBox.Show("twuj stary");
        }
    }
}