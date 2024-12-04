using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUI.Components
{
    class DateToColorConverter: IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is DateTime expiryDate)
            {
                var daysUntilExpiry = (expiryDate - DateTime.Now).Days;

                if(daysUntilExpiry <= 45 )
                    return Colors.Red;
                else if (daysUntilExpiry <= 90)
                    return Colors.Yellow;
                else 
                    return Colors.Green;
            }

            return Colors.Transparent;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) 
        {
            throw new NotImplementedException();
        }
    }
}
