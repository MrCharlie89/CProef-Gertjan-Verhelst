
using Syntra.VDOAP.CProef.Ecommerce.LIB.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace Syntra.VDOAP.CProef.Ecommerce2
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public bool ShowPassword { get; set; }

        public LoginWindow()
        {
            InitializeComponent();

            ShowPassword = false;
            ToggleShowPassword();
        }

        private void ToggleShowPassword()
        {
            txtPassword.Visibility = btnShowPassword.Visibility = !ShowPassword ? Visibility.Visible : Visibility.Collapsed;
            txtPasswordPlain.Visibility = btnHidePassword.Visibility = ShowPassword ? Visibility.Visible : Visibility.Collapsed;
        }

        private void txtUserName_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                txtPassword.Focus();
        }

        private void txtPassword_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                PerformAuthentication();
        }

        private void txtPasswordPlain_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                PerformAuthentication();
        }

        private void txtPasswordPlain_TextChanged(object sender, TextChangedEventArgs e)
        {
            txtPassword.Password = txtPasswordPlain.Text;
        }

        private void txtPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            txtPasswordPlain.Text = txtPassword.Password;
            txtPassword.SetCursorOnEnd();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            PerformAuthentication();
        }

        private void PerformAuthentication()
        {
            errPassword.Content = errUserName.Content = errCredentials.Content = string.Empty;

            string _username = txtUserName.Text.ToLower(), _password = txtPassword.Password;
            bool correctCredentials = false;

            if (_username == "admin" && _password == "admin")
                correctCredentials = true;

            if (correctCredentials)
            {
                new MainWindow().Show();
                this.Close();
            }

            if (string.IsNullOrWhiteSpace(txtPassword.Password))
            {
                correctCredentials = false;
                errPassword.Content = "Please give your password";
            }
            if (string.IsNullOrWhiteSpace(txtUserName.Text))
            {
                correctCredentials = false;
                errUserName.Content = "please give your username";
            }
            if (_username != "admin" && !string.IsNullOrWhiteSpace(_username))
            {
                errUserName.Content = "the username can not be found";
            }
            if (!string.IsNullOrWhiteSpace(_username) && _password != "admin" && !string.IsNullOrWhiteSpace(_password))
            {
                errCredentials.Content = "Please check the username and password";
            }


            ShowPassword = false;
            ToggleShowPassword();

            txtUserName.Focus();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            //if (MessageBox.Show("Do you want to close the application?", "Close application", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                this.Close();
        }

       

        private void btnShowPassword_Click(object sender, RoutedEventArgs e)
        {
            ShowPassword = true;
            ToggleShowPassword();
        }

        private void btnHidePassword_Click(object sender, RoutedEventArgs e)
        {
            ShowPassword = false;
            ToggleShowPassword();
        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {

        }
    }
}
