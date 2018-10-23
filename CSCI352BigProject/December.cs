using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace CSCI352BigProject
{
    class December : Months
    {
        private MainWindow _mw;
        public December(MainWindow mainWindow)
        {
            _mw = mainWindow;

        }

        public override void SetDays()
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
