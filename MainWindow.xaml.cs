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

namespace nastradomus_elyrium
{
    public partial class MainWindow : Window
    {
        public int pass_lenght_int;
        public MainWindow()
        {
            InitializeComponent();
        }
        private void pass_lenght_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (pass_lenght.Text != "")
            {
                pass_lenght_int = 0;
                pass_lenght_l.Visibility = Visibility.Hidden;

                try
                {
                    pass_lenght_int = Convert.ToInt32(pass_lenght.Text);
                }
                catch
                {
                    MessageBox.Show("Вводите число!");
                }
            }
            else
            {
                pass_lenght_l.Visibility = Visibility.Visible;
            }
        }
        private void pass_symbols_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (pass_symbols.Text != "")
            {
                pass_symbols_l.Visibility = Visibility.Hidden;
            }
            else
            {
                pass_symbols_l.Visibility = Visibility.Visible;
            }
        }
        private void Continue_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (pass_lenght.Text != "")
                {
                    Random rnd = new Random();
                    string symbols = pass_symbols.Text;
                    string pass_result_s = "";
                    int i = 0;
                    
                    //123467890 -= bmgserQWER

                    while (i < pass_lenght_int)
                    {
                        char pass_symbols_i = pass_symbols.Text[rnd.Next(symbols.Length)];
                        if (!pass_result_s.Equals(pass_symbols_i))
                        {
                            pass_result_s += pass_symbols_i;
                        }
                        else
                        {
                            pass_symbols_i = pass_symbols.Text[rnd.Next(symbols.Length)];
                            pass_result_s += pass_symbols_i;
                        }
                        i++;
                    }
                    pass_result.Text = pass_result_s;
                }               
                else
                {
                    MessageBox.Show("Не указана длина строки!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex);
            }
        }
    }
}