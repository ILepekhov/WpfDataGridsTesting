using DataGrids.Shared.Model;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace DataGrids.Shared.ViewModel;

public sealed class SlideTaskViewModel : ReactiveObject
{
    private readonly SlideTask _slideTask;

    public string Title { get; }
    public int Slot => _slideTask.Slot.Position;
    public Magazine Magazine => _slideTask.Slot.ParentMagazine;
    public Profile Profile => _slideTask.Profile;
    public string Directory => _slideTask.Directory;
    [Reactive]
    public SlideState State { get; set; }

    public SlideTaskViewModel(SlideTask slideTask)
    {
        _slideTask = slideTask;
        Title = $"{slideTask.Slot.Position + 1}: {slideTask.Title}";
        State = slideTask.State;
    }
}
