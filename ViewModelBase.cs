using System;
using System.ComponentModel;
using System.Linq.Expressions;

namespace LambdaPropertyPerformanceApp
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        public ViewModelBase()
        {
        }

        protected virtual void OnPropertyChanged(Expression<Func<object>> expression)
        {
            this.PropertyChanged.Raise(this, expression);
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
