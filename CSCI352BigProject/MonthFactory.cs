using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace CSCI352BigProject
{
    class MonthFactory : AbsFactory
    {
        private MainWindow _mw;  
        Dictionary<string, string> _eventPairs = new Dictionary<string, string>();
        public string _monthStart;

        int currentDayNum = System.DateTime.Now.Day;



        public MonthFactory(MainWindow mw, Dictionary<string, string> eventPairs)
        {
            _mw = mw;
            _eventPairs = eventPairs;
        }

        public void addBorders()
        {
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
        }

        public void addDays()
        {
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
            rectangle1.Fill = System.Windows.Media.Brushes.LightBlue;
            rectangle1.Stroke = System.Windows.Media.Brushes.Black;
            rectangle1.StrokeThickness = 2;
            Grid.SetRow(rectangle1, 1);
            Grid.SetColumnSpan(rectangle1, 7);

            addBorders();
            _mw.calendar.Children.Add(rectangle1);
            _mw.calendar.Children.Add(sunday);
            _mw.calendar.Children.Add(monday);
            _mw.calendar.Children.Add(tuesday);
            _mw.calendar.Children.Add(wednesday);
            _mw.calendar.Children.Add(thursday);
            _mw.calendar.Children.Add(friday);
            _mw.calendar.Children.Add(saturday);

        }

        public string setEvent(int c, string month)
        {
            
                string eventName = "";
                string temp = "";

                foreach (var k in _eventPairs)
                {
                    if (k.Key.Contains(month))
                    {
                        //code for extracting date found at: https://stackoverflow.com/questions/844461/return-only-digits-0-9-from-a-string/844479#844479
                        temp = new String(k.Key.Where(Char.IsDigit).ToArray());

                        if (temp == c.ToString())
                        {
                            eventName += k.Value;
                        }
                    }
                }
                return eventName;
        }

        public void addTitle(MainWindow mw, string month, Months Month)
        {
            TextBlock title = new TextBlock();
            title.Text = month + " " + Month.year();
            title.FontSize = 40;
            title.FontWeight = FontWeights.Bold;
            title.HorizontalAlignment = HorizontalAlignment.Center;
            title.VerticalAlignment = VerticalAlignment.Center;
            Grid.SetRow(title, 0);
            Grid.SetColumnSpan(title, 7);
            _mw.calendar.Children.Add(title);
        }

        public override void buildMonth(string monthStart, string monthName, int monthLength)
        {
            string tempmonth = monthName;
            if (monthStart == "Sunday")
            {
                int count = 1;

                for (int i = 2; i < _mw.calendar.RowDefinitions.Count; i++)
                {
                    for (int j = 0; j < _mw.calendar.ColumnDefinitions.Count; j++)
                    {
                        TextBlock day = new TextBlock();
                        day.Text = count.ToString();
                        day.HorizontalAlignment = HorizontalAlignment.Left;
                        day.VerticalAlignment = VerticalAlignment.Top;
                        TextBlock eventTitle = new TextBlock();
                        EventTextBlockDecorator decorator = new ChangeColor(eventTitle);
                        decorator.HorizontalAlignment = HorizontalAlignment.Center;
                        decorator.VerticalAlignment = VerticalAlignment.Center;
                        day.Margin = new Thickness(10, 10, 0, 0);

                        if (count > monthLength)
                        {
                            day.Text = "";
                            decorator.Text = "";
                        }
                        else
                        {
                            Grid.SetRow(day, i);
                            Grid.SetColumn(day, j);
                            Grid.SetRow(decorator, i);
                            Grid.SetColumn(decorator, j);
                            decorator.Text = setEvent(count, monthName);
                            if (currentDayNum == count)
                            {
                                decorator.changeColor();
                            }

                            count++;
                        }
                        _mw.calendar.Children.Add(day);
                        _mw.calendar.Children.Add(decorator);

                    }
                }
            }
            else if (monthStart == "Monday")
            {
                int count = 0;

                for (int i = 2; i < _mw.calendar.RowDefinitions.Count; i++)
                {
                    for (int j = 0; j < _mw.calendar.ColumnDefinitions.Count; j++)
                    {
                        TextBlock day = new TextBlock();
                        day.Text = count.ToString();
                        day.HorizontalAlignment = HorizontalAlignment.Left;
                        day.VerticalAlignment = VerticalAlignment.Top;
                        TextBlock eventTitle = new TextBlock();
                        EventTextBlockDecorator decorator = new ChangeColor(eventTitle);
                        decorator.HorizontalAlignment = HorizontalAlignment.Center;
                        decorator.VerticalAlignment = VerticalAlignment.Center;
                        day.Margin = new Thickness(10, 10, 0, 0);
                        if (count == 0)
                        {
                            int temp = count + 1;
                            day.Text = "";
                            Grid.SetRow(day, i);
                            Grid.SetColumn(day, temp);
                            decorator.Text = "";
                            Grid.SetRow(decorator, i);
                            Grid.SetColumn(decorator, temp);

                            count++;
                        }
                        else if (count > monthLength)
                        {
                            day.Text = "";
                            decorator.Text = "";

                        }
                        else
                        {
                            Grid.SetRow(day, i);
                            Grid.SetColumn(day, j);
                            Grid.SetRow(decorator, i);
                            Grid.SetColumn(decorator, j);
                            decorator.Text = setEvent(count, monthName);
                            if (count == currentDayNum)
                            {
                                decorator.changeColor();
                            }


                            count++;
                        }
                        _mw.calendar.Children.Add(day);
                        _mw.calendar.Children.Add(decorator);

                    }
                }
            }
            else if (monthStart == "Tuesday")
            {
                int count = 0;
                for (int i = 2; i < _mw.calendar.RowDefinitions.Count; i++)
                {
                    for (int j = 0; j < _mw.calendar.ColumnDefinitions.Count; j++)
                    {
                        TextBlock day = new TextBlock();
                        day.Text = count.ToString();
                        day.HorizontalAlignment = HorizontalAlignment.Left;
                        day.VerticalAlignment = VerticalAlignment.Top;
                        TextBlock eventTitle = new TextBlock();
                        EventTextBlockDecorator decorator = new ChangeColor(eventTitle);
                        decorator.HorizontalAlignment = HorizontalAlignment.Center;
                        decorator.VerticalAlignment = VerticalAlignment.Center;
                        day.Margin = new Thickness(10, 10, 0, 0);
                        if (count == 0)
                        {
                            int temp = count + 1;
                            day.Text = "";
                            Grid.SetRow(day, i);
                            Grid.SetColumn(day, temp);
                            decorator.Text = "";
                            Grid.SetRow(decorator, i);
                            Grid.SetColumn(decorator, temp);
                            count++;
                        }
                        else if (count == 1)
                        {
                            int temp = count + 2;
                            day.Text = "";
                            Grid.SetRow(day, i);
                            Grid.SetColumn(day, temp);
                            decorator.Text = "";
                            Grid.SetRow(decorator, i);
                            Grid.SetColumn(decorator, temp);
                            count++;
                        }
                        else if (count > monthLength + 1)
                        {
                            day.Text = "";
                            decorator.Text = "";
                        }
                        else
                        {
                            int temp = count - 1;
                            Grid.SetRow(day, i);
                            Grid.SetColumn(day, j);
                            day.Text = temp.ToString();
                            Grid.SetRow(decorator, i);
                            Grid.SetColumn(decorator, j);
                            decorator.Text = setEvent(temp,monthName);
                            if (temp == currentDayNum)
                            {
                                decorator.changeColor();
                            }

                            count++;
                        }
                        _mw.calendar.Children.Add(day);
                        _mw.calendar.Children.Add(decorator);

                    }
                }
            }
            else if (monthStart == "Wednesday")
            {
                int count = 0;
                for (int i = 2; i < _mw.calendar.RowDefinitions.Count; i++)
                {
                    for (int j = 0; j < _mw.calendar.ColumnDefinitions.Count; j++)
                    {
                        TextBlock day = new TextBlock();
                        day.Text = count.ToString();
                        day.HorizontalAlignment = HorizontalAlignment.Left;
                        day.VerticalAlignment = VerticalAlignment.Top;
                        TextBlock eventTitle = new TextBlock();
                        EventTextBlockDecorator decorator = new ChangeColor(eventTitle);
                        decorator.HorizontalAlignment = HorizontalAlignment.Center;
                        decorator.VerticalAlignment = VerticalAlignment.Center;
                        day.Margin = new Thickness(10, 10, 0, 0);
                        if (count == 0)
                        {
                            int temp = count + 1;
                            day.Text = "";
                            Grid.SetRow(day, i);
                            Grid.SetColumn(day, temp);
                            decorator.Text = "";
                            Grid.SetRow(decorator, i);
                            Grid.SetColumn(decorator, temp);
                            count++;
                        }
                        else if (count == 1)
                        {
                            int temp = count + 2;
                            day.Text = "";
                            Grid.SetRow(day, i);
                            Grid.SetColumn(day, temp);
                            decorator.Text = "";
                            Grid.SetRow(decorator, i);
                            Grid.SetColumn(decorator, temp);
                            count++;
                        }
                        else if (count == 2)
                        {
                            int temp = count + 3;
                            day.Text = "";
                            Grid.SetRow(day, i);
                            Grid.SetColumn(day, temp);
                            decorator.Text = "";
                            Grid.SetRow(decorator, i);
                            Grid.SetColumn(decorator, temp);

                            count++;
                        }
                        else if (count > monthLength + 2)
                        {
                            day.Text = "";
                            decorator.Text = "";
                        }
                        else
                        {
                            int temp = count - 2;
                            Grid.SetRow(day, i);
                            Grid.SetColumn(day, j);
                            day.Text = temp.ToString();
                            Grid.SetRow(decorator, i);
                            Grid.SetColumn(decorator, j);
                            decorator.Text = setEvent(temp, monthName);
                            if (temp == currentDayNum)
                            {
                                decorator.changeColor();
                            }

                            count++;
                        }
                        _mw.calendar.Children.Add(day);
                        _mw.calendar.Children.Add(decorator);

                    }
                }
            }
            else if (monthStart == "Thursday")
            {
                int count = 0;
                for (int i = 2; i < _mw.calendar.RowDefinitions.Count; i++)
                {
                    for (int j = 0; j < _mw.calendar.ColumnDefinitions.Count; j++)
                    {
                        TextBlock day = new TextBlock();
                        day.Text = count.ToString();
                        day.HorizontalAlignment = HorizontalAlignment.Left;
                        day.VerticalAlignment = VerticalAlignment.Top;
                        TextBlock eventTitle = new TextBlock();
                        EventTextBlockDecorator decorator = new ChangeColor(eventTitle);
                        decorator.HorizontalAlignment = HorizontalAlignment.Center;
                        decorator.VerticalAlignment = VerticalAlignment.Center;
                        day.Margin = new Thickness(10, 10, 0, 0);
                        if (count == 0)
                        {
                            int temp = count + 1;
                            day.Text = "";
                            Grid.SetRow(day, i);
                            Grid.SetColumn(day, temp);
                            decorator.Text = "";
                            Grid.SetRow(decorator, i);
                            Grid.SetColumn(decorator, temp);

                            count++;
                        }
                        else if (count == 1)
                        {
                            int temp = count + 2;
                            day.Text = "";
                            Grid.SetRow(day, i);
                            Grid.SetColumn(day, temp);
                            decorator.Text = "";
                            Grid.SetRow(decorator, i);
                            Grid.SetColumn(decorator, temp);

                            count++;
                        }
                        else if (count == 2)
                        {
                            int temp = count + 3;
                            day.Text = "";
                            Grid.SetRow(day, i);
                            Grid.SetColumn(day, temp);
                            decorator.Text = "";
                            Grid.SetRow(decorator, i);
                            Grid.SetColumn(decorator, temp);

                            count++;
                        }
                        else if (count == 3)
                        {
                            int temp = count + 4;
                            day.Text = "";
                            Grid.SetRow(day, i);
                            Grid.SetColumn(day, temp);
                            decorator.Text = "";
                            Grid.SetRow(decorator, i);
                            Grid.SetColumn(decorator, temp);

                            count++;
                        }
                        else if (count > monthLength + 3)
                        {
                            day.Text = "";
                            decorator.Text = "";

                        }
                        else
                        {
                            int temp = count - 3;
                            Grid.SetRow(day, i);
                            Grid.SetColumn(day, j);
                            day.Text = temp.ToString();
                            Grid.SetRow(decorator, i);
                            Grid.SetColumn(decorator, j);
                            decorator.Text = setEvent(temp,monthName);
                            if (temp == currentDayNum)
                            {
                                decorator.changeColor();
                            }
                            count++;
                        }
                        _mw.calendar.Children.Add(day);
                        _mw.calendar.Children.Add(decorator);

                    }
                }
            }
            else if (monthStart == "Friday")
            {
                int count = 0;
                for (int i = 2; i < _mw.calendar.RowDefinitions.Count; i++)
                {
                    for (int j = 0; j < _mw.calendar.ColumnDefinitions.Count; j++)
                    {
                        TextBlock day = new TextBlock();
                        day.Text = count.ToString();
                        day.HorizontalAlignment = HorizontalAlignment.Left;
                        day.VerticalAlignment = VerticalAlignment.Top;
                        TextBlock eventTitle = new TextBlock();
                        EventTextBlockDecorator decorator = new ChangeColor(eventTitle);
                        decorator.HorizontalAlignment = HorizontalAlignment.Center;
                        decorator.VerticalAlignment = VerticalAlignment.Center;
                        day.Margin = new Thickness(10, 10, 0, 0);
                        if (count == 0)
                        {
                            int temp = count + 1;
                            day.Text = "";
                            Grid.SetRow(day, i);
                            Grid.SetColumn(day, temp);
                            decorator.Text = "";
                            Grid.SetRow(decorator, i);
                            Grid.SetColumn(decorator, temp);

                            count++;
                        }
                        else if (count == 1)
                        {
                            int temp = count + 2;
                            day.Text = "";
                            Grid.SetRow(day, i);
                            Grid.SetColumn(day, temp);
                            decorator.Text = "";
                            Grid.SetRow(decorator, i);
                            Grid.SetColumn(decorator, temp);

                            count++;
                        }
                        else if (count == 2)
                        {
                            int temp = count + 3;
                            day.Text = "";
                            Grid.SetRow(day, i);
                            Grid.SetColumn(day, temp);
                            decorator.Text = "";
                            Grid.SetRow(decorator, i);
                            Grid.SetColumn(decorator, temp);

                            count++;
                        }
                        else if (count == 3)
                        {
                            int temp = count + 4;
                            day.Text = "";
                            Grid.SetRow(day, i);
                            Grid.SetColumn(day, temp);
                            decorator.Text = "";
                            Grid.SetRow(decorator, i);
                            Grid.SetColumn(decorator, temp);

                            count++;
                        }
                        else if (count == 4)
                        {
                            int temp = count + 5;
                            day.Text = "";
                            Grid.SetRow(day, i);
                            Grid.SetColumn(day, temp);
                            decorator.Text = "";
                            Grid.SetRow(decorator, i);
                            Grid.SetColumn(decorator, temp);

                            count++;
                        }
                        else if (count > monthLength + 4)
                        {
                            day.Text = "";
                            decorator.Text = "";

                        }
                        else
                        {
                            int temp = count-4;
                            Grid.SetRow(day, i);
                            Grid.SetColumn(day, j);
                            day.Text = temp.ToString();
                            Grid.SetRow(decorator, i);
                            Grid.SetColumn(decorator, j);
                            decorator.Text = setEvent(temp, monthName);
                            if (temp == currentDayNum)
                            {
                                decorator.changeColor();
                            }
                            count++;
                        }
                        _mw.calendar.Children.Add(day);
                        _mw.calendar.Children.Add(decorator);

                    }
                }
            }
            else
            {
                int count = 0;
                for (int i = 2; i < _mw.calendar.RowDefinitions.Count; i++)
                {
                    for (int j = 0; j < _mw.calendar.ColumnDefinitions.Count; j++)
                    {
                        TextBlock day = new TextBlock();
                        day.Text = count.ToString();
                        TextBlock eventTitle = new TextBlock();
                        EventTextBlockDecorator decorator = new ChangeColor(eventTitle);
                        decorator.HorizontalAlignment = HorizontalAlignment.Center;
                        decorator.VerticalAlignment = VerticalAlignment.Center;
                        day.HorizontalAlignment = HorizontalAlignment.Left;
                        day.VerticalAlignment = VerticalAlignment.Top;
                        if (currentDayNum == count)
                        {
                            decorator.changeColor();
                        }
                        day.Margin = new Thickness(10, 10, 0, 0);
                        if (count == 0)
                        {
                            int temp = count + 1;
                            day.Text = "";
                            Grid.SetRow(day, i);
                            Grid.SetColumn(day, temp);
                            decorator.Text = "";
                            Grid.SetRow(decorator, i);
                            Grid.SetColumn(decorator, temp);

                            count++;
                        }
                        else if (count == 1)
                        {
                            int temp = count + 2;
                            day.Text = "";
                            Grid.SetRow(day, i);
                            Grid.SetColumn(day, temp);
                            decorator.Text = "";
                            Grid.SetRow(decorator, i);
                            Grid.SetColumn(decorator, temp);

                            count++;
                        }
                        else if (count == 2)
                        {
                            int temp = count + 3;
                            day.Text = "";
                            Grid.SetRow(day, i);
                            Grid.SetColumn(day, temp);
                            decorator.Text = "";
                            Grid.SetRow(decorator, i);
                            Grid.SetColumn(decorator, temp);

                            count++;
                        }
                        else if (count == 3)
                        {
                            int temp = count + 4;
                            day.Text = "";
                            Grid.SetRow(day, i);
                            Grid.SetColumn(day, temp);
                            decorator.Text = "";
                            Grid.SetRow(decorator, i);
                            Grid.SetColumn(decorator, temp);

                            count++;
                        }
                        else if (count == 4)
                        {
                            int temp = count + 5;
                            day.Text = "";
                            Grid.SetRow(day, i);
                            Grid.SetColumn(day, temp);
                            decorator.Text = "";
                            Grid.SetRow(decorator, i);
                            Grid.SetColumn(decorator, temp);

                            count++;
                        }
                        else if (count == 5)
                        {
                            int temp = count + 6;
                            day.Text = "";
                            Grid.SetRow(day, i);
                            Grid.SetColumn(day, temp);
                            decorator.Text = "";
                            Grid.SetRow(decorator, i);
                            Grid.SetColumn(decorator, temp);

                            count++;
                        }
                        else if (count > monthLength + 5)
                        {
                            day.Text = "";
                            decorator.Text = "";
                        }
                        else
                        {
                            int temp = count - 5;
                            Grid.SetRow(day, i);
                            Grid.SetColumn(day, j);
                            Grid.SetRow(decorator, i);
                            Grid.SetColumn(decorator, j);
                            day.Text = temp.ToString();
                            decorator.Text = setEvent(temp, monthName);
                            if(temp == currentDayNum)
                            {
                                decorator.changeColor();
                            }
                            count++;
                        }
                        _mw.calendar.Children.Add(day);
                        _mw.calendar.Children.Add(decorator);
                    }
                }

            }
        }

        public override void ChangeMonth(string month)
        {
            if(month == "October")
            {
                Months Month = new October(_mw, _eventPairs);
                string monthName = "October";
                int monthLength = Month.returnMonthLength();
                _monthStart = Month.returnMonthStart();
                addDays();
                addTitle(_mw, monthName, Month);
                buildMonth(_monthStart, monthName, monthLength);

                _monthStart = "";

            }
            else if(month == "November")
            {
                Months Month = new November(_mw, _eventPairs);
                string monthName = "November";
                int monthLength = Month.returnMonthLength();
                _monthStart = Month.returnMonthStart();
                addDays();
                addTitle(_mw, monthName, Month);
                buildMonth(_monthStart, monthName, monthLength);

                _monthStart = "";

            }
            else if (month == "December")
            {
                Months Month = new December(_mw, _eventPairs);
                string monthName = "December";
                int monthLength = Month.returnMonthLength();
                _monthStart = Month.returnMonthStart();
                addDays();
                addTitle(_mw, monthName, Month);
                buildMonth(_monthStart, monthName, monthLength);

                _monthStart = "";

            }
            else if (month == "February")
            {
                
                Months Month = new February(_mw, _eventPairs);
                int monthLength = Month.returnMonthLength();
                string monthName = "February";
                _monthStart = Month.returnMonthStart();
                addDays();
                addTitle(_mw, monthName, Month);
                buildMonth(_monthStart, monthName, monthLength);

                _monthStart = "";

            }
            else if (month == "March")
            {

                Months Month = new March(_mw, _eventPairs);
                int monthLength = Month.returnMonthLength();
                string monthName = "March";
                _monthStart = Month.returnMonthStart();
                addDays();
                addTitle(_mw, monthName, Month);
                buildMonth(_monthStart, monthName, monthLength);

                _monthStart = "";

            }
            else if (month == "April")
            {

                Months Month = new April(_mw, _eventPairs);
                int monthLength = Month.returnMonthLength();
                string monthName = "April";
                _monthStart = Month.returnMonthStart();
                addDays();
                addTitle(_mw, monthName, Month);
                buildMonth(_monthStart, monthName, monthLength);

                _monthStart = "";

            }
            else if (month == "May")
            {

                Months Month = new May(_mw, _eventPairs);
                int monthLength = Month.returnMonthLength();
                string monthName = "May";
                _monthStart = Month.returnMonthStart();
                addDays();
                addTitle(_mw, monthName, Month);
                buildMonth(_monthStart, monthName, monthLength);

                _monthStart = "";

            }
            else if (month == "June")
            {

                Months Month = new June(_mw, _eventPairs);
                int monthLength = Month.returnMonthLength();
                string monthName = "June";
                _monthStart = Month.returnMonthStart();
                addDays();
                addTitle(_mw, monthName, Month);
                buildMonth(_monthStart, monthName, monthLength);

                _monthStart = "";

            }
            else if (month == "July")
            {

                Months Month = new July(_mw, _eventPairs);
                int monthLength = Month.returnMonthLength();
                string monthName = "July";
                _monthStart = Month.returnMonthStart();
                addDays();
                addTitle(_mw, monthName, Month);
                buildMonth(_monthStart, monthName, monthLength);

                _monthStart = "";

            }
            else if (month == "August")
            {

                Months Month = new August(_mw, _eventPairs);
                int monthLength = Month.returnMonthLength();
                string monthName = "August";
                _monthStart = Month.returnMonthStart();
                addDays();
                addTitle(_mw, monthName, Month);
                buildMonth(_monthStart, monthName, monthLength);

                _monthStart = "";

            }
            else if (month == "September")
            {

                Months Month = new September(_mw, _eventPairs);
                int monthLength = Month.returnMonthLength();
                string monthName = "September";
                _monthStart = Month.returnMonthStart();
                addDays();
                addTitle(_mw, monthName, Month);
                buildMonth(_monthStart, monthName, monthLength);

                _monthStart = "";

            }
            else
            {
                Months Month = new January(_mw, _eventPairs);
                string monthName = "January";
                int monthLength = Month.returnMonthLength();
                _monthStart = Month.returnMonthStart();
                addDays();
                addTitle(_mw, monthName, Month);
                buildMonth(_monthStart, monthName, monthLength);

                _monthStart = "";

            }
        }
        
    }
}
