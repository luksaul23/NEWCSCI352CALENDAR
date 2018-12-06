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
        OleDbConnection todoCN;
        Dictionary<string, string> eventDict = new Dictionary<string, string>();
        Dictionary<string, string> eventDictIDs = new Dictionary<string, string>();
        List<string> toDoList = new List<string>();
        List<CheckBox> checkBoxes = new List<CheckBox>();
        
        int MAX_TODOS = 5;

        public MainWindow()
        {
            InitializeComponent();

            checkBoxes.Add(checkBox1);
            checkBoxes.Add(checkBox2);
            checkBoxes.Add(checkBox3);
            checkBoxes.Add(checkBox4);
            checkBoxes.Add(checkBox5);

            cn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\\Events.accdb");
            readEventsFromDatabase();

            todoCN = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\\ToDos.accdb");

            checkBox1.Visibility = System.Windows.Visibility.Hidden;
            updateToDos();

            MonthSelector.Items.Add("October");
            MonthSelector.Items.Add("November");
            MonthSelector.Items.Add("December");
            MonthSelector.Items.Add("January");
            MonthSelector.Items.Add("February");

            //Define the columns
            ColumnDefinition col0 = new ColumnDefinition();
            ColumnDefinition col1 = new ColumnDefinition();
            ColumnDefinition col2 = new ColumnDefinition();
            ColumnDefinition col3 = new ColumnDefinition();
            ColumnDefinition col4 = new ColumnDefinition();
            ColumnDefinition col5 = new ColumnDefinition();
            ColumnDefinition col6 = new ColumnDefinition();
            //ColumnDefinition col7 = new ColumnDefinition();

            //Add the columns
            calendar.ColumnDefinitions.Add(col0);
            calendar.ColumnDefinitions.Add(col1);
            calendar.ColumnDefinitions.Add(col2);
            calendar.ColumnDefinitions.Add(col3);
            calendar.ColumnDefinitions.Add(col4);
            calendar.ColumnDefinitions.Add(col5);
            calendar.ColumnDefinitions.Add(col6);
            //todoListGrid.ColumnDefinitions.Add(col7);

            //Define the rows
            RowDefinition row0 = new RowDefinition();
            RowDefinition row1 = new RowDefinition();
            RowDefinition row2 = new RowDefinition();
            RowDefinition row3 = new RowDefinition();
            RowDefinition row4 = new RowDefinition();
            RowDefinition row5 = new RowDefinition();
            RowDefinition row6 = new RowDefinition();
            RowDefinition row7 = new RowDefinition();
            //RowDefinition row8 = new RowDefinition();
            //RowDefinition row9 = new RowDefinition();
            //RowDefinition row10 = new RowDefinition();
            //RowDefinition row11 = new RowDefinition();
            //RowDefinition row12 = new RowDefinition();



            //Add the rows
            calendar.RowDefinitions.Add(row0);
            calendar.RowDefinitions.Add(row1);
            calendar.RowDefinitions.Add(row2);
            calendar.RowDefinitions.Add(row3);
            calendar.RowDefinitions.Add(row4);
            calendar.RowDefinitions.Add(row5);
            calendar.RowDefinitions.Add(row6);
            calendar.RowDefinitions.Add(row7);
            //todoListGrid.RowDefinitions.Add(row8);
            //todoListGrid.RowDefinitions.Add(row9);
            //todoListGrid.RowDefinitions.Add(row10);
            //todoListGrid.RowDefinitions.Add(row11);
            //todoListGrid.RowDefinitions.Add(row12);
            //populateList();
            if (MonthSelector.SelectedIndex == 0)
            {
                string month = "October";
                October october = new October(this, eventDict);
                AbsFactory Factory = new MonthFactory(this, eventDict);
                calendar.Children.Clear();
                Factory.ChangeMonth(month);
            }


        }

        //private void populateList()
        //{
           
        //    for(int i = 0; i < 5; i++)
        //    {
        //        CheckBox checkBox = new CheckBox();
        //        checkBox.Content = "Test";
        //        checkBox.VerticalAlignment = VerticalAlignment.Center;
        //        checkBox.HorizontalAlignment = HorizontalAlignment.Center;

        //        Grid.SetColumn(checkBox, 0);
        //        Grid.SetRow(checkBox, i);
        //        checkBoxes.Add(checkBox);
        //        todoListGrid.Children.Add(checkBox);
        //    }
        //    //todoListGrid.Children.Add(checkBox);
        //}

        private void refreshCalendar()
        {
            readEventsFromDatabase();
            string month = MonthSelector.SelectedItem.ToString();
            AbsFactory Factory = new MonthFactory(this, eventDict);
            calendar.Children.Clear();
            Factory.ChangeMonth(month);
        }
        

        private void MonthSelector_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            readEventsFromDatabase();
            string month = MonthSelector.SelectedItem.ToString();
            AbsFactory Factory = new MonthFactory(this, eventDict);
            calendar.Children.Clear();
            Factory.ChangeMonth(month);
        }

        private void readEventsFromDatabase()
        {
            eventDict.Clear();
            eventDictIDs.Clear();
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



        private void addEventButton_Click(object sender, RoutedEventArgs e)
        {

            AddEvent addEventWindow = new AddEvent();
            addEventWindow.Show();

            readEventsFromDatabase();
            //refreshEventList();
            refreshCalendar();
        }

        private void removeEvent_Click(object sender, RoutedEventArgs e)
        {
            RemoveEvent removeEventWindow = new RemoveEvent();
            removeEventWindow.Show();

            readEventsFromDatabase();
            //refreshEventList();
            refreshCalendar();
        }

        private void updateToDos()
        {
            // Hide all checkboxes so user doesn't see changes
            for (int i = 0; i < checkBoxes.Count(); ++i)
            {
                checkBoxes[i].Visibility = Visibility.Hidden;
            }

            // Set up database connection
            string query = "select * from ToDos";
            OleDbCommand cmd = new OleDbCommand(query, todoCN);
            todoCN.Open();
            OleDbDataReader read = cmd.ExecuteReader();
            int verticalOffset = 150;


            toDoList.Clear();
            while (read.Read())
            {
                // Update list holding all to-dos
                toDoList.Add(read[0].ToString());
            }
            // Update check boxes
            int numToDos = toDoList.Count();
            for (int i = 0; i < numToDos; ++i)
            {
               
                //checkBox2.Content = "In updateToDos()";
                checkBoxes[i].Content = toDoList[i];
                checkBoxes[i].Visibility = Visibility.Visible;
                
                //CheckBox c = new CheckBox();
                //c.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
                //c.VerticalAlignment = System.Windows.VerticalAlignment.Top;
                //c.Margin = new System.Windows.Thickness(1067, 300, 0, 0);
                //c.Content = toDoList[i];
                //c.Visibility = System.Windows.Visibility.Visible;
                //mainGrid.Children.Add(c);
                
            }

            if (numToDos == MAX_TODOS)
            {
                addToDoBox.Visibility = Visibility.Hidden;
                addToDoButton.Visibility = Visibility.Hidden;
            }
            else
            {
                addToDoBox.Visibility = Visibility.Visible;
                addToDoButton.Visibility = Visibility.Visible;
            }
            todoCN.Close();
        }

        private void addToDoButton_Click(object sender, RoutedEventArgs e)
        {
            int numToDos = toDoList.Count();
            if (numToDos < MAX_TODOS)
            {
                string todo = addToDoBox.Text;
                string query = "INSERT into ToDos (ToDo) Values(@ToDo)";
                OleDbCommand cmd = new OleDbCommand(query, todoCN);
                todoCN.Open();
                cmd.Parameters.Add("@ToDo", OleDbType.VarChar).Value = todo;
                cmd.ExecuteNonQuery();
                addToDoBox.Text = "";
                todoCN.Close();
                updateToDos();
            }
               
        }

        private void checkBox1_Checked(object sender, RoutedEventArgs e)
        {
            // Remove item from database
            //string td = this.Content.ToString();
            OleDbCommand cmd = new OleDbCommand("DELETE from ToDos WHERE [ToDo]= @ToDo", todoCN);
            todoCN.Open();
            cmd.Parameters.AddWithValue("@ToDo", checkBox1.Content.ToString());

            cmd.ExecuteNonQuery();
            todoCN.Close();
            // uncheck box
            checkBox1.IsChecked = false;
            // Update checkboxes
            updateToDos();
        }

        private void checkBox2_Checked(object sender, RoutedEventArgs e)
        {
            // Remove item from database
            //string td = this.Content.ToString();
            OleDbCommand cmd = new OleDbCommand("DELETE from ToDos WHERE [ToDo]= @ToDo", todoCN);
            todoCN.Open();
            cmd.Parameters.AddWithValue("@ToDo", checkBox2.Content.ToString());

            cmd.ExecuteNonQuery();
            todoCN.Close();
            // uncheck box
            checkBox2.IsChecked = false;
            // Update checkboxes
            updateToDos();
        }

        private void checkBox3_Checked(object sender, RoutedEventArgs e)
        {
            // Remove item from database
            //string td = this.Content.ToString();
            OleDbCommand cmd = new OleDbCommand("DELETE from ToDos WHERE [ToDo]= @ToDo", todoCN);
            todoCN.Open();
            cmd.Parameters.AddWithValue("@ToDo", checkBox3.Content.ToString());

            cmd.ExecuteNonQuery();
            todoCN.Close();
            // uncheck box
            checkBox3.IsChecked = false;
            // Update checkboxes
            updateToDos();
        }

        private void checkBox4_Checked_1(object sender, RoutedEventArgs e)
        {
            // Remove item from database
            //string td = this.Content.ToString();
            OleDbCommand cmd = new OleDbCommand("DELETE from ToDos WHERE [ToDo]= @ToDo", todoCN);
            todoCN.Open();
            cmd.Parameters.AddWithValue("@ToDo", checkBox4.Content.ToString());

            cmd.ExecuteNonQuery();
            todoCN.Close();
            // uncheck box
            checkBox4.IsChecked = false;
            // Update checkboxes
            updateToDos();
        }

        private void checkBox5_Checked_1(object sender, RoutedEventArgs e)
        {
            // Remove item from database
            //string td = this.Content.ToString();
            OleDbCommand cmd = new OleDbCommand("DELETE from ToDos WHERE [ToDo]= @ToDo", todoCN);
            todoCN.Open();
            cmd.Parameters.AddWithValue("@ToDo", checkBox5.Content.ToString());

            cmd.ExecuteNonQuery();
            todoCN.Close();
            // uncheck box
            checkBox5.IsChecked = false;
            // Update checkboxes
            updateToDos();
        }
    }
}
