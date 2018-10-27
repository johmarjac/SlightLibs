using SlightLibs.WPF.ViewModel;
using SlightLibs.WPF.Window;
using System.Windows;

namespace SlightLibs.WPF.Services
{
    public class WindowService : IWindowService
    {
        public void Create<TViewModel>() where TViewModel : ViewModelBase, new()
        {
            var window = new DefaultWindow
            {
                DataContext = new TViewModel()
            };

            window.Show();
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