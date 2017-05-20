using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace IKEA.UiFramework.BoilerPlate.UWP.Common.Converters
{
    public class BoolToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (targetType == typeof(Visibility))
            {
                return (bool)value ? Visibility.Visible : Visibility.Collapsed;
            }
            throw new ArgumentException("Error while converting boolean",
                targetType.FullName);
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return null;
        }
    }
}

