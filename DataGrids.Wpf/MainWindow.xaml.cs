using System;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Reactive.Disposables;
using System.Windows.Data;
using DataGrids.Shared.ViewModel;
using ReactiveUI;

namespace DataGrids.Wpf
{
    [SingleInstanceView]
    public partial class MainWindow
    {
        public MainWindow(RootViewModel rootViewModel)
        {
            ViewModel = rootViewModel ?? throw new ArgumentNullException(nameof(rootViewModel));
            InitializeComponent();

            this.WhenActivated(disposableRegistration =>
            {
                this.OneWayBind(ViewModel,
                        vm => vm.SlideTasks,
                        v => v.TasksDataGrid.ItemsSource)
                    .DisposeWith(disposableRegistration);

                ActivateSlideTasksGrouping(TasksDataGrid.ItemsSource);

                Disposable.Create(() => DeactivateSlideTasks(TasksDataGrid.ItemsSource))
                    .DisposeWith(disposableRegistration);
            });
        }

        private static void ActivateSlideTasksGrouping(IEnumerable slideTasksCollection)
        {
            if (TryGetCollectionView(slideTasksCollection, out ICollectionView? collectionView) is false)
            {
                return;
            }

            collectionView.GroupDescriptions.Clear();
            collectionView.GroupDescriptions.Add(new PropertyGroupDescription(nameof(SlideTaskViewModel.Magazine)));
        }

        private static void DeactivateSlideTasks(IEnumerable slideTasksCollection)
        {
            if (TryGetCollectionView(slideTasksCollection, out ICollectionView? collectionView) is false)
            {
                return;
            }

            collectionView.GroupDescriptions.Clear();
        }

        private static bool TryGetCollectionView(IEnumerable collection, [NotNullWhen(true)] out ICollectionView? collectionView)
        {
            ICollectionView? slideTasksCollectionView = CollectionViewSource.GetDefaultView(collection);
            if (slideTasksCollectionView is null || slideTasksCollectionView.CanGroup is false)
            {
                collectionView = default;
                return false;
            }

            collectionView = slideTasksCollectionView;
            return true;
        }
    }
}
