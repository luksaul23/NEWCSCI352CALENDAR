using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace CSCI352BigProject
{
    class ChangeColor : EventTextBlockDecorator
    {

        public ChangeColor(TextBlock eventBlock) : base(eventBlock)
        {

        }

        public override void changeColor()
        {
            this.Background = Brushes.Cyan;
        }

       
    }
}
