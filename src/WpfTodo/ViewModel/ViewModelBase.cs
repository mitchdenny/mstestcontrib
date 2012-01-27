using System;
using System.ComponentModel;
using System.Linq.Expressions;

namespace WpfTodo.ViewModel
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged<T>(Expression<Func<T>> getter)
        {
            var propertyName = PropertyResolver.NameFor(getter);
            RaisePropertyChanged(propertyName);
        }

        protected void RaisePropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler == null) return;
            var e = new PropertyChangedEventArgs(propertyName);
            handler(this, e);
        }
    }
}