using System.ComponentModel;
using System.Windows;
using SlightLibs.WPF.ViewModel;

namespace SlightLibs.WPF.Tests.ViewModels
{
    public class SecondViewModel : ViewModelBase
    {
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