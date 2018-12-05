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
    /// Interaction logic for RemoveEvent.xaml
    /// </summary>
    public partial class RemoveEvent : Window
    {
        OleDbConnection cn;
        Dictionary<string, string> eventDict = new Dictionary<string, string>();
        Dictionary<string, string> eventDictIDs = new Dictionary<string, string>();

        public RemoveEvent()
        {
            cn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\\Events.accdb");
            InitializeComponent();
        }

        private void readEventsFromDatabase()
        {
            string query = "select * from Events";
            OleDbCommand cmd = new OleDbCommand(query, cn);
            cn.Open();
            OleDbDataReader read = cmd.ExecuteReader();
            while (read.Read())
            {
                if (!eventDict.ContainsKey(read[1].ToString()))
                {
                    eventDict.Add(read[1].ToString(), read[2].ToString());
                    eventDictIDs.Add(read[0].ToString(), read[2].ToString());
                }
            }
            cn.Close();
        }

        private void removeEventFromDatabase()
        {
            readEventsFromDatabase();
            string date = dateBox.Text;
            string ev = eventBox.Text;
            decimal id = 0;

            foreach (var k in eventDictIDs)
            {
                if (k.Value.Contains(ev))
                {
                    id = Decimal.Parse(k.Key);
                }
            }

            // Code for inserting found at:
            // https://stackoverflow.com/questions/19275557/c-sharp-inserting-data-from-a-form-into-an-access-database
            OleDbCommand cmd = new OleDbCommand("DELETE from Events WHERE id=" + id, cn);
            cn.Open();

            cmd.ExecuteNonQuery();
            cn.Close();
        }

        private void removeEvent_Click(object sender, RoutedEventArgs e)
        {
            removeEventFromDatabase();
            this.Close();
        }
    }
}
