using System;
using System.Linq;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Threading;

using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Programming4_Lab04_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private GridLength GridLengthZero;

        private double A, B, W, H;
        private DispatcherTimer dt;
        private double interval = 10;
        private double time = 0;

        ObservableCollection<Point> plotPoints = new ObservableCollection<Point>();
        public ObservableCollection<Point> PointsOfPlot
        { get { return plotPoints; } }

        public MainWindow()
        {
            GridLengthZero = new GridLength(0);
            InitializeComponent();

            dt = new DispatcherTimer();
            dt.Interval = new TimeSpan(0, 0, 0, 0, (int)interval);
            dt.Tick += new EventHandler(dispatcherTimer_Tick);
            dt.Start();
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            double time_old = time;
            time += (interval / 250) * (sliderSpeed.Value / sliderSpeed.Maximum);
            addPoint(time_old, time);
        }

        private Thickness getCanvasDims()
        {
            int margin = 2; //extra margin
            return new Thickness(margin, margin,
                canvas.ActualWidth - margin * 2, canvas.ActualHeight - margin * 2);
        }

        private void addPoint(double t0, double t)
        {
            double a = sliderA.Value, b = sliderB.Value;
            double w = canvas.ActualWidth, h = canvas.ActualHeight;

            if (A != a || B != b || W != w || H != h)
            {
                //size changed
                PointsOfPlot.Clear();
            }

            Thickness rect = getCanvasDims();

            //set this to true to check out the old drawing method
            bool normalVariant = false;

            if (normalVariant)
            {
                //old drawing method, does not look good at the speed of light
                // (or close to that speed)

                Double xUnit = Math.Sin(t * a), yUnit = Math.Sin(t * b);
                double x = rect.Left + rect.Right / 2 + rect.Right / 2 * xUnit;
                double y = rect.Top + rect.Bottom / 2 + rect.Bottom / 2 * yUnit;

                PointsOfPlot.Add(new Point(x, y));
            }
            else
            {
                //after a certain treshold, the number of points per tick is increased,
                // to compensate for the fact that at higher speeds the distance between
                // points would be too large and the poly line would not look good

                double minimum = (interval / 250) * sliderSpeed.Minimum; //0.04
                double current = (interval / 250) * sliderSpeed.Value;
                double maximum = (interval / 250) * sliderSpeed.Maximum; //8
                int limit = 1 + (int)current;

                double deltaT = t - t0;

                //minimum: 1 point per tick, maximum: 9 points per tick
                // (for current interface settings, the program behavior will change
                //  according to modifications of UI)
                for (int i = 0; i < limit; i++)
                {
                    double currT = t0 + ((i + 1) * deltaT) / limit;
                    Double xUnit = Math.Sin(currT * a), yUnit = Math.Sin(currT * b);
                    double x = rect.Left + rect.Right / 2 + rect.Right / 2 * xUnit;
                    double y = rect.Top + rect.Bottom / 2 + rect.Bottom / 2 * yUnit;

                    PointsOfPlot.Add(new Point(x, y));
                }
            }

            if (radioButtonHome.IsChecked == true && enableFade.IsChecked == true)
                for (int i = PointsOfPlot.Count - 1 - (int)sliderFade.Value;
                    i >= 0;
                    PointsOfPlot.RemoveAt(i--)) ;

            PropertyChanged(this, new PropertyChangedEventArgs("PointsOfPlot"));

            A = a;
            B = b;
            W = w;
            H = h;
        }

        public event PropertyChangedEventHandler PropertyChanged;

    }

    public class BooleanToGridLengthConverter : IValueConverter
    {
        private GridLength glZero = new GridLength(0);

        public object Convert(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value.GetType() == typeof(Boolean) && targetType == typeof(GridLength))
            {
                Boolean b = (Boolean)value;
                if (b == true)
                    return GridLength.Auto;
                else
                    return glZero;
            }
            return null;
        }

        public object ConvertBack(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value.GetType() == typeof(GridLength) && targetType == typeof(Boolean))
            {
                GridLength gl = (GridLength)value;
                if (gl.IsAuto)
                    return true;
                else
                    return false;
            }
            return null;
        }
    }

    public class DoubleToStringConverter : IValueConverter
    {
        public object Convert(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value.GetType() != typeof(Double) || targetType != typeof(String))
                return null;

            if (value == null)
                return "?";

            Double val = (double)value;
            return Math.Round(val, 3).ToString();
        }

        public object ConvertBack(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value.GetType() != typeof(String) || targetType != typeof(Double))
                return null;

            if (value == null)
                return 0.666;

            String val = (String)value;
            return Double.Parse(val);
            //return null;
        }
    }

    public class PointCollectionConverter : IValueConverter
    {
        public object Convert(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value.GetType() == typeof(ObservableCollection<Point>) && targetType == typeof(PointCollection))
            {
                var pointCollection = new PointCollection();
                foreach (var point in value as ObservableCollection<Point>)
                    pointCollection.Add(point);
                return pointCollection;
            }
            return null;

        }

        public object ConvertBack(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null; //not needed
        }

    }

    public class PointCollectionForCircleConverter : IValueConverter
    {
        protected bool setX = true;

        public object Convert(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value.GetType() == typeof(ObservableCollection<Point>) && targetType == typeof(Double))
            {
                ObservableCollection<Point> pts = (ObservableCollection<Point>)value;
                int len = pts.Count;

                if (len > 0)
                    if (setX)
                        return pts.ElementAt(len - 1).X - 5;
                    else
                        return pts.ElementAt(len - 1).Y - 5;
                else return 5;
            }
            return null;

        }

        public object ConvertBack(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null; //not needed
        }

    }

    public class PointCollectionForCircleXConverter : PointCollectionForCircleConverter
    {
        public PointCollectionForCircleXConverter()
        {
            setX = true;
        }
    }

    public class PointCollectionForCircleYConverter : PointCollectionForCircleConverter
    {
        public PointCollectionForCircleYConverter()
        {
            setX = false;
        }
    }
}
