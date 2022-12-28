namespace DataGrids.Shared.Model;

public sealed class SlideTask
{
    public string Title { get; set; }
    public MagazineSlot MagazineSlot { get; set; }
    public Profile Profile { get; set; }
    public string Directory { get; set; }
    public SlideState State { get; set; }
}
