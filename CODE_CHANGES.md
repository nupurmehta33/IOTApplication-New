# Code Changes Guide

This document provides detailed instructions for making changes to the IoT Dashboard application.

## 📁 File Structure Overview

```
WpfApp1/
├── MainWindow.xaml              # Main UI layout and styling
├── MainWindow.xaml.cs           # Window logic and chart configuration
├── ViewModels/
│   └── DashboardViewModel.cs    # ALL DATA AND CHART CONFIGURATION
├── App.xaml                     # Application entry point
└── WpfApp1.csproj              # Project dependencies
```

## 🎯 Where to Make Changes

### 1. **Chart Data & Configuration** - `ViewModels/DashboardViewModel.cs`

This is the **MOST IMPORTANT** file for data changes. All chart data is defined here.

#### Traveled Distance Chart
```csharp
// Current Period data (orange area)
Values = new double[] { 12, 29, 18, 35, 42, 28, 45, 38, 52, 41, 48, 55, 60 }

// Previous Period data (gray line)
Values = new double[] { 6, 15, 8, 22, 18, 12, 25, 20, 30, 24, 28, 32, 35 }

// X-axis labels (dates)
DistanceLabels = new string[] { "Mar 22", "Mar 23", "Mar 24", ... }
```

#### Engine Hours Chart
```csharp
// Ignition hours (green bars)
Values = new double[] { 4.2, 3.8, 5.1, 3.5, 4.8, 4.0, 5.3, ... }

// Idling hours (orange bars)
Values = new double[] { 2.8, 2.4, 3.2, 2.1, 3.0, 2.6, 3.5, ... }

// X-axis labels (dates)
EngineHoursLabels = new string[] { "Mar 20", "Mar 21", "Mar 22", ... }
```

#### Activity Breakdown (Donut Chart)
```csharp
// Activity segments with values and colors
new PieSeries<double> { Values = new double[] { 500 }, Name = "Ignition Off", Fill = new SolidColorPaint(new SKColor(128, 0, 0)) }
new PieSeries<double> { Values = new double[] { 600 }, Name = "Ignition", Fill = new SolidColorPaint(SKColors.Green) }
new PieSeries<double> { Values = new double[] { 146 }, Name = "Idling", Fill = new SolidColorPaint(SKColors.Orange) }
```

#### Messages Received Chart
```csharp
// Daily message counts
Values = new double[] { 2450, 2180, 2750, 1920, 3100, 2680, 2950, ... }

// X-axis labels (dates)
MessagesLabels = new string[] { "Mar 22", "Mar 23", "Mar 24", ... }
```

#### Gantt Chart (Day Overview)
```csharp
// Asset timeline data - each asset has 4 states
// BL-08 Asset
new ColumnSeries<double> { Values = new double[] { 2.5 }, Name = "BL-08 Idling", Fill = new SolidColorPaint(SKColors.Orange) }
new ColumnSeries<double> { Values = new double[] { 3.2 }, Name = "BL-08 Active", Fill = new SolidColorPaint(SKColors.Cyan) }
new ColumnSeries<double> { Values = new double[] { 1.8 }, Name = "BL-08 Minor", Fill = new SolidColorPaint(new SKColor(128, 128, 0)) }
new ColumnSeries<double> { Values = new double[] { 0.5 }, Name = "BL-08 Off", Fill = new SolidColorPaint(SKColors.LightGray) }

// Time labels
GanttLabels = new string[] { "11:00", "12:00", "13:00", "14:00", "15:00", "16:00", "17:00", "18:00" }

// Asset labels with percentages
AssetLabels = new string[] { "BL-08 (85%)", "Q-47898 (92%)", "D-26653 (78%)" }
```

### 2. **UI Layout & Styling** - `MainWindow.xaml`

#### Adding New Charts
```xml
<!-- Add new chart panel -->
<Border Grid.Row="0" Grid.Column="2" Style="{StaticResource PanelStyle}">
    <Grid>
        <Grid.RowDefinitions>
            <RowDefinition Height="Auto"/>
            <RowDefinition Height="*"/>
        </Grid.RowDefinitions>
        
        <TextBlock Grid.Row="0" Text="New Chart Title" Style="{StaticResource PanelTitleStyle}"/>
        <Grid Grid.Row="1" Style="{StaticResource ChartContainerStyle}">
            <lvc:CartesianChart x:Name="NewChart" Series="{Binding NewChartSeries}"/>
        </Grid>
    </Grid>
</Border>
```

#### Modifying Chart Styles
```xml
<!-- Chart container styling -->
<Style x:Key="ChartContainerStyle" TargetType="Grid">
    <Setter Property="Margin" Value="8"/>
</Style>

<!-- Panel styling -->
<Style x:Key="PanelStyle" TargetType="Border">
    <Setter Property="Background" Value="#FFFFFF"/>
    <Setter Property="BorderBrush" Value="#E9ECEF"/>
    <Setter Property="BorderThickness" Value="1"/>
    <Setter Property="CornerRadius" Value="12"/>
    <Setter Property="Margin" Value="12"/>
</Style>
```

### 3. **Chart Configuration** - `MainWindow.xaml.cs`

#### Adding New Chart Axes
```csharp
// Configure axes for new chart
NewChart.XAxes = new Axis[]
{
    new Axis { Labels = vm.NewChartLabels }
};
NewChart.YAxes = new Axis[]
{
    new Axis()
};
```

#### Modifying Existing Chart Axes
```csharp
// Distance chart axes
DistanceChart.XAxes = new Axis[]
{
    new Axis { Labels = vm.DistanceLabels }
};

// Engine hours chart axes
EngineHoursChart.XAxes = new Axis[]
{
    new Axis { Labels = vm.EngineHoursLabels }
};
```

## 🎨 Color Customization

### Available Colors (SkiaSharp)
```csharp
// Basic colors
SKColors.Red, SKColors.Green, SKColors.Blue, SKColors.Orange
SKColors.Purple, SKColors.Cyan, SKColors.Yellow, SKColors.Gray

// Custom colors
new SKColor(128, 0, 0)      // Maroon
new SKColor(128, 128, 0)    // Olive
new SKColor(255, 0, 0)      // Bright Red
```

### Chart Color Examples
```csharp
// Area chart fill with transparency
Fill = new SolidColorPaint(SKColors.Orange.WithAlpha(80))

// Line stroke
Stroke = new SolidColorPaint(SKColors.Orange, 3)

// Bar fill
Fill = new SolidColorPaint(SKColors.Green)
```

## 📊 Adding New Charts

### Step 1: Add Data to ViewModel
```csharp
// In DashboardViewModel.cs
private ObservableCollection<ISeries> _newChartSeries;
public ObservableCollection<ISeries> NewChartSeries
{
    get => _newChartSeries;
    set
    {
        _newChartSeries = value;
        OnPropertyChanged();
    }
}

// In InitializeCharts() method
NewChartSeries = new ObservableCollection<ISeries>
{
    new LineSeries<double>
    {
        Values = new double[] { 1, 2, 3, 4, 5 },
        Name = "New Series",
        Stroke = new SolidColorPaint(SKColors.Blue, 3)
    }
};
```

### Step 2: Add UI Element
```xml
<!-- In MainWindow.xaml -->
<lvc:CartesianChart x:Name="NewChart" Series="{Binding NewChartSeries}"/>
```

### Step 3: Configure Axes
```csharp
// In MainWindow.xaml.cs
NewChart.XAxes = new Axis[]
{
    new Axis { Labels = vm.NewChartLabels }
};
```

## 🔧 Common Modifications

### Changing Chart Types
```csharp
// Line Chart
new LineSeries<double> { Values = data }

// Bar Chart
new ColumnSeries<double> { Values = data }

// Area Chart
new LineSeries<double> { Values = data, Fill = new SolidColorPaint(color) }

// Pie Chart
new PieSeries<double> { Values = new double[] { value }, Name = "Name" }
```

### Adding Tooltips
```xml
<!-- In XAML -->
<lvc:CartesianChart Series="{Binding Series}" TooltipPosition="Top"/>
```

### Adding Legends
```xml
<!-- In XAML -->
<lvc:CartesianChart Series="{Binding Series}" LegendPosition="Bottom"/>
```

### Modifying Chart Titles
```xml
<!-- In XAML -->
<TextBlock Text="New Chart Title" Style="{StaticResource PanelTitleStyle}"/>
```

## 🚀 Adding New Tabs

### Step 1: Add Tab Item
```xml
<!-- In MainWindow.xaml -->
<TabItem Header="New Tab" Style="{StaticResource TabItemStyle}">
    <Grid>
        <!-- Tab content -->
    </Grid>
</TabItem>
```

### Step 2: Add Tab Styling
```xml
<!-- In Window.Resources -->
<Style x:Key="TabItemStyle" TargetType="TabItem">
    <Setter Property="FontSize" Value="14"/>
    <Setter Property="FontWeight" Value="SemiBold"/>
    <Setter Property="Padding" Value="20,10"/>
</Style>
```

## 🔍 Debugging Tips

### Check Data Binding
```csharp
// Add debug output in ViewModel
Console.WriteLine($"Data count: {DistanceSeries.Count}");
```

### Verify Chart Configuration
```csharp
// Check if axes are properly set
if (DistanceChart.XAxes != null && DistanceChart.XAxes.Length > 0)
{
    Console.WriteLine("X-axis configured");
}
```

### Test Chart Data
```csharp
// Add simple test data
Values = new double[] { 1, 2, 3, 4, 5 }  // Simple test values
```

## 📝 Best Practices

1. **Data Consistency**: Ensure data arrays match label arrays in length
2. **Color Consistency**: Use consistent colors across related charts
3. **Naming Conventions**: Use descriptive names for series and properties
4. **Error Handling**: Add null checks for data binding
5. **Performance**: Avoid large datasets in UI thread

## 🆘 Troubleshooting

### Chart Not Displaying
- Check if Series property is bound correctly
- Verify data arrays are not empty
- Ensure axes are configured properly

### Data Not Updating
- Implement INotifyPropertyChanged properly
- Check if OnPropertyChanged() is called
- Verify data binding in XAML

### Build Errors
- Check NuGet package references
- Verify .NET version compatibility
- Ensure all using statements are present

### Runtime Errors
- Check for null reference exceptions
- Verify chart data initialization
- Ensure proper exception handling 