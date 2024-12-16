using System.Globalization;

namespace MauiApp1.Converters
{
    public class BoolToEyeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool isPassword)
            {
                return isPassword ? "eye_closed.png" : "eye_open.png";
            }
            return "eye_closed.png";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
