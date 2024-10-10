using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WPF.Viewmodels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        // This event is raised whenever a property value changes
        public event PropertyChangedEventHandler PropertyChanged;

        // This method is called to raise the PropertyChanged event
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        // This method sets the value of a property and raises PropertyChanged if necessary
        protected bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            if (Equals(storage, value)) return false;

            storage = value;
            OnPropertyChanged(propertyName);
            return true;
        }
    }
}
