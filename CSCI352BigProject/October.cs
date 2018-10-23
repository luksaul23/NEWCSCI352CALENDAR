using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace CSCI352BigProject
{
    class October : Months
    {

        private MainWindow _mw;
        public October(MainWindow mainWindow)
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
                    else if (count > 31)
                    {
                        day.Text = "";
                    }
                    else
                    {
                        Grid.SetRow(day, i);
                        Grid.SetColumn(day, j);
                        count++;
                    }
                    _mw.calendar.Children.Add(day);                       
                }                    
            }
            
        }


    }
}
