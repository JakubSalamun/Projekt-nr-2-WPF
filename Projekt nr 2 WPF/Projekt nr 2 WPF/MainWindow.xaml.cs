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

namespace Projekt_nr_2_WPF
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        float t1, t2, t3, t4, t5, t6, t7, t8, t9;

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
           


        }

        public MainWindow()
        {
            InitializeComponent();
            combobox();
            combobox2();


        }
    
        private void combobox()
        {
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
        }
        private void combobox2()
        {
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
        }
    }
}
