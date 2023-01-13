using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using DataGrids.Shared.ViewModel;
using ReactiveUI;

namespace DataGrids.Avalonia;

public partial class App : Application
{
    private readonly Bootstrapper _bootstrapper = new();
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            if (_bootstrapper.Resolve<IViewFor<RootViewModel>>() is not MainWindow mainWindow)
            {
                return;
            }

            desktop.MainWindow = mainWindow;
        }

        base.OnFrameworkInitializationCompleted();
    }
}
