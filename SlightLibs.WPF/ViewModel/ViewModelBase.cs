using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SlightLibs.WPF.ViewModel
{
    public abstract class ViewModelBase : INotifyPropertyChanged, IDisposable
    {        
        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

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