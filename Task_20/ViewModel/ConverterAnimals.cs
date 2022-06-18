using System;
using System.Globalization;
using System.Windows.Data;

namespace Task_20.ViewModel
{
    public  class GGGG : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            string value = values[1].ToString();

            string data = (string)values[0] + '.' + value.Substring(value.IndexOf(' ') +1);

            return data;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
