using SlightLibs.Service;
using SlightLibs.WPF.ViewModel;
using SlightLibs.WPF.Window;
using System.Windows;

namespace SlightLibs.WPF.Services
{
    [InjectableService]
    public class WindowService : IWindowService
    {
        public void Create<TViewModel>(string title = "DefaultWindow", bool isDialog = false) where TViewModel : ViewModelBase, new()
        {
            var window = new DefaultWindow
            {
                Title = title,
                DataContext = new TViewModel(),
                SizeToContent = SizeToContent.Manual,
                WindowStartupLocation = WindowStartupLocation.CenterScreen
            };

            Application.Current.Dispatcher.Invoke(() =>
            {
                if (!isDialog)
                    window.Show();
                else
                    window.ShowDialog();
            });
        }

        public void Destroy<TViewModel>() where TViewModel : ViewModelBase
        {
            foreach(System.Windows.Window window in Application.Current.Windows)
            {
                if (window.DataContext.GetType() == typeof(TViewModel))
                    window.Close();
            }
        }
    }
}