using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Painting;
using SkiaSharp;

namespace WpfApp1.ViewModels
{
    public class DashboardViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<ISeries> _distanceSeries;
        private ObservableCollection<ISeries> _engineHoursSeries;
        private ObservableCollection<ISeries> _activitySeries;
        private ObservableCollection<ISeries> _messagesSeries;
        private ObservableCollection<ISeries> _ganttSeries;
        private string[] _distanceLabels;
        private string[] _engineHoursLabels;
        private string[] _messagesLabels;
        private string[] _ganttLabels;
        private string[] _assetLabels;

        public ObservableCollection<ISeries> DistanceSeries
        {
            get => _distanceSeries;
            set
            {
                _distanceSeries = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<ISeries> EngineHoursSeries
        {
            get => _engineHoursSeries;
            set
            {
                _engineHoursSeries = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<ISeries> ActivitySeries
        {
            get => _activitySeries;
            set
            {
                _activitySeries = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<ISeries> MessagesSeries
        {
            get => _messagesSeries;
            set
            {
                _messagesSeries = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<ISeries> GanttSeries
        {
            get => _ganttSeries;
            set
            {
                _ganttSeries = value;
                OnPropertyChanged();
            }
        }

        public string[] DistanceLabels
        {
            get => _distanceLabels;
            set
            {
                _distanceLabels = value;
                OnPropertyChanged();
            }
        }

        public string[] EngineHoursLabels
        {
            get => _engineHoursLabels;
            set
            {
                _engineHoursLabels = value;
                OnPropertyChanged();
            }
        }

        public string[] MessagesLabels
        {
            get => _messagesLabels;
            set
            {
                _messagesLabels = value;
                OnPropertyChanged();
            }
        }

        public string[] GanttLabels
        {
            get => _ganttLabels;
            set
            {
                _ganttLabels = value;
                OnPropertyChanged();
            }
        }

        public string[] AssetLabels
        {
            get => _assetLabels;
            set
            {
                _assetLabels = value;
                OnPropertyChanged();
            }
        }

        public DashboardViewModel()
        {
            InitializeCharts();
        }

        private void InitializeCharts()
        {
            // Traveled Distance Chart - Area chart with two series
            DistanceSeries = new ObservableCollection<ISeries>
            {
                // Current Period (solid orange line with area fill)
                new LineSeries<double>
                {
                    Values = new double[] { 12, 29, 18, 35, 42, 28, 45, 38, 52, 41, 48, 55, 60 },
                    Name = "Current Period",
                    Stroke = new SolidColorPaint(SKColors.Orange, 3),
                    Fill = new SolidColorPaint(SKColors.Orange.WithAlpha(80)),
                    GeometrySize = 6,
                    GeometryFill = new SolidColorPaint(SKColors.Orange),
                    GeometryStroke = new SolidColorPaint(SKColors.White, 2)
                },
                // Previous Period (dotted line)
                new LineSeries<double>
                {
                    Values = new double[] { 6, 15, 8, 22, 18, 12, 25, 20, 30, 24, 28, 32, 35 },
                    Name = "Previous Period",
                    Stroke = new SolidColorPaint(SKColors.Gray, 2),
                    GeometrySize = 4,
                    GeometryFill = new SolidColorPaint(SKColors.Gray),
                    GeometryStroke = new SolidColorPaint(SKColors.White, 1)
                }
            };

            // X-axis labels for dates (March 22 to April 3)
            DistanceLabels = new string[] 
            { 
                "Mar 22", "Mar 23", "Mar 24", "Mar 25", "Mar 26", "Mar 27", "Mar 28", 
                "Mar 29", "Mar 30", "Mar 31", "Apr 1", "Apr 2", "Apr 3" 
            };

            // Engine Hours Stacked Bar Chart
            EngineHoursSeries = new ObservableCollection<ISeries>
            {
                // Ignition (Green)
                new ColumnSeries<double>
                {
                    Values = new double[] { 4.2, 3.8, 5.1, 3.5, 4.8, 4.0, 5.3, 4.6, 3.9, 4.7, 4.1, 5.0, 4.4, 4.9, 4.3, 5.2 },
                    Name = "Ignition",
                    Fill = new SolidColorPaint(SKColors.Green),
                    Stroke = new SolidColorPaint(SKColors.DarkGreen, 1)
                },
                // Idling (Orange)
                new ColumnSeries<double>
                {
                    Values = new double[] { 2.8, 2.4, 3.2, 2.1, 3.0, 2.6, 3.5, 2.9, 2.3, 3.1, 2.7, 3.3, 2.5, 3.2, 2.8, 3.4 },
                    Name = "Idling",
                    Fill = new SolidColorPaint(SKColors.Orange),
                    Stroke = new SolidColorPaint(SKColors.DarkOrange, 1)
                }
            };

            // X-axis labels for dates (Mar 20 to Apr 4)
            EngineHoursLabels = new string[] 
            { 
                "Mar 20", "Mar 21", "Mar 22", "Mar 23", "Mar 24", "Mar 25", "Mar 26", "Mar 27",
                "Mar 28", "Mar 29", "Mar 30", "Mar 31", "Apr 1", "Apr 2", "Apr 3", "Apr 4"
            };

            // Activity Breakdown Donut Chart
            ActivitySeries = new ObservableCollection<ISeries>
            {
                new PieSeries<double> { Values = new double[] { 500 }, Name = "Ignition Off", Fill = new SolidColorPaint(new SKColor(128, 0, 0)) }, // Maroon
                new PieSeries<double> { Values = new double[] { 600 }, Name = "Ignition", Fill = new SolidColorPaint(SKColors.Green) },
                new PieSeries<double> { Values = new double[] { 146 }, Name = "Idling", Fill = new SolidColorPaint(SKColors.Orange) }
            };

            // Messages Received Bar Chart
            MessagesSeries = new ObservableCollection<ISeries>
            {
                new ColumnSeries<double>
                {
                    Values = new double[] { 2450, 2180, 2750, 1920, 3100, 2680, 2950, 2340, 2890, 2560, 2780, 3020, 2410 },
                    Name = "Messages Received",
                    Fill = new SolidColorPaint(SKColors.Orange),
                    Stroke = new SolidColorPaint(SKColors.DarkOrange, 1)
                }
            };

            MessagesLabels = new string[] { "Mar 22", "Mar 23", "Mar 24", "Mar 25", "Mar 26", "Mar 27", "Mar 28", "Mar 29", "Mar 30", "Mar 31", "Apr 1", "Apr 2", "Apr 3" };

            // Gantt Chart - Horizontal Stacked Bar Timeline
            GanttSeries = new ObservableCollection<ISeries>
            {
                // BL-08 Asset
                new ColumnSeries<double>
                {
                    Values = new double[] { 2.5 }, // Idling hours
                    Name = "BL-08 Idling",
                    Fill = new SolidColorPaint(SKColors.Orange)
                },
                new ColumnSeries<double>
                {
                    Values = new double[] { 3.2 }, // Active hours
                    Name = "BL-08 Active",
                    Fill = new SolidColorPaint(SKColors.Cyan)
                },
                new ColumnSeries<double>
                {
                    Values = new double[] { 1.8 }, // Minor state hours
                    Name = "BL-08 Minor",
                    Fill = new SolidColorPaint(new SKColor(128, 128, 0)) // Olive
                },
                new ColumnSeries<double>
                {
                    Values = new double[] { 0.5 }, // Off hours
                    Name = "BL-08 Off",
                    Fill = new SolidColorPaint(SKColors.LightGray)
                },
                // Q-47898 Asset
                new ColumnSeries<double>
                {
                    Values = new double[] { 1.8 }, // Idling hours
                    Name = "Q-47898 Idling",
                    Fill = new SolidColorPaint(SKColors.Orange)
                },
                new ColumnSeries<double>
                {
                    Values = new double[] { 4.5 }, // Active hours
                    Name = "Q-47898 Active",
                    Fill = new SolidColorPaint(SKColors.Cyan)
                },
                new ColumnSeries<double>
                {
                    Values = new double[] { 1.2 }, // Minor state hours
                    Name = "Q-47898 Minor",
                    Fill = new SolidColorPaint(new SKColor(128, 128, 0)) // Olive
                },
                new ColumnSeries<double>
                {
                    Values = new double[] { 0.5 }, // Off hours
                    Name = "Q-47898 Off",
                    Fill = new SolidColorPaint(SKColors.LightGray)
                },
                // D-26653 Asset
                new ColumnSeries<double>
                {
                    Values = new double[] { 3.1 }, // Idling hours
                    Name = "D-26653 Idling",
                    Fill = new SolidColorPaint(SKColors.Orange)
                },
                new ColumnSeries<double>
                {
                    Values = new double[] { 2.8 }, // Active hours
                    Name = "D-26653 Active",
                    Fill = new SolidColorPaint(SKColors.Cyan)
                },
                new ColumnSeries<double>
                {
                    Values = new double[] { 1.6 }, // Minor state hours
                    Name = "D-26653 Minor",
                    Fill = new SolidColorPaint(new SKColor(128, 128, 0)) // Olive
                },
                new ColumnSeries<double>
                {
                    Values = new double[] { 0.5 }, // Off hours
                    Name = "D-26653 Off",
                    Fill = new SolidColorPaint(SKColors.LightGray)
                }
            };

            // Time labels (11:00 to 18:00)
            GanttLabels = new string[] { "11:00", "12:00", "13:00", "14:00", "15:00", "16:00", "17:00", "18:00" };
            
            // Asset labels with percentages
            AssetLabels = new string[] { "BL-08 (85%)", "Q-47898 (92%)", "D-26653 (78%)" };
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
} 