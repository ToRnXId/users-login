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

namespace users_login
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int counter = 0;
            string login = tbLogin.Text.Trim();
            string password = pbPassword.Password.Trim();
            string passwordConfirm = pbConfirmPassword.Password.Trim();
            string email = tbEmail.Text.Trim().ToLower();

            tbLogin.ToolTip = null;
            tbLogin.Background = Brushes.Transparent;
            pbPassword.ToolTip = null;
            pbPassword.Background = Brushes.Transparent;
            pbConfirmPassword.ToolTip = null;
            pbConfirmPassword.Background = Brushes.Transparent;
            tbEmail.ToolTip = null;
            tbEmail.Background = Brushes.Transparent;

            if (login.Length < 5)
            {
                tbLogin.ToolTip = "Login incorect";
                tbLogin.Background = Brushes.IndianRed;
                counter++;
            } 
            if (password.Length < 8) 
            {
                pbPassword.ToolTip = "Password incorrect";
                pbPassword.Background = Brushes.IndianRed;
                counter++;
            } 
            if (passwordConfirm != password)
            {
                pbConfirmPassword.ToolTip = "Password is not the same";
                pbConfirmPassword.Background = Brushes.IndianRed;
                counter++;
            } 
            if (email.Length < 8 || !email.Contains('@') || !email.Contains('.'))
            {
                tbEmail.ToolTip = "Email incorrect";
                tbEmail.Background = Brushes.IndianRed;
                counter++;
            }

            if (counter == 0)
            {
                MessageBox.Show("Done");
            }
        }
    }
}
