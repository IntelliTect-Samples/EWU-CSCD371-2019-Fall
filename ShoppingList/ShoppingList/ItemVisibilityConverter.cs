using System;
using System.Globalization;
using System.Windows.Data;

namespace ShoppingList
{
    public class ItemVisibilityConverter : IValueConverter
    {
        public object Convert(object? value, Type? targetType = null, object? parameter = null, CultureInfo? culture = null)
        {
            if (value is Item)
                return "Visible";

            return "Hidden";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new InvalidOperationException();
        }
    }
}