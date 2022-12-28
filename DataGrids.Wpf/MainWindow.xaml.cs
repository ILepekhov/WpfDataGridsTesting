using System;
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
        }
    }
}
