using System;
using System.Diagnostics;

namespace LambdaPropertyPerformanceApp
{
    public class PropertyChangeTestViewModel : ViewModelBase
    {
        private const int TestInterations = 1000000;

        private object _propertyChangingViewModel;

        private string _iNotifyNoBindingResult;
        private string _iNotifyWithBindingResult;
        private string _lambdaNoBindingResult;
        private string _lambdaWithBindingResult;
        private string _dependencyObjectNoBindingResult;
        private string _dependencyObjectWithBindingResult;

        public void RunINotifyNoBinding()
        {
            INotifyNoBindingResult = MeasureAction(() =>
            {
                DummyINotifyViewModel iNotifyViewModel = new DummyINotifyViewModel();

                for (int i = 0; i < TestInterations; ++i)
                {
                    //nothing is listening to the property changed event
                    iNotifyViewModel.DummyProperty = "DummyText";
                }

            });
        }

        public void RunINotifyWithBinding()
        {
            INotifyWithBindingResult = MeasureAction(() =>
            {
                DummyINotifyViewModel iNotifyViewModel = new DummyINotifyViewModel();

                //the main window is bound to this propery and will listen to property change events on this object
                PropertyChangingViewModel = iNotifyViewModel;

                for (int i = 0; i < TestInterations; ++i)
                {
                    //a textbox is listening to the property changed event
                    iNotifyViewModel.DummyProperty = "DummyText";
                }
            });
        }

        public void RunLambdaNoBinding()
        {
            LambdaNoBindingResult = MeasureAction(() =>
            {
                DummyLambdaViewModel lambdaViewModel = new DummyLambdaViewModel();

                for (int i = 0; i < TestInterations; ++i)
                {
                    //nothing is listening to the property changed event
                    lambdaViewModel.DummyProperty = "DummyText";
                }

            });
        }

        public void RunLambdaWithBinding()
        {
            LambdaWithBindingResult = MeasureAction(() =>
            {
                DummyLambdaViewModel lambdaViewModel = new DummyLambdaViewModel();

                //the main window is bound to this propery and will listen to property change events on this object
                PropertyChangingViewModel = lambdaViewModel;

                for (int i = 0; i < TestInterations; ++i)
                {
                    //a textbox is listening to the property changed event
                    lambdaViewModel.DummyProperty = "DummyText";
                }
            });
        }

        public void RunDependencyObjectNoBinding()
        {
            DependencyObjectNoBindingResult = MeasureAction(() =>
            {
                DummyDependencyObjectViewModel dependencyObjectViewModel = new DummyDependencyObjectViewModel();

                for (int i = 0; i < TestInterations; ++i)
                {
                    //nothing is listening to the property changed event
                    dependencyObjectViewModel.DummyProperty = "DummyText";
                }

            });
        }

        public void RunDependencyObjectWithBinding()
        {
            DependencyObjectWithBindingResult = MeasureAction(() =>
            {
                DummyDependencyObjectViewModel dependencyObjectViewModel = new DummyDependencyObjectViewModel();

                //the main window is bound to this propery and will listen to property change events on this object
                PropertyChangingViewModel = dependencyObjectViewModel;

                for (int i = 0; i < TestInterations; ++i)
                {
                    //a textbox is listening to the property changed event
                    dependencyObjectViewModel.DummyProperty = "DummyText";
                }
            });
        }

        private string MeasureAction(Action action)
        {
            Stopwatch sw = Stopwatch.StartNew();

            action();

            return String.Format("{0:F3} seconds", sw.ElapsedTicks / (double)Stopwatch.Frequency);
        }

        public object PropertyChangingViewModel
        {
            get
            {
                return _propertyChangingViewModel;
            }
            set
            {
                _propertyChangingViewModel = value;
                OnPropertyChanged(() => PropertyChangingViewModel);
            }
        }

        public string INotifyNoBindingResult
        {
            get
            {
                return _iNotifyNoBindingResult;
            }
            private set
            {
                _iNotifyNoBindingResult = value;
                OnPropertyChanged(() => INotifyNoBindingResult);
            }
        }

        public string INotifyWithBindingResult
        {
            get
            {
                return _iNotifyWithBindingResult;
            }
            private set
            {
                _iNotifyWithBindingResult = value;
                OnPropertyChanged(() => INotifyWithBindingResult);
            }
        }

        public string LambdaNoBindingResult
        {
            get
            {
                return _lambdaNoBindingResult;
            }
            private set
            {
                _lambdaNoBindingResult = value;
                OnPropertyChanged(() => LambdaNoBindingResult);
            }
        }

        public string LambdaWithBindingResult
        {
            get
            {
                return _lambdaWithBindingResult;
            }
            private set
            {
                _lambdaWithBindingResult = value;
                OnPropertyChanged(() => LambdaWithBindingResult);
            }
        }

        public string DependencyObjectNoBindingResult
        {
            get
            {
                return _dependencyObjectNoBindingResult;
            }
            private set
            {
                _dependencyObjectNoBindingResult = value;
                OnPropertyChanged(() => DependencyObjectNoBindingResult);
            }
        }

        public string DependencyObjectWithBindingResult
        {
            get
            {
                return _dependencyObjectWithBindingResult;
            }
            private set
            {
                _dependencyObjectWithBindingResult = value;
                OnPropertyChanged(() => DependencyObjectWithBindingResult);
            }
        }
    }
}
