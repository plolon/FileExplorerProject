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

        public Answer Response { get; set; }

        public RemoveWindow(FileModel fileModel, string message)
        {
            InitializeComponent();
            title.Text = message;
            this.DataContext = fileModel;
            Response = Answer.No; //default
        }

        private void No_Click(object sender, RoutedEventArgs e)
        {
            Response = Answer.No;
            this.Close();
        }
        private void Yes_Click(object sender, RoutedEventArgs e)
        {
            Response = Answer.Yes;
            this.Close();
        }

        private void YesAll_Click(object sender, RoutedEventArgs e)
        {
            Response = Answer.YesToAll;
            this.Close();
        }

        public enum Answer
        {
            Yes, No, YesToAll,
        }

    }
}
