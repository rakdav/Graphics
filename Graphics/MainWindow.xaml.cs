using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Forms.DataVisualization.Charting;

namespace Graphics
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                double x1 = double.Parse(X1.Text);
                double x2 = double.Parse(X2.Text);
                double h = double.Parse(H.Text);
                int count = (int)Math.Ceiling((x2 - x1) / h)+1;
                double[] x = new double[count];
                double[] y1 = new double[count];
                double[] y2 = new double[count];
                for(int i=0;i<count;i++)
                {
                    x[i] = x1 + h * i;
                    y1[i] = Math.Sin(x[i]);
                    y2[i] = Math.Cos(x[i]);
                }
                chart.ChartAreas.Add(new ChartArea("Default"));
                chart.Series.Add(new Series("Series1"));
                chart.Series.Add(new Series("Series2"));
                chart.Series["Series1"].ChartArea = "Default";
                chart.Series["Series1"].ChartType = SeriesChartType.Bar;
                chart.Series["Series2"].ChartArea = "Default";
                chart.Series["Series2"].ChartType = SeriesChartType.Bar;
                chart.Series["Series1"].Points.DataBindXY(x, y1);
                chart.Series["Series2"].Points.DataBindXY(x, y2);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
