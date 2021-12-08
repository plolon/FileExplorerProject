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
        public HeaderControl()
        {
            InitializeComponent();
        }
        private void FileName_Click(object sender, RoutedEventArgs e)
        {
            MainWindow window = Window.GetWindow(this) as MainWindow;
            SortingHelper.SortByFileName(window.leftListBox);
        }

        private void DateCreated_Click(object sender, RoutedEventArgs e)
        {

        }

    }
}
