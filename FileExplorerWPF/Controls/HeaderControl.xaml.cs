using FileExplorerWPF.Util.Helpers;
using System.Windows;
using System.Windows.Controls;

namespace FileExplorerWPF.Controls
{
    /// <summary>
    /// Interaction logic for HeaderControl.xaml
    /// </summary>
    public partial class HeaderControl : UserControl
    {
        private SortType sortType;

        public SortType getSortType()
        {
            if(sortType == SortType.Ascending)
            {
                sortType = SortType.Descending;
                return sortType;
            }
            else
            {
                sortType = SortType.Ascending;
                return sortType;
            }
        }

        public HeaderControl()
        {
            sortType = SortType.Ascending;
            InitializeComponent();
        }
        private void FileName_Click(object sender, RoutedEventArgs e)
        {
            MainWindow window = Window.GetWindow(this) as MainWindow;
            window.Model.Sort(SortBy.Name, getSortType());
        }

        private void DateCreated_Click(object sender, RoutedEventArgs e)
        {
            MainWindow window = Window.GetWindow(this) as MainWindow;
            window.Model.Sort(SortBy.DateCreated, getSortType());
        }

        private void DateModified_Click(object sender, RoutedEventArgs e)
        {
            MainWindow window = Window.GetWindow(this) as MainWindow;
            window.Model.Sort(SortBy.DateModified, getSortType());
        }

        private void Type_Click(object sender, RoutedEventArgs e)
        {
            MainWindow window = Window.GetWindow(this) as MainWindow;
            window.Model.Sort(SortBy.Type, getSortType());
        }

        private void Size_Click(object sender, RoutedEventArgs e)
        {
            MainWindow window = Window.GetWindow(this) as MainWindow;
            window.Model.Sort(SortBy.Size, getSortType());
        }
    }
}
