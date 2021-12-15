using FileExplorerWPF.Files;
using System;
using System.Windows;

namespace FileExplorerWPF.Windows
{
    /// <summary>
    /// Interaction logic for RemoveWindow.xaml
    /// </summary>
    public partial class RemoveWindow : Window
    {
        public FileModel Model { get; set; }

        public RemoveWindow(FileModel fileModel)
        {
            InitializeComponent();
            Model = fileModel;
        }

        private void btnDialogOk_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        private void Window_ContentRendered(object sender, EventArgs e)
        {
            txtAnswer.SelectAll();
            txtAnswer.Focus();
        }

        public string Answer
        {
            get { return txtAnswer.Text; }
        }

    }
}
