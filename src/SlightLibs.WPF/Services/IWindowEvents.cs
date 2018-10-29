using System.ComponentModel;
using System.Windows;

namespace SlightLibs.WPF.Services
{
    public interface IWindowEvents
    {
        void OnLoaded(object sender, RoutedEventArgs e);
        void OnClosing(object sender, CancelEventArgs e);
    }
}