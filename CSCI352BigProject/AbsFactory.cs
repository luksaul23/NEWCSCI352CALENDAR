using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSCI352BigProject
{
    abstract class AbsFactory
    {
        abstract public void ChangeMonth(string month);
        abstract public void buildMonth(string day,string monthName);
    }
}
