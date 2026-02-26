using PrismDemo.Models;
using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;


namespace PrismDemo.Converters
{
    /*
     * [ValueConversion(typeof(DeviceStatus), typeof(Brush))] 特性标记
     * - 明确告诉开发者（和 IDE）：这个转换器的作用是把 DeviceStatus 类型（源类型）转换成 Brush 类型（目标类型）；
     * - 辅助IDE提供智能提示，但不影响程序运行（即使删掉这个特性，转换器功能依然正常）。
     * - DeviceStatus(设备状态) -> Brush(颜色)
     */

    /// <summary>
    /// 将设备状态转换成UI颜色
    /// </summary>
    [ValueConversion(typeof(DeviceStatus), typeof(Brush))]
    public class StatusToColorConverter : IValueConverter
    {

        // 正向转换：状态→颜色
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // 特殊情况，返回黑色
            if(value == null || !(value is DeviceStatus)) {
                return Brushes.Black;
            }

            // 设备状态切换: Normal -> Error -> Offline
            return (DeviceStatus)value switch
            {
                DeviceStatus.Normal => Brushes.Green,
                DeviceStatus.Error => Brushes.Red,
                DeviceStatus.Offline => Brushes.Gray,
                _ => Brushes.Black
            };
        }

        // 反向转换（无需实现）
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

    }

}