using SlightLibs.Service;
using System.Windows;

namespace SlightLibs.WPF.Tests
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            ServiceProvider.Instance.InjectServices();
        }
    }
}