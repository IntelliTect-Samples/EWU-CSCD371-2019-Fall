using System;
using System.Globalization;
using System.Windows.Data;

namespace ShoppingList
{
    public class PersonAgeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType = null, object parameter = null, CultureInfo culture = null)
        {
            if (value is Person person)
            {
                int age = DateTime.Now.Year - person.DOB.Year;
                return age;
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new InvalidOperationException();
        }
    }
}
