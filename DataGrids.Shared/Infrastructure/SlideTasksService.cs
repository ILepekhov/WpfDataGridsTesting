using DataGrids.Shared.Model;

namespace DataGrids.Shared.Infrastructure;

public sealed class SlideTasksService : ISlideTasksService
{
    private readonly List<Magazine> _magazines = new(CreateMagazines());

    public IEnumerable<SlideTask> GetTasks()
    {
        foreach (var slot in _magazines[0].Slots.Take(5))
        {
            yield return new SlideTask
            {
                Title = "K00121852_001_CD15",
                Profile = Profiles.Normal40x,
                Directory = "slides\\K00121852",
                Slot = slot,
                State = SlideState.WaitingForScan
            };
        }

        foreach (var slot in _magazines[0].Slots.Skip(5))
        {
            yield return new SlideTask
            {
                Title = "K00121852_001_CD15",
                Profile = Profiles.Normal40x,
                Directory = "slides\\K00121852",
                Slot = slot,
                State = SlideState.Scan
            };
        }

        foreach (var slot in _magazines[1].Slots.Take(5))
        {
            yield return new SlideTask
            {
                Title = "K00121852_001_CD15",
                Profile = Profiles.Normal40x,
                Directory = "slides\\K00121852",
                Slot = slot,
                State = SlideState.WaitingForPreview
            };
        }

        foreach (var slot in _magazines[1].Slots.Skip(5))
        {
            yield return new SlideTask
            {
                Title = "K00121852_001_CD15",
                Profile = Profiles.Fat40x,
                Directory = "slides\\K00121852",
                Slot = slot,
                State = SlideState.Preview
            };
        }
    }

    private static IEnumerable<Magazine> CreateMagazines()
    {
        foreach (var column in "ABCD")
        {
            for (int i = 0; i < 10; i++)
            {
                yield return new Magazine(column, i);
            }
        }
    }
}
