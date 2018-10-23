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

            MonthSelector.Items.Add("October");
            MonthSelector.Items.Add("November");
            MonthSelector.Items.Add("December");

            //Define the columns
            ColumnDefinition col0 = new ColumnDefinition();
            ColumnDefinition col1 = new ColumnDefinition();
            ColumnDefinition col2 = new ColumnDefinition();
            ColumnDefinition col3 = new ColumnDefinition();
            ColumnDefinition col4 = new ColumnDefinition();
            ColumnDefinition col5 = new ColumnDefinition();
            ColumnDefinition col6 = new ColumnDefinition();

            //Add the columns
            calendar.ColumnDefinitions.Add(col0);
            calendar.ColumnDefinitions.Add(col1);
            calendar.ColumnDefinitions.Add(col2);
            calendar.ColumnDefinitions.Add(col3);
            calendar.ColumnDefinitions.Add(col4);
            calendar.ColumnDefinitions.Add(col5);
            calendar.ColumnDefinitions.Add(col6);

            //Define the rows
            RowDefinition row0 = new RowDefinition();
            RowDefinition row1 = new RowDefinition();
            RowDefinition row2 = new RowDefinition();
            RowDefinition row3 = new RowDefinition();
            RowDefinition row4 = new RowDefinition();
            RowDefinition row5 = new RowDefinition();
            RowDefinition row6 = new RowDefinition();
            RowDefinition row7 = new RowDefinition();



            //Add the rows
            calendar.RowDefinitions.Add(row0);
            calendar.RowDefinitions.Add(row1);
            calendar.RowDefinitions.Add(row2);
            calendar.RowDefinitions.Add(row3);
            calendar.RowDefinitions.Add(row4);
            calendar.RowDefinitions.Add(row5);
            calendar.RowDefinitions.Add(row6);
            calendar.RowDefinitions.Add(row7);

            //Add Days
            TextBlock sunday = new TextBlock();
            sunday.Text = "Sunday";
            sunday.FontSize = 20;
            sunday.HorizontalAlignment = HorizontalAlignment.Center;
            sunday.VerticalAlignment = VerticalAlignment.Center;
            Grid.SetRow(sunday, 1);
            Grid.SetColumn(sunday, 0);

            TextBlock monday = new TextBlock();
            monday.Text = "Monday";
            monday.FontSize = 20;
            monday.HorizontalAlignment = HorizontalAlignment.Center;
            monday.VerticalAlignment = VerticalAlignment.Center;
            Grid.SetRow(monday, 1);
            Grid.SetColumn(monday, 1);

            TextBlock tuesday = new TextBlock();
            tuesday.Text = "Tuesday";
            tuesday.FontSize = 20;
            tuesday.HorizontalAlignment = HorizontalAlignment.Center;
            tuesday.VerticalAlignment = VerticalAlignment.Center;
            Grid.SetRow(tuesday, 1);
            Grid.SetColumn(tuesday, 2);

            TextBlock wednesday = new TextBlock();
            wednesday.Text = "Wednesday";
            wednesday.FontSize = 20;
            wednesday.HorizontalAlignment = HorizontalAlignment.Center;
            wednesday.VerticalAlignment = VerticalAlignment.Center;
            Grid.SetRow(wednesday, 1);
            Grid.SetColumn(wednesday, 3);

            TextBlock thursday = new TextBlock();
            thursday.Text = "Thursday";
            thursday.FontSize = 20;
            thursday.HorizontalAlignment = HorizontalAlignment.Center;
            thursday.VerticalAlignment = VerticalAlignment.Center;
            Grid.SetRow(thursday, 1);
            Grid.SetColumn(thursday, 4);

            TextBlock friday = new TextBlock();
            friday.Text = "Friday";
            friday.FontSize = 20;
            friday.HorizontalAlignment = HorizontalAlignment.Center;
            friday.VerticalAlignment = VerticalAlignment.Center;
            Grid.SetRow(friday, 1);
            Grid.SetColumn(friday, 5);

            TextBlock saturday = new TextBlock();
            saturday.Text = "Saturday";
            saturday.FontSize = 20;
            saturday.HorizontalAlignment = HorizontalAlignment.Center;
            saturday.VerticalAlignment = VerticalAlignment.Center;
            Grid.SetRow(saturday, 1);
            Grid.SetColumn(saturday, 6);

            Rectangle rectangle1 = new Rectangle();
            rectangle1.Fill = System.Windows.Media.Brushes.Gray;
            rectangle1.Stroke = System.Windows.Media.Brushes.Black;
            rectangle1.StrokeThickness = 2;
            Grid.SetRow(rectangle1, 1);
            Grid.SetColumnSpan(rectangle1, 7);

            TextBlock month = new TextBlock();
            month.Text = "October";
            month.FontSize = 40;
            month.FontWeight = FontWeights.Bold;
            month.HorizontalAlignment = HorizontalAlignment.Center;
            month.VerticalAlignment = VerticalAlignment.Center;
            Grid.SetRow(month, 0);
            Grid.SetColumnSpan(month, 7);

            for (int i = 2; i < calendar.RowDefinitions.Count; i++)
            {
                for(int j = 0; j < calendar.ColumnDefinitions.Count; j++)
                {
                    Rectangle rectangle2 = new Rectangle();
                    rectangle2.Stroke = System.Windows.Media.Brushes.Black;
                    rectangle2.StrokeThickness = 1;
                    Grid.SetRow(rectangle2, i);
                    Grid.SetColumn(rectangle2, j);
                    calendar.Children.Add(rectangle2);

                }
            }

            calendar.Children.Add(rectangle1);
            calendar.Children.Add(sunday);
            calendar.Children.Add(monday);
            calendar.Children.Add(tuesday);
            calendar.Children.Add(wednesday);
            calendar.Children.Add(thursday);
            calendar.Children.Add(friday);
            calendar.Children.Add(saturday);
            


        }

        private void MonthSelector_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string month = MonthSelector.SelectedItem.ToString();
        }

        void ClearCalendar()
        {
            for (int i = 2; i < calendar.RowDefinitions.Count; i++)
            {
                for (int j = 0; j < calendar.ColumnDefinitions.Count; j++)
                {
                    TextBlock day = new TextBlock();
                    day.Text = "";
                    day.HorizontalAlignment = HorizontalAlignment.Left;
                    day.VerticalAlignment = VerticalAlignment.Top;
                    calendar.Children.Add(day);
                }
            }
        }
        }
    }
}
