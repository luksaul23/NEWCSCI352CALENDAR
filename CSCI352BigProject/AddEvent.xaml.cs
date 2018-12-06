using System;
using System.Collections.Generic;
using System.Data.OleDb;
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
        OleDbConnection cn;
        public event EventHandler eventAdded;

        public AddEvent()
        {
            cn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\\Events.accdb");
            InitializeComponent();

        }


        public void addEventToDatabase()
        {
            String _date = dateBox.Text;
            String _ev = eventBox.Text;

            if (dateBox.Text != "" || eventBox.Text != "")
            {
                // Code for inserting found at:
                // https://stackoverflow.com/questions/19275557/c-sharp-inserting-data-from-a-form-into-an-access-database
                OleDbCommand cmd = new OleDbCommand("INSERT into Events (EventDate, Event) Values(@EventDate, @Event)", cn);
                cn.Open();

                cmd.Parameters.Add("@EventDate", OleDbType.VarChar).Value = _date;
                cmd.Parameters.Add("@Event", OleDbType.VarChar).Value = _ev;

                cmd.ExecuteNonQuery();

                dateBox.Text = "";
                eventBox.Text = "";

                cn.Close();
            }
            else
            {
                // Code for inserting found at:
                // https://stackoverflow.com/questions/19275557/c-sharp-inserting-data-from-a-form-into-an-access-database
                OleDbCommand cmd = new OleDbCommand("select * from Events", cn);
                cn.Open();

                cmd.ExecuteNonQuery();

                dateBox.Text = "";
                eventBox.Text = "";

                cn.Close();
            }
        }

        private void addEvent_Click(object sender, RoutedEventArgs e)
        {
            addEventToDatabase();
            this.Close();
        }

        
    }
}
