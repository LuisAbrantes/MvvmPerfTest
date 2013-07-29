using System.Windows;

namespace LambdaPropertyPerformanceApp
{
    public class DummyDependencyObjectViewModel : DependencyObject
    {
        public string DummyProperty
        {
            get { return (string)GetValue(DummyPropertyProperty); }
            set { SetValue(DummyPropertyProperty, value); }
        }

        public static readonly DependencyProperty DummyPropertyProperty =
            DependencyProperty.Register("DummyProperty", typeof(string), typeof(DummyDependencyObjectViewModel), new UIPropertyMetadata(null));
    }
}
