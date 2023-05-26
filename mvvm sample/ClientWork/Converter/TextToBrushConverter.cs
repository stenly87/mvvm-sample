using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Markup;
using System.Windows.Media;

namespace mvvm_sample.ClientWork.Converter
{
    [ValueConversion(typeof(string), typeof(Brush))]
    public class TextToBrushConverter : MarkupExtension, IValueConverter
    {
        // model to view
        // text (HEX) to brush
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string text = value as string;
            if (text.Length != 6)
                return Brushes.Red;
            
            byte r = byte.Parse(text.Substring(0, 2), NumberStyles.HexNumber);
            byte g = byte.Parse(text.Substring(2, 2), NumberStyles.HexNumber);
            byte b = byte.Parse(text.Substring(4, 2), NumberStyles.HexNumber);
            SolidColorBrush brush = new SolidColorBrush(Color.FromRgb(r,g,b));
            return brush;
        }

        // view to model
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        static TextToBrushConverter instance = new();

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return instance;
        }
    }
}
