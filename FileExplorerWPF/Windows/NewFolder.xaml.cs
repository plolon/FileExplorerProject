using FileExplorerWPF.Util;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace FileExplorerWPF.Windows
{
    /// <summary>
    /// Interaction logic for NewFolder.xaml
    /// </summary>
    public partial class NewFolder : Window
    {
        public string DirectoryName { get; private set; }
        public bool Create { get; private set; }

        public Icon Ico { get; set; }

        public NewFolder()
        {
            InitializeComponent();
            Ico = IconHelper.GetIconOfFile(Environment.SpecialFolder.ProgramFiles.ToString(), false, true);
            Create = false;
            icon.Source = Ico.ToImageSource();
        }

        private void Cancel(object sender, RoutedEventArgs e)
        {
            Create = false;
        }

        private void CreateFolder(object sender, RoutedEventArgs e)
        {
            DirectoryName = FolderName.Text;
            Create = true;
            this.Close();
        }
    }
}
