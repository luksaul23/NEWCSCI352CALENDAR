using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace CSCI352BigProject
{
    class November : Months
    {
        private MainWindow _mw;
        Dictionary<string, string> _eventPairs = new Dictionary<string, string>();

        public November(MainWindow mainWindow, Dictionary<string, string> eventPairs)
        {
            _mw = mainWindow;
            _eventPairs = eventPairs;

        }

        public override string returnMonthStart()
        {
            return "Thursday";
        }

        public override int returnMonthLength()
        {
            return 30;
        }

        public override string year()
        {
            return "2018";
        }


    }
}
