using System;
using System.Globalization;
using System.Windows.Data;

namespace myServices.Converters
{
    /// <summary>
    /// Get status of process and parameter(Start or Stop)
    /// return True if command is enable
    /// </summary>
    internal class StatusConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return false;

            DataItemViewModel item = value as DataItemViewModel;

            if (item == null)
                return false;

            if (item.Status.Equals("Running") && parameter.Equals("Stop"))
            {
                return true;
            }

            if (item.Status.Equals("Stopped") && parameter.Equals("Start"))
            {
                return true;
            }

            return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
