using System;
using System.Windows;
using System.Windows.Controls;
using System.Globalization;
using System.Windows.Data;
using System.Linq;

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
        public static void DeleteButtonClicked(Object sender, EventArgs e)
        {

        }
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

        public static void InsertColumns(Grid toInsert, int ammount)
        {
            for(int i = 0; i < ammount; i++)
                toInsert.ColumnDefinitions.Add(new ColumnDefinition());
            
            
        }

        
        public static void WriteToRow<T>(Grid grid, T[] row, int rowNum)
        {
            int counter = 1;
            foreach(var n in row) {
                System.Windows.Controls.TextBox txt = new System.Windows.Controls.TextBox();
                txt.IsReadOnly = true;
                txt.Text = n.ToString();
                txt.TextAlignment = TextAlignment.Center;

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

            Button button = new Button();

            button.Click += DeleteButtonClicked;
            button.Name = "DeleteRow";
            button.Content = "Delete the row";
            Grid.SetColumn(button, 0);
            Grid.SetRow(button, toInsert.RowDefinitions.Count() -1);
            toInsert.Children.Add(button);

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

        string[] col = { "Hello", "World", "nice", "day" };
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
            GridFunctions.WriteToRow(grd, col, 0);
            GridFunctions.ResizeGrid(grd, bord);
            

        }

        public MainWindow()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
            
        }
    }
}
