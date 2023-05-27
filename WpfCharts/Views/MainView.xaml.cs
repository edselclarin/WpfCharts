using System.Windows;
using WpfCharts.ViewModels;

namespace WpfCharts.Views
{
    /// <summary>
    /// Interaction logic for MainView.xaml
    /// </summary>
    public partial class MainView : Window
    {
        private MainViewModel _viewModel = new MainViewModel();

        public MainView()
        {
            InitializeComponent();

            DataContext = _viewModel;
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            _viewModel.SetLineSmoothness(e.NewValue);
        }
    }
}
