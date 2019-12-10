using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Data;
using System.Windows.Navigation;

namespace ShoppingList
{
    public class ItemVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type? targetType,  object? parameter, CultureInfo? culture)
        {
            return value is Item ? "Visible" : "Hidden";
        }

        public object ConvertBack(object value, Type? targetType, object? parameter, CultureInfo? culture)
        {
            throw new InvalidOperationException();
        }
    }
}
