using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace Projekt_nr_2_WPF
{
    /// <summary>
    /// Logika interakcji dla klasy RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        SqlConnection sqlConnection = new SqlConnection(@"Data Source=DESKTOP-MPTGS57\SQLEXPRESS;Initial Catalog=NowyDzien;Integrated Security=True;
                        Connect Timeout=30;Encrypt=False;
                        TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        string sql;
        public static int index_ID;
        public static string user_ID_find;


        private void id_generation()
        {
            sqlConnection.Open();
            sql = "SELECT MAX ([idUser]) FROM [dbo].[Users]";
            SqlCommand sqlCmd = new SqlCommand(sql, sqlConnection);
            user_ID_find = sqlCmd.ExecuteScalar().ToString();
            index_ID = Int32.Parse(user_ID_find);
            index_ID++;
            user_ID.Text = RegisterWindow.index_ID.ToString();
            sqlConnection.Close();
        }

        public RegisterWindow()
        {



            InitializeComponent();
            id_generation();
           




        }

        private bool check_password()
        {
            if (reg_password.Password!=reg_re_password.Password)
            {
                return false;
            }
            return true;
        }
        private bool check_login()
        {
            if (reg_login.Text.Length>0)
            {
                sqlConnection.Open();
                sql = "SELECT COUNT(*) FROM [dbo].[Users] WHERE [Imie]=@login";
                SqlCommand sqlCmd = new SqlCommand(sql, sqlConnection);
                sqlCmd.Parameters.AddWithValue("@login", reg_login.Text);
                int resoult = (int)sqlCmd.ExecuteScalar();
                
                if (resoult>0)
                {
                    MessageBox.Show("Prosze zmienić login.Podany login jest zajęty", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                    return false;
                }
                sqlConnection.Close();
                return true;
                

            }
            return false;
        }
        private void Insert_new()
        {
            sqlConnection.Open();
            sql = "insert into NowyDzien.dbo.Users([idUser],[Imie],[Nazwisko],[uPassword])" +
                "values(@id,@login,@last_name,@password)";
            SqlCommand sqlCmd = new SqlCommand(sql, sqlConnection);
            sqlCmd.Parameters.AddWithValue("@id",user_ID.Text);
            sqlCmd.Parameters.AddWithValue("@login", reg_login.Text);
            sqlCmd.Parameters.AddWithValue("@password", reg_password.Password);
            sqlCmd.Parameters.AddWithValue("@last_name", reg_last_name.Text);
            sqlCmd.ExecuteNonQuery();
            MessageBox.Show("Witamy "+reg_login.Text+"!");
            sqlConnection.Close();
        }



        private void backLoginWindow_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();
            this.Hide();
        }

        private void register_button_Click(object sender, RoutedEventArgs e)
        {
            if (check_login()==true && check_password()==true)
            {
                Insert_new();
                this.Hide();
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
            }
        }
    }
}
