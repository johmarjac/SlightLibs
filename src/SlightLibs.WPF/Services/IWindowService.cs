using SlightLibs.WPF.ViewModel;

namespace SlightLibs.WPF.Services
{
    public interface IWindowService
    {
        void Create<TViewModel>(string title = "DefaultWindow", ViewModelBase ownerViewModel = null, bool isDialog = false) where TViewModel : ViewModelBase, new();
        void Destroy<TViewModel>() where TViewModel : ViewModelBase;
    }
}