using SlightLibs.Service;
using SlightLibs.WPF.Command;
using SlightLibs.WPF.Services;
using SlightLibs.WPF.ViewModel;
using System.Windows.Input;

namespace SlightLibs.WPF.Tests.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public ICommand OpenWindow { get; }

        public MainViewModel() : base("Main View Title")
        {
            OpenWindow = new RelayCommand(() =>
            {
                ServiceProvider.Instance
                    .GetService<IWindowService>()
                    .Create<SecondViewModel>(this, true);
            });
        }
    }
}