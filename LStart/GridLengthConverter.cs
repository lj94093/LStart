using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace LStart
{
    [ValueConversion(typeof(double), typeof(GridLength))]
    public class GridLengthConverter : IValueConverter
    {
        public object Convert(Object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) return DependencyProperty.UnsetValue;
            return new GridLength((double)value);
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var width = (GridLength)value;
            return width.Value;
        }
    }
}
