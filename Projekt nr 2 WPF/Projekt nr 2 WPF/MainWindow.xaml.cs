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
        string sql;
        string mw_userID,help_dnia_tygodnia;

        DataTable dt = new DataTable("Info");

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int selectedIndex = plan_dnia.SelectedIndex;
            object selectedItem = plan_dnia.SelectedItem;
            int selectedIndex2 = plan_dnia2.SelectedIndex;
            object selectedItem2 = plan_dnia2.SelectedItem;

            if (selectedIndex>selectedIndex2||(selectedIndex==(-1) ||selectedIndex2==(-1)))
            {
                MessageBox.Show("Coś nie tak zaznaczyłeś");

            }
            else
            {
                text1.Text = selectedItem.ToString();
                text2.Text = selectedItem2.ToString();
            }
            user_add_info();
            add_info();


        }

        public MainWindow()
        {
            InitializeComponent();
            mw_userID = Help.user_help;
            combobox();
            combobox2();
            //combobox3();
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
            plan_dnia.Items.Add("22:00:00");
            plan_dnia.Items.Add("22:30:00");
            plan_dnia.Items.Add("23:00:00");
            plan_dnia.Items.Add("23:30:00");
            plan_dnia.Items.Add("24:00:00");
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
            plan_dnia2.Items.Add("22:00:00");
            plan_dnia2.Items.Add("22:30:00");
            plan_dnia2.Items.Add("23:00:00");
            plan_dnia2.Items.Add("23:30:00");
            plan_dnia2.Items.Add("24:00:00");
        }

        /*private void combobox3()
        {
            plan_dnia3.Items.Add("Poniedzialek");
            plan_dnia3.Items.Add("Wtorek");
            plan_dnia3.Items.Add("Sroda");
            plan_dnia3.Items.Add("Czwartek");
            plan_dnia3.Items.Add("Piatek");
            plan_dnia3.Items.Add("Sobota");
            plan_dnia3.Items.Add("Niedziela");
        }*/



        private void add_info()
        {
            DateTime date_t = DateTime.Now;
            help_dnia_tygodnia = date_t.DayOfWeek.ToString();
            sqlConnection.Open();
            DataTable dataTable = new DataTable();
            sql = "select [Czas_Od],[Czas_Do],[Czynnosc] from Czas where Uzytkownik=@mw_userID and Dzien=@help_dnia_tygodnia";
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

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            
            poniedzialek();

        }

        private void b_wtorek_Click(object sender, RoutedEventArgs e)
        {
            wtorek();

        }

        private void b_sroda_Click(object sender, RoutedEventArgs e)
        {
            sroda();
        }

        private void b_czwartek_Click(object sender, RoutedEventArgs e)
        {
            czwartek();
        }

        private void b_piatek_Click(object sender, RoutedEventArgs e)
        {
            piatek();
        }

        private void b_sobota_Click(object sender, RoutedEventArgs e)
        {
            sobota();
        }

        private void b_niedziela_Click(object sender, RoutedEventArgs e)
        {
            niedziela();
        }

        private void user_add_info()
        {
            DateTime dt = DateTime.Now;
            help_dnia_tygodnia =dt.DayOfWeek.ToString();
            sqlConnection.Open();
            sql = "INSERT INTO Czas(Czas_Od,Czas_Do,Czynnosc,Uzytkownik,Dzien)"+
                "VALUES (@czas_o,@czas_d,@czyn,@mw_userID,@help_dnia_tygodnia)";
            SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection);
            sqlCommand.Parameters.AddWithValue("@czas_o", text1.Text);
            sqlCommand.Parameters.AddWithValue("@czas_d", text2.Text);
            sqlCommand.Parameters.AddWithValue("@czyn", text3.Text);
            sqlCommand.Parameters.AddWithValue("@mw_userID", mw_userID);
            sqlCommand.Parameters.AddWithValue("@help_dnia_tygodnia", help_dnia_tygodnia);
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();


        }

   
    }
}
