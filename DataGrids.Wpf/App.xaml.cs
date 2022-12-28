using System.Windows;
using DataGrids.Shared.ViewModel;
using ReactiveUI;

namespace DataGrids.Wpf
{
    public partial class App
    {
        private readonly Bootstrapper _bootstrapper;

        public App()
        {
            _bootstrapper = new Bootstrapper();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            if (_bootstrapper.Resolve<IViewFor<RootViewModel>>() is not MainWindow mainWindow)
            {
                return;
            }

            Current.MainWindow = mainWindow;
            mainWindow.Show();
        }
    }
}
