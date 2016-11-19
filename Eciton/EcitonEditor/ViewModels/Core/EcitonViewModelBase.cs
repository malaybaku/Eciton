using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace EcitonEditor
{
    public abstract class EcitonViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void SetProperty<T>(T value, ref T target, [CallerMemberName]string propName="")
            where T : IEquatable<T>
        {
            if(!value.Equals(target))
            {
                target = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
            }
        }

        protected void RaisePropertyChanged([CallerMemberName]string propName = "")
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
    }
}
