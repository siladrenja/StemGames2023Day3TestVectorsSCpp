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
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Interop;
using System.Globalization;

namespace TestVectors
{

    public class ProportionalHeightConverter : IMultiValueConverter
    {
        public double MinHeight { get; set; } = 0;
        public double MaxHeight { get; set; } = double.PositiveInfinity;

        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            double width = (double)values[0];
            double minWidth = (double)values[1];
            double minHeight = 300; // Set your desired minimum height here
            double ratio = minHeight / minWidth;
            double height = width * ratio;
            return Math.Min(Math.Max(height, MinHeight), MaxHeight);
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }



    public class GridFunctions
    {
        /*
            Pozovi na kraju, kad ubaciš sve redove, ovo će prilagoditi Grid broju redova
         */
        public static void ResizeGrid(Grid toResize)
        {

        }

        //očisti grid da nema redova ni stupaca
        public static void ClearGrid(Grid toClear)
        {

        }

        public static DataGridTextColumn InsertColumn(Grid toInsert)
        {

            return null;
        }

        public static void WriteToRow(Array row)
        {

        }

        public static RowDefinition InsertRow(Grid toInsert)
        {
            RowDefinition row = new RowDefinition();
            toInsert.RowDefinitions.Add(row);
            return row;
        }

        public static void Remove(Grid toRemove, ColumnDefinition column)
        {
            toRemove.ColumnDefinitions.Remove(column);
        }

        public static void Remove(Grid toRemove, RowDefinition row)
        {
            toRemove.RowDefinitions.Remove(row);
            
        }

        public static void Clear(Grid toClear)
        {
            toClear.ColumnDefinitions.Clear();
            toClear.RowDefinitions.Clear();
        }
        


    }
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < 10; i++)
            {
                grdChampions.RowDefinitions.Add(new RowDefinition());
            }

            for (int i = 0; i < 4; i++)
            {
                grdChampions.ColumnDefinitions.Add(new ColumnDefinition());
            }
            //grdChampions.ColumnDefinitions.Clear();

            //this.Content = grdChampions;
            // Brush br = new SolidColorBrush(Color.FromRgb(0,0,0));
            //
            // myGrid g = new myGrid(0.8f, 1f, 3, 3, this, br);
            //
            // this.Content = g.border;

        }

        public MainWindow()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
            
        }
    }
}
