using SlightLibs.Service;
using SlightLibs.WPF.Command;
using SlightLibs.WPF.Services;
using SlightLibs.WPF.ViewModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace SlightLibs.WPF.Tests.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public ICommand OpenWindow { get; }

        public MainViewModel()
        {
            OpenWindow = new RelayCommand(() =>
            {
                ServiceProvider.Instance
                    .GetService<IWindowService>()
                    .Create<SecondViewModel>("SecondView", this, true, Window_Loaded, Window_Closing);
            });
        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            MessageBox.Show("Closing");
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Loaded");
        }
    }
}