using FileExplorerWPF.Files;
using System;
using System.Drawing;
using System.Windows;

namespace FileExplorerWPF.Windows
{
    /// <summary>
    /// Interaction logic for RemoveWindow.xaml
    /// </summary>
    public partial class RemoveWindow : Window
    {
        public RemoveWindow(FileModel fileModel)
        {
            InitializeComponent();
            this.DataContext = fileModel;
        }

        private void btnDialogOk_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        private void Window_ContentRendered(object sender, EventArgs e)
        {

        }
    }
}
