# How-to-create-a-Column-Chart-in-WinUI

The WinUI Column Chart (Vertical Bar Chart) uses vertical bars (called columns) to display different values of one or more items. This section explains how to create WinUI Column Charts.

The user guide Documentation helps you to acquire more knowledge on charts and their features. You can also refer to the Feature Tour site to get an overview of all the features in the chart.

### Step 1: 
Create a simple project using the instructions given in the Getting Started with your first WinUI app documentation.

### Step 2: 
Add Syncfusion.Chart.WinUI NuGet to the project and import the SfCartesianChart namespace as follows.

**[XAML]**
```
xmlns:chart="using:Syncfusion.UI.Xaml.Charts"
```
**[C#]**
```
using Syncfusion.UI.Xaml.Charts;
```
### Step 3: 
Initialize an empty chart with PrimaryAxis and SecondaryAxis as shown in the following code sample.

**[XAML]**
```
<chart:SfCartesianChart>
    <chart:SfCartesianChart.PrimaryAxis>
        <chart:CategoryAxis/>
    </chart:SfCartesianChart.PrimaryAxis>
    <chart:SfCartesianChart.SecondaryAxis>
        <chart:NumericalAxis/>
    </chart:SfCartesianChart.SecondaryAxis>
</chart:SfCartesianChart>
```
**[C#]**
```
SfCartesianChart chart = new SfCartesianChart();

//Initializing Primary Axis
CategoryAxis primaryAxis = new CategoryAxis();

chart.PrimaryAxis = primaryAxis;

//Initializing Secondary Axis
NumericalAxis secondaryAxis = new NumericalAxis();

chart.SecondaryAxis = secondaryAxis;

this.Content = chart;
```
### Step 4: 
Initialize a data model that represents a data point for the Column Chart.

**[C#]**
```
public class Model
{
   public string Country { get; set; }

   public double Counts { get; set; }

   public Model(string name, double count)
   {
       Country = name;
       Counts = count;
   }
}
```
### Step 5: 
Create a ViewModel class with a data collection property using the above model and initialize a list of objects as shown in the following code sample.

**[C#]**
```
public class ViewModel
    {
        public ObservableCollection<Model> Data { get; set; }

        public ViewModel()
        {
            Data = new ObservableCollection<Model>()
            {
                new Model("Korea",39),
                new Model("India",20),
                new Model("Africa",  61),
                new Model("China",65),
                new Model("France",45),
            };
        }
    }
```
### Step 6: 
Set the ViewModel instance as the DataContext of your window; this is done to bind properties of ViewModel to the chart.

> Note: Add namespace of ViewModel class to your XAML page, if you prefer to set DataContext in XAML.

**[XAML]**
```
xmlns:viewModel="using:CartesianChartDesktop"
. . .
<chart:SfCartesianChart>

      <chart:SfCartesianChart.DataContext>
             <viewModel:ViewModel/>
      </chart:SfCartesianChart.DataContext>
</chart:SfCartesianChart>
```
**[C#]**
```
SfCartesianChart chart = new SfCartesianChart();
chart.DataContext = new ViewModel();
```
### Step 7: Populate chart with data.

As we are going to visualize the comparison of internet users from various countries in the data model, add ColumnSeries to SfCartesianChart.Series property, and then bind the Data property of the above ViewModel to the ColumnSeries ItemsSource property, as shown in the following code sample.

> Note: Need to set XBindingPath and YBindingPath properties so that series will fetch values from the respective properties in the data model to plot the series.

**[XAML]**
```
<chart:SfCartesianChart>
    <chart:SfCartesianChart.DataContext>
           <viewModel:ViewModel/>
     </chart:SfCartesianChart.DataContext>
. . .
    <chart:SfCartesianChart.Series>
        <chart:ColumnSeries ItemsSource="{Binding Data}" 
                            XBindingPath="Country" 
                            YBindingPath="Counts" 
                            ShowDataLabels="True"/>
    </chart:SfCartesianChart.Series>

</chart:SfCartesianChart> 
```
**[C#]**
```
SfCartesianChart chart = new SfCartesianChart();
chart.DataContext = new ViewModel();
. . .

ColumnSeries series = new ColumnSeries();
series.SetBinding(ColumnSeries.ItemsSourceProperty, new Binding() { Path = new PropertyPath("Data") });
series.XBindingPath = "Country";
series.YBindingPath = "Counts";
series.ShowDataLabels = true;

chart.Series.Add(series);
this.Content = chart;
```
Output
 
