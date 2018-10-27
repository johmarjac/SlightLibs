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

            var windowService = ServiceProvider.Instance.AddService(new WindowService());

            windowService.Create<MainViewModel>();
        }
    }
}