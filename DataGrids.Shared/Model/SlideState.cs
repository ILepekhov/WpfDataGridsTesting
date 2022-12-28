using Ardalis.SmartEnum;

namespace DataGrids.Shared.Model;

public sealed class SlideState : SmartEnum<SlideState>
{
    public static readonly SlideState WaitingForPreview = new("Ожидает превью", 1);
    public static readonly SlideState Preview = new("Превью", 2);
    public static readonly SlideState WaitingForScan = new("Ожидает сканирования", 3);
    public static readonly SlideState Scan = new("Сканирование", 4);

    private SlideState(string name, int value) : base(name, value)
    {
    }
}
