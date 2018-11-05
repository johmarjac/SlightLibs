using SlightLibs.WPF.Services;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

namespace SlightLibs.WPF.ViewModel
{
    public abstract class ViewModelBase : INotifyPropertyChanged, IDisposable, IWindowEvents
    {        
        public event PropertyChangedEventHandler PropertyChanged;

        private string title { get; set; }
        public string Title
        {
            get { return title; }
            set
            {
                title = value;
                NotifyPropertyChanged();
            }
        }

        public ViewModelBase(string title = "DefaultTitle")
        {
            Title = title;
        }

        public void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        
        public virtual void OnLoaded(object sender, RoutedEventArgs e) { }

        public virtual void OnClosing(object sender, CancelEventArgs e) { }

        protected virtual void Dispose(bool disposing)
        {
            if(disposing)
            {
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}