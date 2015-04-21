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
using System.Windows.Navigation;
using System.Windows.Shapes;
using MySql.Data.MySqlClient;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {   
            
            InitializeComponent();
        }

        private void bSubmit_Click(object sender, RoutedEventArgs e)
        {
            MySqlConnection con;
            string server = "localhost";
            string database = "streaming";
            string uid = "root";
            string password = "";
            string conString;
            conString = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";
            con = new MySqlConnection(conString);

            //Open Connection to database.
            try
            {
                con.Open();
                string name = tbName.Text;
                string father = tbFather.Text;
                string query = "INSERT INTO users VALUES ('','" + name + "', '" + father + "') ";
                MySqlCommand order = new MySqlCommand(query, con);

                //ExecuteNonQuery is for such queries which don't return anything.
                order.ExecuteNonQuery();

                //Close connection
                try
                {
                    con.Close();
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            catch (MySqlException ex)
            {
                //0: Cannot connect to server.
                //1045: Invalid username and/or password.
                switch (ex.Number)
                {
                    case 0:
                        MessageBox.Show("Cannot connect to server.");
                        break;
                    case 1045:
                        MessageBox.Show("Invalid username/password.");
                        break;
                }
            }
        }
    }
}
