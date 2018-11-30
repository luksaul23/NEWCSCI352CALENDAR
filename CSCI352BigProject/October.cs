﻿using System;
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

        public override string returnMonthStart()
        {
            return "Monday";
        }

       
            
        


    }
}
