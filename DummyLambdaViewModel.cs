using System;
using System.ComponentModel;
using System.Linq.Expressions;

namespace LambdaPropertyPerformanceApp
{
    public class DummyLambdaViewModel : INotifyPropertyChanged
    {
        private string _dummyProperty;

        public DummyLambdaViewModel()
        {
        }

        public string DummyProperty
        {
            get
            {
                return this._dummyProperty;
            }
            set
            {
                this._dummyProperty = value;
                OnPropertyChanged(() => this.DummyProperty);
            }
        }

        #region INotifyPropertyChanged Members

        protected virtual void OnPropertyChanged(Expression<Func<object>> expression)
        {
            this.PropertyChanged.Raise(this, expression);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion
    }
}
