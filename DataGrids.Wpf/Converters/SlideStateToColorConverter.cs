using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;
using DataGrids.Shared.Model;

namespace DataGrids.Wpf.Converters;

[ValueConversion(typeof(SlideState), typeof(Color))]
public sealed class SlideStateToColorConverter : IValueConverter
{
    public Color WaitingForPreviewColor { get; set; }
    public Color PreviewColor { get; set; }
    public Color WaitingForScanColor { get; set; }
    public Color ScanColor { get; set; }
    public Color DefaultColor { get; set; }

    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is SlideState slideState)
        {
            if (slideState == SlideState.WaitingForPreview)
            {
                return WaitingForPreviewColor;
            }

            if (slideState == SlideState.Preview)
            {
                return PreviewColor;
            }

            if (slideState == SlideState.WaitingForScan)
            {
                return WaitingForScanColor;
            }

            if (slideState == SlideState.Scan)
            {
                return ScanColor;
            }
        }

        return DefaultColor;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return Binding.DoNothing;
    }
}
