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
        string sql,sql_a;
        string mw_userID,help_dnia_tygodnia;

        DataTable dt = new DataTable("Info");

        private void Add_Button_Click(object sender, RoutedEventArgs e)
        {
            if (plan_dnia.SelectedIndex.Equals(-1)||plan_dnia2.SelectedIndex.Equals(-1)||plan_dnia3.SelectedIndex.Equals(-1)||text3.Text=="")
            {
                MessageBox.Show("Prosze podać godzine oraz dzień + wypełnić pole czynności");
            }
            if (plan_dnia2.SelectedIndex<plan_dnia.SelectedIndex)
            {
                MessageBox.Show("Chyba coś źle zaznaczyłeś,spróbuj ponownie");
            }
            else
            {
                    user_add_info();
                    add_info();
                    help_data_grid();
            }
        }

        public MainWindow()
        {
            InitializeComponent();
            mw_userID = Help.user_help;
            plan_dnia3.SelectedItem = help_dnia_tygodnia;
            DateTime dt = DateTime.Now;
            help_dnia_tygodnia = dt.DayOfWeek.ToString();
            help_select_day_2.Content = dt.DayOfWeek.ToString();

            combobox();
            combobox2();
            combobox3();
            add_info();
        }
    
        private void combobox()
        {

            for (int i = 0; i < 24; i++)
            {
                for (int j = 0; j < 60; j++)
                {
                    if (j < 10)
                    {
                        plan_dnia.Items.Add(i + ":0" + j);
                    }
                    else
                    {
                        plan_dnia.Items.Add(i + ":" + j);
                        if (j == 60)
                        {
                            j = 0;

                            plan_dnia.Items.Add(i + ":" + j);
                        }
                    }
                

                }
            }
  
           
        }
        private void combobox2()
        {
            for (int i = 0; i < 24; i++)
            {
                for (int j = 0; j < 60; j++)
                {
                    if (j < 10)
                    {
                        plan_dnia2.Items.Add(i + ":0" + j);
                    }
                    else
                    {
                        plan_dnia2.Items.Add(i + ":" + j);
                        if (j == 60)
                        {
                            j = 0;

                            plan_dnia2.Items.Add(i + ":" + j);
                        }
                    }


                }
            }

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
            sql = "select [idPoryDnia],[Czas_Od],[Czas_Do],[Czynnosc] from Czas where Uzytkownik=@mw_userID and Dzien=@help_dnia_tygodnia Order by Czas_Od";
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
            sql = "select [idPoryDnia],[Czas_Od],[Czas_Do],[Czynnosc] from Czas where Uzytkownik=@mw_userID and Dzien='Monday'";
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
            sql = "select [idPoryDnia],[Czas_Od],[Czas_Do],[Czynnosc] from Czas where Uzytkownik=@mw_userID and Dzien='Tuesday'";
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
            sql = "select [idPoryDnia],[Czas_Od],[Czas_Do],[Czynnosc] from Czas where Uzytkownik=@mw_userID and Dzien='Wednesday'";
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
            sql = "select [idPoryDnia],[Czas_Od],[Czas_Do],[Czynnosc] from Czas where Uzytkownik=@mw_userID and Dzien='Thursday'";
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
            sql = "select [idPoryDnia],[Czas_Od],[Czas_Do],[Czynnosc] from Czas where Uzytkownik=@mw_userID and Dzien='Friday'";
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
            sql = "select [idPoryDnia],[Czas_Od],[Czas_Do],[Czynnosc] from Czas where Uzytkownik=@mw_userID and Dzien='Saturday'";
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
            sql = "select [idPoryDnia],[Czas_Od],[Czas_Do],[Czynnosc] from Czas where Uzytkownik=@mw_userID and Dzien='Sunday'";
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
            help_data_grid();
        }

        private void Delete_click(object sender, RoutedEventArgs e)
        {
      
               string delete_help;
               
                List<DataGridCellInfo> cell_infos = new List<DataGridCellInfo>();
                for (int i = 0; i < plan_dnia_dgv.SelectedCells.Count; i++)
                {
                    cell_infos.Add(plan_dnia_dgv.SelectedCells[i]);
                }

                if (plan_dnia_dgv.SelectedCells.Count > 0)
                {
                    delete_help = (cell_infos[0].Column.GetCellContent(cell_infos[0].Item) as TextBlock).Text;
                    sqlConnection.Open();
                    sql = "DELETE from Czas where idPoryDnia=@help_delete";
                    SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection);
                    sqlCommand.Parameters.AddWithValue("@help_delete", Convert.ToInt32(delete_help));
                    sqlCommand.ExecuteNonQuery();
                    sqlConnection.Close();
                    add_info();
                     help_data_grid();

                }

                  List<DataGridCellInfo> cell_infos_2 = new List<DataGridCellInfo>();
                  for (int i = 0; i < plan_dnia_dgv_1.SelectedCells.Count; i++)
                  {
                      cell_infos_2.Add(plan_dnia_dgv_1.SelectedCells[i]);

                  }

                  if (plan_dnia_dgv_1.SelectedCells.Count > 0)
                  {
                     delete_help = (cell_infos_2[0].Column.GetCellContent(cell_infos_2[0].Item) as TextBlock).Text;
                     sqlConnection.Open();
                     sql = "DELETE from Czas where idPoryDnia=@help_delete";
                     SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection);
                     sqlCommand.Parameters.AddWithValue("@help_delete", Convert.ToInt32(delete_help));
                     sqlCommand.ExecuteNonQuery();
                     sqlConnection.Close();
                     add_info();
                    help_data_grid();
                  }


        }


        private void user_add_info()
        {
            sqlConnection.Open();
            sql_a = "SELECT Count(*) From Czas where Dzien=@dzien and ((Czas_Od between @help_czas_od and @help_czas_do) or (Czas_Do between @help_czas_od and @help_czas_do))";
            SqlCommand sqlCommand1 = new SqlCommand(sql_a, sqlConnection);
            sqlCommand1.Parameters.AddWithValue("@help_czas_od", plan_dnia.SelectedItem.ToString());
            sqlCommand1.Parameters.AddWithValue("@help_czas_do", plan_dnia2.SelectedItem.ToString());
            sqlCommand1.Parameters.AddWithValue("@dzien", plan_dnia3.SelectedItem.ToString());
            
            int exist_help = (int)sqlCommand1.ExecuteScalar();
            
            if (exist_help>0)
            {
                MessageBox.Show("Masz juz coś zaplanowane o tej godzinie!");
            }
            
            else
            {
                sql = "INSERT INTO Czas(Czas_Od,Czas_Do,Czynnosc,Uzytkownik,Dzien)" +
               "VALUES (@czas_o,@czas_d,@czyn,@mw_userID,@dzien)";
                SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@czas_o", plan_dnia.SelectedItem.ToString());
                sqlCommand.Parameters.AddWithValue("@czas_d", plan_dnia2.SelectedItem.ToString());
                sqlCommand.Parameters.AddWithValue("@czyn", text3.Text);
                sqlCommand.Parameters.AddWithValue("@mw_userID", mw_userID);
                sqlCommand.Parameters.AddWithValue("@dzien", plan_dnia3.SelectedItem.ToString());
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
            }

            sqlConnection.Close();
        }


        private void help_data_grid()
        {
            if (plan_dnia3.SelectedIndex == (0))
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

    }
}
