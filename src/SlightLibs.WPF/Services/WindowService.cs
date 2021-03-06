﻿using SlightLibs.Service;
using SlightLibs.WPF.ViewModel;
using SlightLibs.WPF.Window;
using System.Windows;

namespace SlightLibs.WPF.Services
{
    [InjectableService]
    public class WindowService : IWindowService
    {
        public void Create<TViewModel>(ViewModelBase ownerViewModel = null, bool isDialog = false) where TViewModel : ViewModelBase, new()
        {
            var viewModel = new TViewModel();

            var window = new DefaultWindow
            {
                DataContext = viewModel,
                SizeToContent = SizeToContent.WidthAndHeight,
                Owner = GetViewByViewModel(ownerViewModel),
                WindowStartupLocation = WindowStartupLocation.CenterOwner,
            };

            if (ownerViewModel == null)
                window.WindowStartupLocation = WindowStartupLocation.CenterScreen;

            window.Loaded += viewModel.OnLoaded;
            window.Closing += viewModel.OnClosing;

            Application.Current.Dispatcher.Invoke(() =>
            {
                if (!isDialog)
                    window.Show();
                else
                    window.ShowDialog();
            });
        }

        private System.Windows.Window GetViewByViewModel(ViewModelBase viewModel)
        {
            foreach (System.Windows.Window window in Application.Current.Windows)
            {
                if (window.DataContext == viewModel)
                    return window;
            }

            return null;
        }

        public void Destroy<TViewModel>() where TViewModel : ViewModelBase
        {
            foreach(System.Windows.Window window in Application.Current.Windows)
            {
                if (window.DataContext.GetType() == typeof(TViewModel))
                {
                    window.Loaded -= ((ViewModelBase)window.DataContext).OnLoaded;
                    window.Closing -= ((ViewModelBase)window.DataContext).OnClosing;
                    window.Close();
                }
            }
        }
    }
}