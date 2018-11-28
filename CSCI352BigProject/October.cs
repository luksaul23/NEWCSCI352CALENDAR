using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace CSCI352BigProject
{
    class October : Months
    {

        private MainWindow _mw;
        Dictionary<string, string> _eventPairs = new Dictionary<string, string>();

        public October(MainWindow mainWindow, Dictionary<string, string> eventPairs)
        {
            _mw = mainWindow;           
            _eventPairs = eventPairs;

        }

        public override void SetDays()
        {
            int count = 0;

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

            for (int i = 2; i < _mw.calendar.RowDefinitions.Count; i++)
            {
                for (int j = 0; j < _mw.calendar.ColumnDefinitions.Count; j++)
                {
                    Rectangle rectangle2 = new Rectangle();
                    rectangle2.Stroke = System.Windows.Media.Brushes.Black;
                    rectangle2.StrokeThickness = 1;
                    Grid.SetRow(rectangle2, i);
                    Grid.SetColumn(rectangle2, j);
                    _mw.calendar.Children.Add(rectangle2);

                }
            }

            _mw.calendar.Children.Add(rectangle1);
            _mw.calendar.Children.Add(sunday);
            _mw.calendar.Children.Add(monday);
            _mw.calendar.Children.Add(tuesday);
            _mw.calendar.Children.Add(wednesday);
            _mw.calendar.Children.Add(thursday);
            _mw.calendar.Children.Add(friday);
            _mw.calendar.Children.Add(saturday);

            //Check if the dictionary has an event for that month then filters
            //out the date for placing on the appropriate day
            string setEvent(int c)
            {
                string eventName = "";
                string temp = "";

                foreach(var k in _eventPairs)
                {
                    if (k.Key.Contains("October"))
                    {
                        //code for extracting date found at: https://stackoverflow.com/questions/844461/return-only-digits-0-9-from-a-string/844479#844479
                        temp = new String(k.Key.Where(Char.IsDigit).ToArray());

                        if(temp == c.ToString())
                        {
                            eventName += k.Value + "\n";
                        }
                    }
                }
                return eventName;
            }

            for (int i = 2; i < _mw.calendar.RowDefinitions.Count; i++)
            {
                for (int j = 0; j < _mw.calendar.ColumnDefinitions.Count; j++)
                {
                    TextBlock day = new TextBlock();
                    day.Text = count.ToString();
                    TextBlock eventTitle = new TextBlock();
                    day.HorizontalAlignment = HorizontalAlignment.Left;
                    day.VerticalAlignment = VerticalAlignment.Top;
                    eventTitle.HorizontalAlignment = HorizontalAlignment.Center;
                    eventTitle.VerticalAlignment = VerticalAlignment.Bottom;
                    day.Margin = new Thickness(10,10,0,0);
                    if (count == 0)
                    {
                        int temp = count + 1;
                        day.Text = "";
                        Grid.SetRow(day, i);
                        Grid.SetColumn(day, temp);
                        eventTitle.Text = "";
                        Grid.SetRow(eventTitle, i);
                        Grid.SetColumn(eventTitle, temp);

                        count++;
                    }
                    else if (count > 31)
                    {
                        day.Text = "";
                        eventTitle.Text = "";
                        
                    }
                    else
                    {
                        Grid.SetRow(day, i);
                        Grid.SetColumn(day, j);
                        Grid.SetRow(eventTitle, i);
                        Grid.SetColumn(eventTitle, j);
                        eventTitle.Text = setEvent(count);


                        count++;
                    }
                    _mw.calendar.Children.Add(day);
                    _mw.calendar.Children.Add(eventTitle);

                }
            }
            
        }


    }
}
