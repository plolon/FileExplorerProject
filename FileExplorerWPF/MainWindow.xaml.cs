using FileExplorerWPF.Explorer;
using FileExplorerWPF.FileOperations;
using FileExplorerWPF.ViewModel;
using System.Windows;
using System.Windows.Controls;

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
            Model.TryNavigateTo(null, FileItemsType.Left);
            Model.TryNavigateTo(null, FileItemsType.Right);
            DragDropHelper.isDragging = false;
        }
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
            if(e.LeftButton == System.Windows.Input.MouseButtonState.Pressed)
            {
                ListBox parent = sender as ListBox;
                object data = leftListBox.SelectedItem;
                if(data != null)
                {
                    DragDropHelper.isDragging = true;
                    DragDrop.DoDragDrop(parent, data, DragDropEffects.Copy);
                }
                DragDropHelper.isDragging = false;
            }
        }

        private void rightListBox_Drop(object sender, DragEventArgs e)
        {
            if (DragDropHelper.isDragging)
            {
                MessageBox.Show("XD");
                DragDropHelper.isDragging = false;
            }
        }
    }
}