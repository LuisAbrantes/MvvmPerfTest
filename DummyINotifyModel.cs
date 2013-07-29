using System.ComponentModel;

namespace LambdaPropertyPerformanceApp
{
    public class DummyINotifyViewModel : INotifyPropertyChanged
    {
        private string _dummyProperty;

        public string DummyProperty
        {
            get
            {
                return _dummyProperty;
            }
            set
            {
                _dummyProperty = value;
                OnPropertyChanged("DummyProperty");
            }
        }


        #region INotifyPropertyChanged Members

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion
    }
}
