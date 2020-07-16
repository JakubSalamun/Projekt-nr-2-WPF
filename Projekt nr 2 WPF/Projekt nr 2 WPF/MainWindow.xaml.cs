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
        string mw_userID;

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




        private void add_info()
        {
            sqlConnection.Open();
            DataTable dataTable = new DataTable();
            sql = "select [Czas_Od],[Czas_Do],[Czynnosc] from Czas where Uzytkownik=@mw_userID";
            SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection);
            sqlCommand.Parameters.AddWithValue("@mw_userID", mw_userID);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCommand);
            
            dataAdapter.Fill(dataTable);
            dt = dataTable;
            plan_dnia_dgv.ItemsSource = dt.DefaultView;
            sqlConnection.Close();
        }

        private void user_add_info()
        {
            sqlConnection.Open();
            sql = "INSERT INTO Czas(Czas_Od,Czas_Do,Czynnosc,Uzytkownik)"+
                "VALUES (@czas_o,@czas_d,@czyn,@mw_userID)";
            SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection);
            sqlCommand.Parameters.AddWithValue("@czas_o", text1.Text);
            sqlCommand.Parameters.AddWithValue("@czas_d", text2.Text);
            sqlCommand.Parameters.AddWithValue("@czyn", text3.Text);
            sqlCommand.Parameters.AddWithValue("@mw_userID", mw_userID);
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();


        }
    }
}
