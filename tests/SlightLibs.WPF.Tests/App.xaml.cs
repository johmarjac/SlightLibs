using SlightLibs.Service;
using SlightLibs.WPF.Services;
using SlightLibs.WPF.Tests.ViewModels;
using System.Windows;

namespace SlightLibs.WPF.Tests
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            ServiceProvider.Instance.InjectServices();

            ServiceProvider.Instance
                    .GetService<IWindowService>()
                    .Create<MainViewModel>();
        }
    }
}