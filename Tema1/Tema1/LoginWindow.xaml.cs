using Dictionar.Backend;
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

namespace Tema1
{
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void LoginButton_Clicked(object sender, RoutedEventArgs e)
        {
            string userName = usernameField.Text;
            string password = passwordField.Text;
            MainWindow.Authentication.Login(userName, password);
            if(MainWindow.Authentication.isAuthenticated)
            {
                AdminWindow adminWindow = new AdminWindow();
                adminWindow.Show();
            }
        }
    }
}
