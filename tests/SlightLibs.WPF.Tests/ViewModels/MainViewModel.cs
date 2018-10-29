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
                    .Create<SecondViewModel>("SecondView", this, true);
            });
        }

        public override void OnLoaded(object sender, RoutedEventArgs e)
        {
            base.OnLoaded(sender, e);
            MessageBox.Show("hi");
        }

        public override void OnClosing(object sender, CancelEventArgs e)
        {
            base.OnClosing(sender, e);
            MessageBox.Show("bye");
        }
    }
}