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

namespace CSCI352BigProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //populate grid with boxes
            ColumnDefinition col0 = new ColumnDefinition();
            ColumnDefinition col1 = new ColumnDefinition();
            ColumnDefinition col2 = new ColumnDefinition();
            ColumnDefinition col3 = new ColumnDefinition();
            ColumnDefinition col4 = new ColumnDefinition();
            ColumnDefinition col5 = new ColumnDefinition();
            ColumnDefinition col6 = new ColumnDefinition();

            primaryCalendar.ColumnDefinitions.Add(col0);
            primaryCalendar.ColumnDefinitions.Add(col1);
            primaryCalendar.ColumnDefinitions.Add(col2);
            primaryCalendar.ColumnDefinitions.Add(col3);
            primaryCalendar.ColumnDefinitions.Add(col4);
            primaryCalendar.ColumnDefinitions.Add(col5);
            primaryCalendar.ColumnDefinitions.Add(col6);

            RowDefinition row0 = new RowDefinition();
            RowDefinition row1 = new RowDefinition();
            RowDefinition row2 = new RowDefinition();
            RowDefinition row3 = new RowDefinition();
            RowDefinition row4 = new RowDefinition();

            primaryCalendar.RowDefinitions.Add(row0);
            primaryCalendar.RowDefinitions.Add(row1);
            primaryCalendar.RowDefinitions.Add(row2);
            primaryCalendar.RowDefinitions.Add(row3);
            primaryCalendar.RowDefinitions.Add(row4);

            

            //row0.Style{
               // Border gridBorder = new Border()
              //  {
               //     BorderThickness = new Thickness()
               //    {
                //        Bottom = 1,
                //        Left = 1,
                //        Right = 1,
                //        Top = 1
               //     },
                //    BorderBrush = new SolidColorBrush(Colors.Black)
               // };
           // };

            primaryCalendar.Background = new SolidColorBrush(System.Windows.Media.Color.FromArgb(255, 50, 100, 0));

        }
    }
}
