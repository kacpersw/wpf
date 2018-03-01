using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace ObsługaDanych
{
    [ValueConversion(typeof(decimal), typeof(string))]
    class SalaryConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            decimal price = (decimal)value;
            return price*8/10;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string price = value.ToString();
            decimal result;
            if (Decimal.TryParse(price, NumberStyles.Any,culture, out result))
            {
                return result;
            }
            return value;
        }
    }
}
