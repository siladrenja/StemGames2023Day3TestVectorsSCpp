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
        public static void ResizeGrid(Grid grid, Border toResize)
        {
            toResize.Height = grid.RowDefinitions.Count() * 25;
        }

        //očisti grid da nema redova ni stupaca
        public static void ClearGrid(Grid toClear)
        {
            toClear.ColumnDefinitions.Clear();
            toClear.RowDefinitions.Clear();
        }

        public static ColumnDefinition InsertColumn(Grid toInsert)
        {
            ColumnDefinition col = new ColumnDefinition();
            toInsert.ColumnDefinitions.Add(col);
            return col;
        }

        
        public static void WriteToRow<T>(Grid grid, T[] row, int rowNum)
        {
            int counter = 1;
            foreach(var n in row) {
                System.Windows.Controls.TextBox txt = new System.Windows.Controls.TextBox();
                txt.Name = n.ToString();
                Grid.SetColumn(txt, counter);
                Grid.SetRow(txt, rowNum);
                grid.Children.Add(txt);
                counter++;
            }
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

    }
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        Array col = new Array({ "Hello", "World", "!", " " });
        void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < 10; i++)
            {
                grd.RowDefinitions.Add(new RowDefinition());
            }

            for (int i = 0; i < 4; i++)
            {
                grd.ColumnDefinitions.Add(new ColumnDefinition());
            }

            GridFunctions.ResizeGrid(grd, bord);
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
