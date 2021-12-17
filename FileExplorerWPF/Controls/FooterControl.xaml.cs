using System.Windows;
using System.Windows.Controls;

namespace FileExplorerWPF.Controls
{
    /// <summary>
    /// Interaction logic for FooterControl.xaml
    /// </summary>
    public partial class FooterControl : UserControl
    {
        public FooterControl()
        {
            InitializeComponent();
        }

        private void Remove(object sender, RoutedEventArgs e)
        {
            MainWindow window = Window.GetWindow(this) as MainWindow;
            window.RemoveFiles();
        }

        private void Create(object sender, RoutedEventArgs e)
        {
            MainWindow window = Window.GetWindow(this) as MainWindow;
            window.CreateFolder();
        }

        private void ChangeName(object sender, RoutedEventArgs e)
        {
            MainWindow window = Window.GetWindow(this) as MainWindow;
            window.ChangeName();
        }

        private void Paste(object sender, RoutedEventArgs e)
        {
            MainWindow window = Window.GetWindow(this) as MainWindow;
            window.Paste();
        }

        private void Copy(object sender, RoutedEventArgs e)
        {
            MainWindow window = Window.GetWindow(this) as MainWindow;
            window.Copy();
        }
    }
}
