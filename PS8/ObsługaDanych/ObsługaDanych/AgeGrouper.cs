using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace ObsługaDanych
{
    class AgeGrouper : IValueConverter
    {
        public int GroupInterval { get; set; }
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value == null)
            {
                return null;
            }
            int age = (int)value;
            int interval = (age / GroupInterval);
            int lowerLimit = interval * GroupInterval;
            int upperLimit = (interval + 1) * GroupInterval;
            return String.Format(culture, "{0} - {1}", lowerLimit, upperLimit);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
