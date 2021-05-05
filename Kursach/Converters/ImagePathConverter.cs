using System;
using System.Globalization;
using System.Windows.Data;

namespace Kursach
{
    public class ImagePathConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string imageFile = (string)value;
            string imageFolderPath = (string)parameter;

            // warnings fix
            if (imageFolderPath == "../Images/PagesHeaderImages" && imageFile == null) imageFile = "1";

            Uri imagePath = new Uri($"{imageFolderPath}/{imageFile}.jpg", UriKind.Relative);
            return imagePath;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
