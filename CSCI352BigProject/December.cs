﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace CSCI352BigProject
{
    class December : Months
    {
        //main window to gain access to the calendar object
        private MainWindow _mw;
        public int monthNum = 12;

        public December(MainWindow mainWindow)
        {
            _mw = mainWindow;

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

            //Add the rectangles with borders to the normal days
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

            //Add the days of the week and the background for teh days to the calendar
            _mw.calendar.Children.Add(rectangle1);
            _mw.calendar.Children.Add(sunday);
            _mw.calendar.Children.Add(monday);
            _mw.calendar.Children.Add(tuesday);
            _mw.calendar.Children.Add(wednesday);
            _mw.calendar.Children.Add(thursday);
            _mw.calendar.Children.Add(friday);
            _mw.calendar.Children.Add(saturday);


            //process for adding the textblocks that contain the day numbers

            for (int i = 2; i < _mw.calendar.RowDefinitions.Count; i++)
            {
                for (int j = 0; j < _mw.calendar.ColumnDefinitions.Count; j++)
                {
                    TextBlock day = new TextBlock();
                    day.Text = count.ToString();
                    day.HorizontalAlignment = HorizontalAlignment.Left;
                    day.VerticalAlignment = VerticalAlignment.Top;
                    day.Margin = new Thickness(10, 10, 0, 0);
                    if (count == 0)
                    {
                        int temp = count + 1;
                        day.Text = "";
                        Grid.SetRow(day, i);
                        Grid.SetColumn(day, temp);
                        count++;
                    }
                    else if (count == 1)
                    {
                        int temp = count + 2;
                        day.Text = "";
                        Grid.SetRow(day, i);
                        Grid.SetColumn(day, temp);
                        count++;
                    }
                    else if (count == 2)
                    {
                        int temp = count + 3;
                        day.Text = "";
                        Grid.SetRow(day, i);
                        Grid.SetColumn(day, temp);
                        count++;
                    }
                    else if (count == 3)
                    {
                        int temp = count + 4;
                        day.Text = "";
                        Grid.SetRow(day, i);
                        Grid.SetColumn(day, temp);
                        count++;
                    }
                    else if (count == 4)
                    {
                        int temp = count + 5;
                        day.Text = "";
                        Grid.SetRow(day, i);
                        Grid.SetColumn(day, temp);
                        count++;
                    }
                    else if (count == 5)
                    {
                        int temp = count + 6;
                        day.Text = "";
                        Grid.SetRow(day, i);
                        Grid.SetColumn(day, temp);
                        count++;
                    }
                    else if (count > 36)
                    {
                        day.Text = "";
                    }
                    else
                    {
                        int temp = count - 5;
                        Grid.SetRow(day, i);
                        Grid.SetColumn(day, j);
                        day.Text = temp.ToString();
                        count++;
                    }
                    _mw.calendar.Children.Add(day);
                }
            }

        }
    }
}
