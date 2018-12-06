using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSCI352BigProject
{
    class September : Months
    {
        private MainWindow _mw;
        Dictionary<string, string> _eventPairs = new Dictionary<string, string>();

        public September(MainWindow mainWindow, Dictionary<string, string> eventPairs)
        {
            _mw = mainWindow;
            _eventPairs = eventPairs;

        }

        public override string returnMonthStart()
        {
            return "Sunday";
        }

        public override int returnMonthLength()
        {
            return 30;
        }

        public override string year()
        {
            return "2019";
        }


    }
}
