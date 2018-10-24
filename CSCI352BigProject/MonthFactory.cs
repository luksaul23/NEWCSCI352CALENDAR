using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace CSCI352BigProject
{
    class MonthFactory : AbsFactory
    {
        private MainWindow _mw;


        public MonthFactory(MainWindow mw)
        {
            _mw = mw;
        }

        public override void ChangeMonth(string month)
        {
            if(month == "October")
            {
                Months Month = new October(_mw);
                Month.SetDays();

                TextBlock title = new TextBlock();
                title.Text = month;
                title.FontSize = 40;
                title.FontWeight = FontWeights.Bold;
                title.HorizontalAlignment = HorizontalAlignment.Center;
                title.VerticalAlignment = VerticalAlignment.Center;
                Grid.SetRow(title, 0);
                Grid.SetColumnSpan(title, 7);
                _mw.calendar.Children.Add(title);

            }
            else if(month == "November")
            {
                Months Month = new November(_mw);
                Month.SetDays();

                TextBlock title = new TextBlock();
                title.Text = month;
                title.FontSize = 40;
                title.FontWeight = FontWeights.Bold;
                title.HorizontalAlignment = HorizontalAlignment.Center;
                title.VerticalAlignment = VerticalAlignment.Center;
                Grid.SetRow(title, 0);
                Grid.SetColumnSpan(title, 7);
                _mw.calendar.Children.Add(title);

            }
            else
            {
                Months Month = new December(_mw);
                Month.SetDays();

                TextBlock title = new TextBlock();
                title.Text = month;
                title.FontSize = 40;
                title.FontWeight = FontWeights.Bold;
                title.HorizontalAlignment = HorizontalAlignment.Center;
                title.VerticalAlignment = VerticalAlignment.Center;
                Grid.SetRow(title, 0);
                Grid.SetColumnSpan(title, 7);
                _mw.calendar.Children.Add(title);

            }
        }
        
    }
}
