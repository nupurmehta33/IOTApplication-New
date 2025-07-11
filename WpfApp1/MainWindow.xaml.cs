using System.Collections.ObjectModel;
using System.Windows;
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Painting;
using LiveChartsCore.SkiaSharpView.VisualElements;
using SkiaSharp;
using WpfApp1.ViewModels;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var vm = new DashboardViewModel();
            DataContext = vm;

            // Configure axes for DistanceChart
            DistanceChart.XAxes = new Axis[]
            {
                new Axis { Labels = vm.DistanceLabels }
            };

            // Configure axes for EngineHoursChart
            EngineHoursChart.XAxes = new Axis[]
            {
                new Axis { Labels = vm.EngineHoursLabels }
            };

            // Configure axes for MessagesChart
            MessagesChart.XAxes = new Axis[]
            {
                new Axis { Labels = vm.MessagesLabels }
            };

            // Configure axes for GanttChart
            GanttChart.XAxes = new Axis[]
            {
                new Axis { Labels = vm.GanttLabels }
            };
            GanttChart.YAxes = new Axis[]
            {
                new Axis { Labels = vm.AssetLabels }
            };
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            // Show a confirmation message to test if the button is working
            MessageBox.Show("Close button clicked! Closing application...", "Test", MessageBoxButton.OK, MessageBoxImage.Information);
            
            // Close the application
            Application.Current.Shutdown();
            
            // Fallback: if Application.Current.Shutdown() doesn't work, try closing the window
            // this.Close();
        }
    }
}