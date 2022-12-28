using System.Collections.ObjectModel;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using DataGrids.Shared.Model;
using DynamicData;
using DynamicData.Binding;
using ReactiveUI;

namespace DataGrids.Shared.ViewModel;

public sealed class RootViewModel : ReactiveObject, IDisposable
{
    private readonly CompositeDisposable _internalSubscriptions;
    private bool _disposed;

    private readonly SourceList<SlideTask> _slideTasksSourceList;
    private readonly ReadOnlyObservableCollection<SlideTaskViewModel> _slideTasks;

    public ReadOnlyObservableCollection<SlideTaskViewModel> SlideTasks => _slideTasks;

    public RootViewModel()
    {
        _internalSubscriptions = new CompositeDisposable();
        _slideTasksSourceList = new SourceList<SlideTask>().DisposeWith(_internalSubscriptions);

        _slideTasksSourceList
            .Connect()
            .Transform(task => new SlideTaskViewModel(task))
            .Sort(SortExpressionComparer<SlideTaskViewModel>.Ascending(x => x.Slot))
            .ObserveOn(RxApp.MainThreadScheduler)
            .Bind(out _slideTasks)
            .DisposeMany()
            .Subscribe()
            .DisposeWith(_internalSubscriptions);
    }

    public void Append(IEnumerable<SlideTask> slideTasks)
    {
        _slideTasksSourceList.AddRange(slideTasks);
    }

    public void Dispose()
    {
        if (_disposed)
        {
            return;
        }

        _internalSubscriptions.Dispose();

        _disposed = true;
    }
}
