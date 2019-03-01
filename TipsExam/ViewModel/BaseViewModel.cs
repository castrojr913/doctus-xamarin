using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TipsExam.ViewModel
{
    /// <summary>
    /// Base view model.
    /// </summary>
    public class BaseViewModel : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged([CallerMemberName] string propertyName = "") =>
         PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

    }
}
