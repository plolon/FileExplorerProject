using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace FileExplorerWPF.Util
{
    /// <summary>
    /// Converts <see cref="System.Drawing.Icon"/> to a <see cref="System.Drawing.Media.ImageSource"/>
    /// </summary>
    public static class IconToImage : IValueConverter
    {
        public static object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value is Icon ico)
            {
                ImageSource = ico.
            }
        }

        public static object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
