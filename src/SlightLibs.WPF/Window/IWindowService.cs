using SlightLibs.WPF.ViewModel;

namespace SlightLibs.WPF.Window
{
    public interface IWindowService
    {
        void Create<TViewModel>() where TViewModel : ViewModelBase, new();
        void Destroy<TViewModel>() where TViewModel : ViewModelBase;
    }
}