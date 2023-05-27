using System;
using System.Globalization;
using System.Windows.Data;

namespace WpfCharts.Converters
{
    public class DoubleToStringConverter : IValueConverter
    {
        object IValueConverter.Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ((double)value).ToString("F2");
        }

        object IValueConverter.ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
