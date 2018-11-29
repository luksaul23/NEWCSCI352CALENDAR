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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CSCI352BigProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        string data = "";
        OleDbConnection cn;

        
        Dictionary<string, string> eventDict = new Dictionary<string, string>();

        public MainWindow()
        {
            InitializeComponent();

            cn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\\Events.accdb");
            readEventsFromDatabase();

            MonthSelector.Items.Add("October");
            MonthSelector.Items.Add("November");
            MonthSelector.Items.Add("December");
            MonthSelector.Items.Add("January");

            //Define the columns
            ColumnDefinition col0 = new ColumnDefinition();
            ColumnDefinition col1 = new ColumnDefinition();
            ColumnDefinition col2 = new ColumnDefinition();
            ColumnDefinition col3 = new ColumnDefinition();
            ColumnDefinition col4 = new ColumnDefinition();
            ColumnDefinition col5 = new ColumnDefinition();
            ColumnDefinition col6 = new ColumnDefinition();

            //Add the columns
            calendar.ColumnDefinitions.Add(col0);
            calendar.ColumnDefinitions.Add(col1);
            calendar.ColumnDefinitions.Add(col2);
            calendar.ColumnDefinitions.Add(col3);
            calendar.ColumnDefinitions.Add(col4);
            calendar.ColumnDefinitions.Add(col5);
            calendar.ColumnDefinitions.Add(col6);

            //Define the rows
            RowDefinition row0 = new RowDefinition();
            RowDefinition row1 = new RowDefinition();
            RowDefinition row2 = new RowDefinition();
            RowDefinition row3 = new RowDefinition();
            RowDefinition row4 = new RowDefinition();
            RowDefinition row5 = new RowDefinition();
            RowDefinition row6 = new RowDefinition();
            RowDefinition row7 = new RowDefinition();



            //Add the rows
            calendar.RowDefinitions.Add(row0);
            calendar.RowDefinitions.Add(row1);
            calendar.RowDefinitions.Add(row2);
            calendar.RowDefinitions.Add(row3);
            calendar.RowDefinitions.Add(row4);
            calendar.RowDefinitions.Add(row5);
            calendar.RowDefinitions.Add(row6);
            calendar.RowDefinitions.Add(row7);

            if (MonthSelector.SelectedIndex == 0)
            {
                October october = new October(this, eventDict);
                october.SetDays();
            }
        }

        private void MonthSelector_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string month = MonthSelector.SelectedItem.ToString();
            AbsFactory Factory = new MonthFactory(this, eventDict);
            calendar.Children.Clear();
            Factory.ChangeMonth(month);

            TextBlock title = new TextBlock();
            title.Text = month;
            title.FontSize = 40;
            title.FontWeight = FontWeights.Bold;
            title.HorizontalAlignment = HorizontalAlignment.Center;
            title.VerticalAlignment = VerticalAlignment.Center;
            Grid.SetRow(title, 0);
            Grid.SetColumnSpan(title, 7);

            
        }

        void ClearCalendar()
        {
            for (int i = 2; i < calendar.RowDefinitions.Count; i++)
            {
                for (int j = 0; j < calendar.ColumnDefinitions.Count; j++)
                {
                    TextBlock day = new TextBlock();
                    day.Text = "";
                    day.HorizontalAlignment = HorizontalAlignment.Left;
                    day.VerticalAlignment = VerticalAlignment.Top;
                    calendar.Children.Add(day);
                }
            }

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
                }



            }

            cn.Close();
        }
        private void showEventsButton_Click(object sender, RoutedEventArgs e)
        {
            textBox1.Text = "";
            data = "";
            string query = "select * from Events";
            OleDbCommand cmd = new OleDbCommand(query, cn);
            cn.Open();
            OleDbDataReader read = cmd.ExecuteReader();
            while (read.Read())
            {
                data += read[1].ToString() + " " + read[2].ToString() + "\n";               
            }
            
            textBox1.Text = data;

            cn.Close();
        }

        private void addEventButton_Click(object sender, RoutedEventArgs e)
        {
            string query = "select * from Events";
            //OleDbCommand cmd = new OleDbCommand(query, cn);
            String date = dateBox.Text;
            String ev = eventBox.Text;
            

            // Code for inserting found at:
            // https://stackoverflow.com/questions/19275557/c-sharp-inserting-data-from-a-form-into-an-access-database
            OleDbCommand cmd = new OleDbCommand("INSERT into Events (EventDate, Event) Values(@EventDate, @Event)", cn);
            cn.Open();

            cmd.Parameters.Add("@EventDate", OleDbType.VarChar).Value = date;
            cmd.Parameters.Add("@Event", OleDbType.VarChar).Value = ev;

            cmd.ExecuteNonQuery();
            /*
            using (OleDbConnection myCon = new OleDbConnection(ConfigurationManager.ConnectionStrings["DbConn"].ToString()))
            {
                OleDbCommand cmd = new OleDbCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "insert into Items ([Item_Name],[Item_Price]) values (?,?);
   cmd.Parameters.AddWithValue("@item", itemNameTBox.Text);
                cmd.Parameters.AddWithValue("@price", Convert.ToDouble(itemPriceTBox.Text));
                cmd.Connection = myCon;
                myCon.Open();
                cmd.ExecuteNonQuery();
                System.Windows.Forms.MessageBox.Show("An Item has been successfully added", "Caption", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            }
            */

            /*
            OleDbDataReader read = cmd.ExecuteReader();
            while (read.Read())
            {
                data += read[1].ToString() + " " + read[2].ToString() + "\n";
            }

            textBox1.Text = data;
            */

            cn.Close();

            readEventsFromDatabase();
        }

   
    }
}
