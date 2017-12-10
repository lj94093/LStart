using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace LStart
{
    [ValueConversion(typeof(String), typeof(ImageSource))]
    public class IconConverter:IValueConverter
    {
        public object Convert(Object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) return DependencyProperty.UnsetValue;
            var path = Config.WindowConfig.Relative2Absolute(value as string);
            Icon icon=null;
            if (File.Exists(path)) icon = Icon.ExtractAssociatedIcon(path);
            else return DependencyProperty.UnsetValue;
            var hBitmap = icon.ToBitmap().GetHbitmap();
            ImageSource source = Imaging.CreateBitmapSourceFromHBitmap(hBitmap, IntPtr.Zero, Int32Rect.Empty,
                BitmapSizeOptions.FromEmptyOptions());
            return source;
            
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
