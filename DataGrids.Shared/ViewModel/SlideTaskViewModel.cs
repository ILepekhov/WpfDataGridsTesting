using DataGrids.Shared.Model;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace DataGrids.Shared.ViewModel;

public sealed class SlideTaskViewModel : ReactiveObject
{
    public string Title { get; }
    public int Slot { get; }
    public Magazine Magazine { get; }
    public Profile Profile { get; }
    public string Directory { get; }
    [Reactive]
    public SlideState State { get; set; }

    public SlideTaskViewModel(SlideTask slideTask)
    {
        Title = $"{slideTask.MagazineSlot.Position + 1}: {slideTask.Title}";
        Slot = slideTask.MagazineSlot.Position;
        Magazine = slideTask.MagazineSlot.ParentMagazine;
        Profile = slideTask.Profile;
        Directory = slideTask.Directory;
        State = slideTask.State;
    }
}
