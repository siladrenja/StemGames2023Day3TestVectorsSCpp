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
        public static System.Collections.Generic.List<RowDefinition> rows;
        public static Grid g;
        public static void DeleteButtonClicked(Object sender, EventArgs e)
        {
            string name = ((Button)sender).Content.ToString();
            int num;
            int.TryParse(name.Substring(name.Length-1), out num);
            RemoveRow(g, num-1);
        }
        /*
            Pozovi na kraju, kad ubaciš sve redove, ovo će prilagoditi Grid broju redova
         */
        public static void ResizeGrid(Grid grid)
        {
            //toResize.Height = grid.RowDefinitions.Count() * 25;
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
            //if(row != null)rows.Append(row);
            
           if (toInsert.RowDefinitions.Count() == 1) return row;
           Button button = new Button();
           button.Click += DeleteButtonClicked;
           button.Name = "DeleteRow" + toInsert.RowDefinitions.Count().ToString();
           button.Content = "Delete the row";
           button.IsEnabled = true;
           button.Visibility = Visibility.Visible;
           button.Margin = new Thickness(10);
           //button.Width = 50;
           Grid.SetColumn(button, 0);
           Grid.SetRow(button, toInsert.RowDefinitions.Count() - 1);
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

        public static void RemoveRow(Grid toRemove, int index)
        {
            Remove(toRemove, rows[index]);
        }

    }
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public static void LoadButtonClicked(Object sender, EventArgs e)
        {

        }
        public static void SaveButtonClicked(Object sender, EventArgs e)
        {

        }


        string[] col = { "Hello", "World", "nice", "day" };
        void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < 10; i++)
            {
                GridFunctions.InsertRow(grd);
            }

            
            GridFunctions.InsertColumns(grd, 5);
            
            GridFunctions.WriteToRow(grd, col, 0);
            GridFunctions.WriteToRow(grd, col, 1);
            GridFunctions.ResizeGrid(grd);
            

        }

        public MainWindow()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
            LoadBtn.Click += LoadButtonClicked;
            SaveBtn.Click += SaveButtonClicked;
            
        }
        //matko je nadalje
        public static void DrawGrid(object obj, int[,] multilist)
        {
            for (int i = 0; i < multilist.GetLength(0); i++)
            {
                GridFunctions.InsertRow(grd);
                GridFunctions.WriteToRow(grd, GetRowValues(multilist, i), i);
            }

            GridFunctions.ResizeGrid(grd, toResize);
        }

        private static int[] GetRowValues(int[,] multilist, int rowIndex)
        {
            int rowLength = multilist.GetLength(1);
            int[] rowValues = new int[rowLength];
            for (int j = 0; j < rowLength; j++)
            {
                rowValues[j] = multilist[rowIndex, j];
            }
            return rowValues;
        }
    }
}
