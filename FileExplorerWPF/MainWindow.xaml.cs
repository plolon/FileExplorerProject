using FileExplorerWPF.Explorer;
using FileExplorerWPF.ViewModel;
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
            Model.TryNavigateTo(null, FileItemsType.Left);
            Model.TryNavigateTo(null, FileItemsType.Right);
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
    }
}