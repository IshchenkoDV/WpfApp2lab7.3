using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Media.Animation;


namespace WpfApp2
{
    public partial class MainWindow : Window
    {
        private RadialGradientBrush _gradientBrush;

        public MainWindow()
        {
            InitializeComponent();
            InitializeGradientBrush();
            StartAnimation();
        }

        private void InitializeGradientBrush()
        {
            _gradientBrush = new RadialGradientBrush();
            _gradientBrush.GradientStops.Add(new GradientStop(Colors.Yellow, 1.0));
            _gradientBrush.GradientStops.Add(new GradientStop(Colors.Red, 0.0));
            PulsarEllipse.Fill = _gradientBrush;
        }

        private void StartAnimation()
        {
            DoubleAnimation radiusAnimation = new DoubleAnimation
            {
                From = 0.0,
                To = 1.0,
                By = 0.0,
                Duration = TimeSpan.FromSeconds(1),
                AutoReverse = true,
                RepeatBehavior = RepeatBehavior.Forever
            };


            var redGradientStop = _gradientBrush.GradientStops[1];
            radiusAnimation.Completed += (s, e) =>
            {

                redGradientStop.Offset = 1.0;
            };

            redGradientStop.BeginAnimation(GradientStop.OffsetProperty, radiusAnimation);
        }
    }
}
