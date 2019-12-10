using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Data;

namespace ShoppingList
{
    public class VisibilityConverter : IValueConverter
    {
        public object Convert(object? value, Type? targetType = null, object? parameter = null, CultureInfo? culture = null)
        {
            return value is ShoppingItem ? "Visible" : "Hidden";
        }

        public object ConvertBack(object? value, Type? targetType = null, object? parameter = null, CultureInfo? culture = null)
        {
            throw new NotImplementedException();
        }
    }
}
