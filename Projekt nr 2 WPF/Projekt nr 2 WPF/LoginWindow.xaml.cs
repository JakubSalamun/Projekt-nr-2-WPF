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
using System.Windows.Shapes;

namespace Projekt_nr_2_WPF
{
    /// <summary>
    /// Logika interakcji dla klasy LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        SqlConnection sqlConnection = new SqlConnection(@"Data Source=DESKTOP-MPTGS57\SQLEXPRESS;Initial Catalog=NowyDzien;Integrated Security=True;
                        Connect Timeout=30;Encrypt=False;
                        TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        string sql;
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void loginButton_Click(object sender, RoutedEventArgs e)
        {
            
            if (userID.Text.Length<1||userPassword.Password.Length<1)
            {
                MessageBox.Show("Prosze podać dane logowania");
            }
            else
            {
                try
                {
                    if (sqlConnection.State==ConnectionState.Closed)
                    {
                        sqlConnection.Open();
                        sql = "Select count(*) from Users where idUser=@userID and uPassword=@userPassword";
                        SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection);
                        sqlCommand.CommandType = CommandType.Text;
                        sqlCommand.Parameters.AddWithValue("@userID", userID.Text);
                        sqlCommand.Parameters.AddWithValue("@userPassword", userPassword.Password);
                        int results = (int)sqlCommand.ExecuteScalar();
                        if (results > 0)
                        {
                            MainWindow mainWindow = new MainWindow();
                            mainWindow.Show();
                            this.Hide();
                            if (better.IsChecked == true)
                            {
                                MessageBox.Show("Oby tak dalej");
                            }
                            if (bad.IsChecked == true)
                            {
                                MessageBox.Show("Dziś będzie lepiej");
                            }
                            if (ok.IsChecked == true)
                            {
                                MessageBox.Show("Witamy ^.^ ");
                            }


                        }
                        else
                        {
                            MessageBox.Show("Nieprawidłowe dane logowania!");
                            userID.Text = "";
                            
                        }
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);

                }

                finally
                {
                    sqlConnection.Close();
                }



            }
        }

        private void regiButton_Click(object sender, RoutedEventArgs e)
        {
            RegisterWindow registerWindow = new RegisterWindow();
            registerWindow.Show();
            this.Hide();
        }
    }
}
