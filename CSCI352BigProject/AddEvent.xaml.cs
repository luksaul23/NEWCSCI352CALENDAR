using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CSCI352BigProject
{
    /// <summary>
    /// Interaction logic for AddEvent.xaml
    /// </summary>
    public partial class AddEvent : Window
    {
        public event EventHandler<CustomEventArgs> RaiseCustomEvent;
        public AddEvent()
        {
            InitializeComponent();
        }

        public string getEventTitle()
        {
            return eventTitle.Text;
        }

        public class CustomEventArgs : EventArgs
        {
            private string title;

            public CustomEventArgs(string s)
            {
                title = s;
            }

            public string Message
            {
                get { return title; }
            }
        }

        private void submitButton_Click(object sender, RoutedEventArgs e)
        {
            RaiseCustomEvent(this, new CustomEventArgs(eventTitle.Text));
        }
    }
}
