using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSCI352BigProject
{
    class February : Months
    {
        private MainWindow _mw;
        Dictionary<string, string> _eventPairs = new Dictionary<string, string>();

        public February(MainWindow mainWindow, Dictionary<string, string> eventPairs)
        {
            _mw = mainWindow;
            _eventPairs = eventPairs;

        }

        public override string returnMonthStart()
        {
            return "Friday";
        }

        public override int returnMonthLength()
        {
            return 28;
        }

        public override string year()
        {
            return "2019";
        }
    }
}
