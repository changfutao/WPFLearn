using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace WPFLearn.SingleValueConverter
{
    /// <summary>
    /// 转换器要实现IValueConverter接口
    /// </summary>
    class ForeColorConverter : IValueConverter
    {
        /// <summary>
        /// 表示从源对象到目标的数据转换
        /// </summary>
        /// <param name="value">数据源的值</param>
        /// <param name="targetType">目标属性的类型</param>
        /// <param name="parameter">转换参数</param>
        /// <param name="culture">本地化</param>
        /// <returns></returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value != null && value.ToString() == "我是标题")
            {
                return Brushes.Red;
            }
            return Brushes.Pink;
        }

        /// <summary>
        /// 表示从目标到源的数据转换
        /// </summary>
        /// <param name="value">/param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
