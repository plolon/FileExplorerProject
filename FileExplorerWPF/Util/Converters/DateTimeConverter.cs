using System;
using System.Globalization;
using System.Windows.Data;

namespace FileExplorerWPF.Util.Converters
{
    class DateTimeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value is DateTime date)
                return String.Format("{0:d/M/yyyy HH:mm:ss}", date);
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
