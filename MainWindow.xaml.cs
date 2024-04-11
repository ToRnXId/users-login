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
using System.Windows.Media.Animation;

namespace users_login
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ApplicationContext db;

        public MainWindow()
        {
            InitializeComponent();

            db = new ApplicationContext();

            DoubleAnimation btnAnimation = new DoubleAnimation();
            btnAnimation.From = 0;
            btnAnimation.To = 300;
            btnAnimation.Duration = TimeSpan.FromSeconds(2);
            btnSubmit.BeginAnimation(Button.WidthProperty, btnAnimation);
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
                User user = new User(login, email, password);
                db.Users.Add(user);
                db.SaveChanges();

                AccountWindow accountWindow = new AccountWindow();
                accountWindow.Show();
                this.Close();
            }
        }

        private void Button_SignIn_Click(object sender, RoutedEventArgs e)
        {
            AuthWindow authWindow = new AuthWindow();
            authWindow.Show();
            this.Close();
        }
    }
}
