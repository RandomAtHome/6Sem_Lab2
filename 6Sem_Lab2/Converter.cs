using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace _6Sem_Lab2
{
    [ValueConversion(typeof(ModelData), typeof(string))]
    class DataModelConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            ModelData modelData = (ModelData)value;
            return "Param value: " + modelData.Parameter + " | Node Count: " + modelData.NodeCount;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
