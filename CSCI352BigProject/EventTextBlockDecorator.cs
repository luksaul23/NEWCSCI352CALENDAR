using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace CSCI352BigProject
{
    abstract class EventTextBlockDecorator : TextBlock
    {
        private TextBlock _eventTitle;

        public EventTextBlockDecorator(TextBlock eventBlock)
        {
            this._eventTitle = eventBlock;
        }

        abstract public void changeColor();
    }
}
