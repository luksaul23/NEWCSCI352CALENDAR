using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSCI352BigProject
{
    class August : Months
    {
        private MainWindow _mw;
        Dictionary<string, string> _eventPairs = new Dictionary<string, string>();

        public August(MainWindow mainWindow, Dictionary<string, string> eventPairs)
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
            return 31;
        }

        public override string year()
        {
            return "2019";
        }


    }
}
