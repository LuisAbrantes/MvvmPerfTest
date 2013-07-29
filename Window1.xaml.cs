namespace LambdaPropertyPerformanceApp
{
    public partial class Window1
    {
        public Window1()
        {
            InitializeComponent();

            DataContext = new PropertyChangeTestViewModel();

            ButtonINotifyNoBinding.Click += (o, e) => { MyViewModel.RunINotifyNoBinding(); };
            ButtonINotifyWithBinding.Click += (o, e) => { MyViewModel.RunINotifyWithBinding(); };
            ButtonLambdaNoBinding.Click += (o, e) => { MyViewModel.RunLambdaNoBinding(); };
            ButtonLambdaWithBinding.Click += (o, e) => { MyViewModel.RunLambdaWithBinding(); };
            ButtonDependencyObjectNoBinding.Click += (o, e) => { MyViewModel.RunDependencyObjectNoBinding(); };
            ButtonDependencyObjectWithBinding.Click += (o, e) => { MyViewModel.RunDependencyObjectWithBinding(); };
        }

        public PropertyChangeTestViewModel MyViewModel
        {
            get
            {
                return DataContext as PropertyChangeTestViewModel;
            }
        }
    }
}
