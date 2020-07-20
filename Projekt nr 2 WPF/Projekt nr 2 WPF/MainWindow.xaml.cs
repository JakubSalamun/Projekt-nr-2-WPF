using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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

namespace Projekt_nr_2_WPF
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SqlConnection sqlConnection = new SqlConnection(@"Data Source=DESKTOP-MPTGS57\SQLEXPRESS;Initial Catalog=NowyDzien;Integrated Security=True;
                        Connect Timeout=30;Encrypt=False;
                        TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        string sql,sql_help;
        string mw_userID,help_dnia_tygodnia;

        DataTable dt = new DataTable("Info");

        private void Add_Button_Click(object sender, RoutedEventArgs e)
        {
            //int selectedIndex = plan_dnia.SelectedIndex;
            //object selectedItem = plan_dnia.SelectedItem;
            //int selectedIndex2 = plan_dnia2.SelectedIndex;
            //object selectedItem2 = plan_dnia2.SelectedItem;

            // if (selectedIndex>selectedIndex2||(selectedIndex==(-1) ||selectedIndex2==(-1)))
            if (plan_dnia.SelectedIndex.Equals(-1)||plan_dnia2.SelectedIndex.Equals(-1))
            {
                MessageBox.Show("Prosze podać godzine!");
            }
           
            else
            {
                //text1.Text = selectedItem.ToString();
               // text2.Text = selectedItem2.ToString();
            }
            user_add_info();
            add_info();



        }

        public MainWindow()
        {
            InitializeComponent();
            mw_userID = Help.user_help;
            DateTime dt = DateTime.Now;
            help_dnia_tygodnia = dt.DayOfWeek.ToString();
            help_select_day_2.Content = dt.DayOfWeek.ToString();


            combobox();
            combobox2();
            combobox3();
            plan_dnia.SelectedIndex = 34;
            plan_dnia2.SelectedIndex = 34;
            plan_dnia3.SelectedItem = help_dnia_tygodnia;


            add_info();



        }
    
        private void combobox()
        {
            plan_dnia.Items.Add("07:00:00");
            plan_dnia.Items.Add("07:30:00");
            plan_dnia.Items.Add("08:00:00");
            plan_dnia.Items.Add("08:30:00");
            plan_dnia.Items.Add("09:00:00");
            plan_dnia.Items.Add("09:30:00");
            plan_dnia.Items.Add("10:00:00");
            plan_dnia.Items.Add("10:30:00");
            plan_dnia.Items.Add("11:00:00");
            plan_dnia.Items.Add("11:30:00");
            plan_dnia.Items.Add("12:00:00");
            plan_dnia.Items.Add("12:30:00");
            plan_dnia.Items.Add("13:00:00");
            plan_dnia.Items.Add("13:30:00");
            plan_dnia.Items.Add("14:00:00");
            plan_dnia.Items.Add("14:30:00");
            plan_dnia.Items.Add("15:00:00");
            plan_dnia.Items.Add("15:30:00");
            plan_dnia.Items.Add("16:00:00");
            plan_dnia.Items.Add("16:30:00");
            plan_dnia.Items.Add("17:00:00");
            plan_dnia.Items.Add("17:30:00");
            plan_dnia.Items.Add("18:00:00");
            plan_dnia.Items.Add("18:30:00");
            plan_dnia.Items.Add("19:00:00");
            plan_dnia.Items.Add("19:30:00");
            plan_dnia.Items.Add("20:00:00");
            plan_dnia.Items.Add("20:30:00");
            plan_dnia.Items.Add("21:00:00");
            plan_dnia.Items.Add("21:30:00");
            plan_dnia.Items.Add("22:00:00");
            plan_dnia.Items.Add("22:30:00");
            plan_dnia.Items.Add("23:00:00");
            plan_dnia.Items.Add("23:0:00");
            plan_dnia.Items.Add("00:00:00");
        }
        private void combobox2()
        {
            plan_dnia2.Items.Add("07:00:00");
            plan_dnia2.Items.Add("07:30:00");
            plan_dnia2.Items.Add("08:00:00");
            plan_dnia2.Items.Add("08:30:00");
            plan_dnia2.Items.Add("09:00:00");
            plan_dnia2.Items.Add("09:30:00");
            plan_dnia2.Items.Add("10:00:00");
            plan_dnia2.Items.Add("10:30:00");
            plan_dnia2.Items.Add("11:00:00");
            plan_dnia2.Items.Add("11:30:00");
            plan_dnia2.Items.Add("12:00:00");
            plan_dnia2.Items.Add("12:30:00");
            plan_dnia2.Items.Add("13:00:00");
            plan_dnia2.Items.Add("13:30:00");
            plan_dnia2.Items.Add("14:00:00");
            plan_dnia2.Items.Add("14:30:00");
            plan_dnia2.Items.Add("15:00:00");
            plan_dnia2.Items.Add("15:30:00");
            plan_dnia2.Items.Add("16:00:00");
            plan_dnia2.Items.Add("16:30:00");
            plan_dnia2.Items.Add("17:00:00");
            plan_dnia2.Items.Add("17:30:00");
            plan_dnia2.Items.Add("18:00:00");
            plan_dnia2.Items.Add("18:30:00");
            plan_dnia2.Items.Add("19:00:00");
            plan_dnia2.Items.Add("19:30:00");
            plan_dnia2.Items.Add("20:00:00");
            plan_dnia2.Items.Add("20:30:00");
            plan_dnia2.Items.Add("21:00:00");
            plan_dnia2.Items.Add("21:30:00");
            plan_dnia2.Items.Add("22:00:00");
            plan_dnia2.Items.Add("22:30:00");
            plan_dnia2.Items.Add("23:00:00");
            plan_dnia2.Items.Add("23:30:00");
            plan_dnia2.Items.Add("00:00:00");
        }

        private void combobox3()
        {
            plan_dnia3.Items.Add("Monday");
            plan_dnia3.Items.Add("Tuesday");
            plan_dnia3.Items.Add("Wednesday");
            plan_dnia3.Items.Add("Thursday");
            plan_dnia3.Items.Add("Friday");
            plan_dnia3.Items.Add("Saturday");
            plan_dnia3.Items.Add("Sunday");
        }



        private void add_info()
        {
            DateTime date_t = DateTime.Now;
            help_dnia_tygodnia = date_t.DayOfWeek.ToString();
            sqlConnection.Open();
            DataTable dataTable = new DataTable();
            sql = "select [Czas_Od],[Czas_Do],[Czynnosc] from Czas where Uzytkownik=@mw_userID and Dzien=@help_dnia_tygodnia Order by Czas_Od";
            SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection);
            sqlCommand.Parameters.AddWithValue("@mw_userID", mw_userID);
            sqlCommand.Parameters.AddWithValue("@help_dnia_tygodnia", help_dnia_tygodnia);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCommand);
            
            dataAdapter.Fill(dataTable);
            dt = dataTable;
            plan_dnia_dgv.ItemsSource = dt.DefaultView;
            sqlConnection.Close();
        }
        private void poniedzialek()
        {
            sqlConnection.Open();
            DataTable dataTable = new DataTable();
            sql = "select [Czas_Od],[Czas_Do],[Czynnosc] from Czas where Uzytkownik=@mw_userID and Dzien='Monday'";
            SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection);
            sqlCommand.Parameters.AddWithValue("@mw_userID", mw_userID);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCommand);

            dataAdapter.Fill(dataTable);
            dt = dataTable;
            plan_dnia_dgv_1.ItemsSource = dt.DefaultView;
            sqlConnection.Close();

        }
        private void wtorek()
        {
            sqlConnection.Open();
            DataTable dataTable = new DataTable();
            sql = "select [Czas_Od],[Czas_Do],[Czynnosc] from Czas where Uzytkownik=@mw_userID and Dzien='Tuesday'";
            SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection);
            sqlCommand.Parameters.AddWithValue("@mw_userID", mw_userID);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCommand);

            dataAdapter.Fill(dataTable);
            dt = dataTable;
            plan_dnia_dgv_1.ItemsSource = dt.DefaultView;
            sqlConnection.Close();

        }
        private void sroda()
        {
            sqlConnection.Open();
            DataTable dataTable = new DataTable();
            sql = "select [Czas_Od],[Czas_Do],[Czynnosc] from Czas where Uzytkownik=@mw_userID and Dzien='Wednesday'";
            SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection);
            sqlCommand.Parameters.AddWithValue("@mw_userID", mw_userID);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCommand);

            dataAdapter.Fill(dataTable);
            dt = dataTable;
            plan_dnia_dgv_1.ItemsSource = dt.DefaultView;
            sqlConnection.Close();

        }
        private void czwartek()
        {
            sqlConnection.Open();
            DataTable dataTable = new DataTable();
            sql = "select [Czas_Od],[Czas_Do],[Czynnosc] from Czas where Uzytkownik=@mw_userID and Dzien='Thursday'";
            SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection);
            sqlCommand.Parameters.AddWithValue("@mw_userID", mw_userID);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCommand);

            dataAdapter.Fill(dataTable);
            dt = dataTable;
            plan_dnia_dgv_1.ItemsSource = dt.DefaultView;
            sqlConnection.Close();

        }
        private void piatek()
        {
            sqlConnection.Open();
            DataTable dataTable = new DataTable();
            sql = "select [Czas_Od],[Czas_Do],[Czynnosc] from Czas where Uzytkownik=@mw_userID and Dzien='Friday'";
            SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection);
            sqlCommand.Parameters.AddWithValue("@mw_userID", mw_userID);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCommand);

            dataAdapter.Fill(dataTable);
            dt = dataTable;
            plan_dnia_dgv_1.ItemsSource = dt.DefaultView;
            sqlConnection.Close();

        }
        private void sobota()
        {
            sqlConnection.Open();
            DataTable dataTable = new DataTable();
            sql = "select [Czas_Od],[Czas_Do],[Czynnosc] from Czas where Uzytkownik=@mw_userID and Dzien='Saturday'";
            SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection);
            sqlCommand.Parameters.AddWithValue("@mw_userID", mw_userID);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCommand);

            dataAdapter.Fill(dataTable);
            dt = dataTable;
            plan_dnia_dgv_1.ItemsSource = dt.DefaultView;
            sqlConnection.Close();

        }
        private void niedziela()
        {
            sqlConnection.Open();
            DataTable dataTable = new DataTable();
            sql = "select [Czas_Od],[Czas_Do],[Czynnosc] from Czas where Uzytkownik=@mw_userID and Dzien='Sunday'";
            SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection);
            sqlCommand.Parameters.AddWithValue("@mw_userID", mw_userID);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCommand);

            dataAdapter.Fill(dataTable);
            dt = dataTable;
            plan_dnia_dgv_1.ItemsSource = dt.DefaultView;
            sqlConnection.Close();

        }


        private void plan_dnia3_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string gregi = e.Source.ToString();


            if (plan_dnia3.SelectedIndex==(0))
            {
                poniedzialek();
                help_select_day.Content = "Poniedziałek";
            }
            if (plan_dnia3.SelectedIndex == (1))
            {
                wtorek();
                help_select_day.Content = "Wtorek";
            }
            if (plan_dnia3.SelectedIndex == (2))
            {
                sroda();
                help_select_day.Content = "Środa";
            }
            if (plan_dnia3.SelectedIndex == (3))
            {
                czwartek();
                help_select_day.Content = "Czwartek";
            }
            if (plan_dnia3.SelectedIndex == (4))
            {
                piatek();
                help_select_day.Content = "Piątek";
            }
            if (plan_dnia3.SelectedIndex == (5))
            {
                sobota();
                help_select_day.Content = "Sobota";
            }
            if (plan_dnia3.SelectedIndex == (6))
            {
                niedziela();
                help_select_day.Content = "Niedziela";
            }

        }

        private void user_add_info()
        {
         
            help_dnia_tygodnia = plan_dnia3.SelectedItem.ToString();
            sqlConnection.Open();
            sql = "SELECT MAX(Czas_Do) From Czas where Dzien=@help_dnia_tygodnia";
            SqlCommand sqlCommand1 = new SqlCommand(sql, sqlConnection);
            sqlCommand1.Parameters.AddWithValue("@help_dnia_tygodnia", help_dnia_tygodnia);

            string result=sqlCommand1.ExecuteScalar().ToString();


           

            sql = "INSERT INTO Czas(Czas_Od,Czas_Do,Czynnosc,Uzytkownik,Dzien)"+
                "VALUES (@czas_o,@czas_d,@czyn,@mw_userID,@help_dnia_tygodnia)";
            SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection);
            sqlCommand.Parameters.AddWithValue("@czas_o", plan_dnia.SelectedItem.ToString());
            sqlCommand.Parameters.AddWithValue("@czas_d", plan_dnia2.SelectedItem.ToString());
            sqlCommand.Parameters.AddWithValue("@czyn", text3.Text);
            sqlCommand.Parameters.AddWithValue("@mw_userID", mw_userID);
            sqlCommand.Parameters.AddWithValue("@help_dnia_tygodnia", help_dnia_tygodnia);
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();


        }

   
    }
}
