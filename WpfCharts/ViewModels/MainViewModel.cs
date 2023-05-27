using LiveCharts;
using LiveCharts.Wpf;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace WpfCharts.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private static double _lineSmoothness = 0;

        public double LineSmoothness
        {
            get => _lineSmoothness;
            set
            {
                _lineSmoothness = value;
                OnPropertyChanged();
            }
        }

        private SeriesCollection _dataSeries = new SeriesCollection
        {
            new LineSeries
            {
                Title = "Series 1",
                Values = new ChartValues<double> { 1, 4, 6, 3, 2 },
                LineSmoothness = _lineSmoothness
            },
            new LineSeries
            {
                Title = "Series 2",
                Values = new ChartValues<double> { 4, 4, 4, 4, 1, 2, 3, 4 },
                LineSmoothness = _lineSmoothness
            }
        };

        public SeriesCollection DataSeries
        {
            get
            {
                return _dataSeries;
            }

            set
            {
                _dataSeries = value;
                OnPropertyChanged();
            }
        }

        public void SetLineSmoothness(double lineSmoothnessVal)
        {
            LineSmoothness = lineSmoothnessVal;

            foreach (var series in _dataSeries)
            {
                var ls = series as LineSeries;
                ls.LineSmoothness = lineSmoothnessVal;
            }

            OnPropertyChanged(nameof(DataSeries));
        }
    }
}
