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

        private void backLoginWindow_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();
            this.Hide();
        }
    }
}
