using DataGrids.Shared.Model;

namespace DataGrids.Shared.Infrastructure;

public interface ISlideTasksService
{
    IEnumerable<SlideTask> GetTasks();
}
