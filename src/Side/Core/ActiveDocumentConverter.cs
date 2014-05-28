using System;
using System.Globalization;
using System.Windows.Data;
using Side.Core.CodeBox;

namespace Side.Core
{
    public class ActiveDocumentConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is CodeViewModel)
                return value;

            return Binding.DoNothing;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is CodeViewModel)
                return value;

            return Binding.DoNothing;
        }
    }
}
