using System;
using System.Globalization;
using System.Windows.Data;

namespace ShoppingList
{
    public class ItemVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type? targetType = null, object? parameter = null, CultureInfo? culture = null) =>
            value is Item ? "Visible" : "Hidden";

        public object ConvertBack(object value, Type? targetType = null, object? parameter = null, CultureInfo? culture = null) =>
            throw new InvalidOperationException();
    }
}
