using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Data;

namespace ShoppingList
{
    public class VisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type? targetType = null, object? parameter = null, CultureInfo? culture = null)
        {
            if(value is Item)
            {
                return "Visible";
            }
            return "Collapsed";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new InvalidOperationException();
        }
    }
}
