using System;
using System.Globalization;
using System.Windows.Data;
namespace ShoppingList
{
    public class VisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type? targetType = null, object? parameter = null, CultureInfo? culture = null)
        {
            if (value is ShopItem)
            {
                return "Visible";
            }
            return "Collapsed";
        }

        public object ConvertBack(object value, Type? targetType = null, object? parameter = null, CultureInfo? culture = null)
        {
            throw new InvalidOperationException();
        }
    }
}
