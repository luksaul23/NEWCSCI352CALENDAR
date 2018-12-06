﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
        Dictionary<string, string> _eventPairs = new Dictionary<string, string>();

        public December(MainWindow mainWindow, Dictionary<string, string> eventPairs)
        {
            _mw = mainWindow;
            _eventPairs = eventPairs;

        }

        public override string returnMonthStart()
        {
            return "Saturday";
        }

        public override int returnMonthLength()
        {
            return 31;
        }

        public override string year()
        {
            return "2018";
        }



    }
}
