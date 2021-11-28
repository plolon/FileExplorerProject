using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace FileExplorerWPF.Util
{
    public static class IconHelper
    {

        [DllImport("gdi32", SetLastError = true)]
        private static extern bool DeleteObject(IntPtr hObject);
        public static ImageSource ToImageSource(this Icon ico)
        {
            Bitmap bitmap = ico.ToBitmap();
            IntPtr hBitmap = bitmap.GetHbitmap();

            ImageSource image = Imaging.CreateBitmapSourceFromHBitmap(hBitmap, IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());

            if (!DeleteObject(hBitmap))
            {
                MessageBox.Show("Failed to delete unused bitmap object");
                return null;
            }
    }
}
