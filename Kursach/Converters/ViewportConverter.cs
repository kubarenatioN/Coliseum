using System;
using System.Globalization;
using System.Windows.Data;

namespace Kursach
{
    [ValueConversion(typeof(double), typeof(double))]
    public class ViewportConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            double viewportHeight = (double)value;
            double divideBy = double.Parse((string)parameter);
            return viewportHeight/divideBy;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
