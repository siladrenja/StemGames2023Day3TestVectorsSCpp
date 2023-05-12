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

namespace TestVectors
{
    
    public class myGrid
    {
        public myGrid(float width, float height, int Rows, int Columns, Window win, Brush brush)
        {
            gr = new Grid();

            border.BorderBrush = brush;
            _width = width;
            _height = height;
            gr.Width = win.ActualWidth * width;
            gr.Height = win.ActualHeight * height;
            gr.HorizontalAlignment = HorizontalAlignment.Center;
            gr.VerticalAlignment = VerticalAlignment.Top;
            border.Width = gr.Width;
            border.Height = gr.Height;

            gr.ShowGridLines = true;
           
            col = Columns;
            ro = Rows;

            for(int i = 0; i < Rows; i++)
            {
                gr.RowDefinitions.Add(new RowDefinition());
            }

            for(int i = 0; i < Columns; i++)
            {
                gr.ColumnDefinitions.Add(new ColumnDefinition());
            }
            win.SizeChanged += this.WindowResize;
            border.Child = gr;
            //win.Content = border;

        }

        public void WindowResize(object sender, SizeChangedEventArgs e)
        {
            gr.Width = e.NewSize.Width * _width;
            //gr.Height = e.NewSize.Height * _height;
            
            return;
        }

        public Grid gr;
        public Border border = new Border();
        private float col, ro;
        private float _width, _height;
    }
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < 4; i++)
            {
                grdChampions.RowDefinitions.Add(new RowDefinition());
            }

            for (int i = 0; i < 4; i++)
            {
                grdChampions.ColumnDefinitions.Add(new ColumnDefinition());
            }

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
