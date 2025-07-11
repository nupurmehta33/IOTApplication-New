# IoT Dashboard Application

A modern .NET Core WPF desktop application featuring an interactive dashboard with real-time IoT data visualization.

## 🚀 Features

### Dashboard Tab
- **Traveled Distance Chart**: Area chart comparing current vs previous period distances
- **Engine Hours Chart**: Stacked bar chart showing ignition and idling hours
- **Activity Breakdown**: Donut chart with center text showing total hours
- **Messages Received**: Bar chart displaying daily message counts

### Day Overview Tab
- **Gantt Chart**: Horizontal stacked bar timeline showing asset utilization
- **Asset Timeline**: Color-coded states (Idling, Active, Minor, Off)
- **Percentage Stats**: Utilization percentages for each machine

## 🛠️ Prerequisites

- **.NET 8.0 SDK** or later
- **Visual Studio 2022** or **Visual Studio Code**
- **Windows OS** (WPF is Windows-specific)

## 📦 Installation

1. **Clone the repository**:
   ```bash
   git clone <repository-url>
   cd IOTApplication
   ```

2. **Restore dependencies**:
   ```bash
   cd WpfApp1
   dotnet restore
   ```

3. **Build the application**:
   ```bash
   dotnet build
   ```

## 🏃‍♂️ Running the Application

### Method 1: Command Line
```bash
cd WpfApp1
dotnet run
```

### Method 2: Visual Studio
1. Open `IOTApplication.sln` in Visual Studio
2. Set `WpfApp1` as the startup project
3. Press `F5` or click "Start Debugging"

### Method 3: Visual Studio Code
1. Open the project folder in VS Code
2. Install C# extension if not already installed
3. Press `Ctrl+F5` to run without debugging

## 🎯 Application Structure

```
IOTApplication/
├── IOTApplication.sln          # Solution file
└── WpfApp1/                   # Main application
    ├── App.xaml               # Application entry point
    ├── App.xaml.cs            # Application logic
    ├── MainWindow.xaml        # Main UI layout
    ├── MainWindow.xaml.cs     # Window logic
    ├── ViewModels/
    │   └── DashboardViewModel.cs  # Data and chart configuration
    └── WpfApp1.csproj        # Project file
```

## 📊 Dashboard Components

### Traveled Distance Chart
- **Type**: Area chart with line series
- **Data**: Daily distance values (Mar 22 - Apr 3)
- **Features**: Current vs Previous period comparison
- **Colors**: Orange (current), Gray (previous)

### Engine Hours Chart
- **Type**: Stacked bar chart
- **Data**: Daily engine hours (Mar 20 - Apr 4)
- **Features**: Ignition vs Idling breakdown
- **Colors**: Green (ignition), Orange (idling)

### Activity Breakdown
- **Type**: Donut chart
- **Data**: Activity distribution percentages
- **Features**: Center text showing total hours
- **Colors**: Maroon, Green, Orange

### Messages Received
- **Type**: Bar chart
- **Data**: Daily message counts (Mar 22 - Apr 3)
- **Features**: Orange bars with realistic values
- **Range**: ~1,900 to ~3,100 messages per day

### Day Overview (Gantt Chart)
- **Type**: Horizontal stacked bar timeline
- **Assets**: BL-08, Q-47898, D-26653
- **Time Range**: 11:00 to 18:00
- **States**: Idling (Orange), Active (Cyan), Minor (Olive), Off (Light Grey)

## 🎨 UI Features

- **Modern Design**: Clean, professional styling with shadows and rounded corners
- **Tab Navigation**: Switch between Dashboard and Day Overview
- **Responsive Layout**: Adapts to window resizing
- **Interactive Charts**: Hover tooltips and legends
- **Close Button**: Red "✕" button in top-right corner

## 📈 Technologies Used

- **.NET 8.0**: Modern .NET framework
- **WPF**: Windows Presentation Foundation for UI
- **LiveCharts2**: Professional charting library
- **MVVM Pattern**: Clean architecture with ViewModels
- **SkiaSharp**: Graphics rendering for charts

## 🔧 Troubleshooting

### Build Issues
- Ensure .NET 8.0 SDK is installed
- Run `dotnet restore` to restore packages
- Check that all NuGet packages are properly referenced

### Runtime Issues
- Verify Windows OS compatibility
- Check that LiveCharts2 package is properly installed
- Ensure all chart data is properly initialized

### Chart Display Issues
- Check that chart series are properly bound
- Verify axis configurations in code-behind
- Ensure data arrays match expected lengths


## 🤝 Contributing

1. Fork the repository
2. Create a feature branch
3. Make your changes
4. Test thoroughly
5. Submit a pull request

## 📞 Support

For issues and questions:
- Check the troubleshooting section above
- Review the code documentation