using System;
using System.Collections.Generic;
using System.Linq;
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
using Microsoft.Research.DynamicDataDisplay;
using Microsoft.Research.DynamicDataDisplay.DataSources;

namespace _03MeteoData
{
    public partial class MainWindow : Window
    {
        DataLoader loader;

        CompleteViewportRestriction viewport;

        public MainWindow()
        {
            InitializeComponent();

            loader = new DataLoader();
            loader.Open("meteodata.csv");

            // turn off plotter anti-alias to boost render performance
            RenderOptions.SetEdgeMode(plotter, EdgeMode.Aliased);

            // restrict viewport
            viewport = new CompleteViewportRestriction(
                null, null,
                -150, 150,
                null, null,
                300, 300);

            plotter.Viewport.Restrictions.Add(viewport);

            // simulovat kliknuti na tlacitko Reset
            OnResetDateClick(null, null);
        }

        void OnSetDateClick(object sender, RoutedEventArgs e)
        {
            try
            {
                MakeGraph(loader.GetTemperatures(dateFrom.SelectedDate.Value, dateTo.SelectedDate.Value));
            }
            catch
            {
                MessageBox.Show("Nesprávně zadané datum.");
            }
        }

        void OnResetDateClick(object sender, RoutedEventArgs e)
        {
            dateFrom.SelectedDate = null;
            dateTo.SelectedDate = null;
            MakeGraph(loader.GetTemperatures());
        }


        void MakeGraph(IEnumerable<Temperature> source)
        {
            // remove old graphs
            plotter.Children.RemoveAll<IPlotterElement, LineGraph>();

            // set viewport
            //viewport.MinX = dateAxis.ConvertToDouble(cache.StartTime);
            //viewport.MaxX = dateAxis.ConvertToDouble(cache.EndTime);

            // create axis data sources
            EnumerableDataSource<Temperature> axisTemp = new EnumerableDataSource<Temperature>(source);
            axisTemp.SetXMapping(point => dateAxis.ConvertToDouble(point.Date));
            axisTemp.SetYMapping(point => point.Temp);

            EnumerableDataSource<Temperature> axisMin = new EnumerableDataSource<Temperature>(source);
            axisMin.SetXMapping(point => dateAxis.ConvertToDouble(point.Date));
            axisMin.SetYMapping(point => point.Minimum);

            EnumerableDataSource<Temperature> axisMax = new EnumerableDataSource<Temperature>(source);
            axisMax.SetXMapping(point => dateAxis.ConvertToDouble(point.Date));
            axisMax.SetYMapping(point => point.Maximum);

            EnumerableDataSource<Temperature> axisAvg = new EnumerableDataSource<Temperature>(source);
            axisAvg.SetXMapping(point => dateAxis.ConvertToDouble(point.Date));
            axisAvg.SetYMapping(point => point.Average);

            // add new graphs
            plotter.Children.Add(new LineGraph(axisTemp)
            {
                LinePen = new Pen(Brushes.Red, 2),
                Description = new PenDescription("Naměřená teplota")
            });
            plotter.Children.Add(new LineGraph(axisMin)
            {
                LinePen = new Pen(Brushes.Green, 1),
                Description = new PenDescription("Minimální teplota")
            });
            plotter.Children.Add(new LineGraph(axisMax)
            {
                LinePen = new Pen(Brushes.Orange, 1),
                Description = new PenDescription("Maximální teplota")
            });
            plotter.Children.Add(new LineGraph(axisAvg)
            {
                LinePen = new Pen(Brushes.Blue, 1),
                Description = new PenDescription("Průměrná teplota")
            });

            // display
            plotter.FitToView();
        }
    }
}
