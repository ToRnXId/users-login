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
using System.Windows.Shapes;

namespace users_login
{
    /// <summary>
    /// Interaction logic for AuthWindow.xaml
    /// </summary>
    public partial class AuthWindow : Window
    {
        public AuthWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int counter = 0;
            string login = tbLogin.Text.Trim();
            string password = pbPassword.Password.Trim();


            tbLogin.ToolTip = null;
            tbLogin.Background = Brushes.Transparent;
            pbPassword.ToolTip = null;
            pbPassword.Background = Brushes.Transparent;

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

            if (counter == 0)
            {
                
                User authUser = null;
                using (ApplicationContext db =  new ApplicationContext())
                {
                    authUser = db.Users.Where(b => b.Login == login && b.Password == password).FirstOrDefault();
                }

                if (authUser != null)
                {
                    AccountWindow accountWindow = new AccountWindow();
                    accountWindow.Show();
                    this.Close();
                }
                else
                    MessageBox.Show("Error");
            }
        }

        private void Button_SignUp_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
