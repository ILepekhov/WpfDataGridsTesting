using System;
using System.Collections;
using System.Diagnostics.CodeAnalysis;
using System.Reactive.Disposables;
using Avalonia.Collections;
using Avalonia.ReactiveUI;
using DataGrids.Shared.ViewModel;
using ReactiveUI;

namespace DataGrids.Avalonia;

[SingleInstanceView]
public partial class MainWindow :  ReactiveWindow<RootViewModel>
{
    public MainWindow()
    {
        InitializeComponent();
    }

    public MainWindow(RootViewModel rootViewModel) : this()
    {
        ViewModel = rootViewModel ?? throw new ArgumentNullException(nameof(rootViewModel));

        DataGridCollectionView collectionView = new(ViewModel.SlideTasks);
        collectionView.GroupDescriptions.Add(new DataGridPathGroupDescription(nameof(SlideTaskViewModel.Magazine)));

        TasksDataGrid.Items = collectionView;
    }

}
