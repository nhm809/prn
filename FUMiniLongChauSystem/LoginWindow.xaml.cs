using BLL.Services;
using DAL.Entities;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace FUMiniLongChauSystem
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private readonly UserService _userService;

        public LoginWindow()
        {
            InitializeComponent();
            _userService = new UserService();
        }

        private async void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string email = EmailTextBox.Text.Trim();
            string password = PasswordBox.Password.Trim();

            var (adminEmail, adminPassword) = GetAdminCredentials();
            if (email == adminEmail && password == adminPassword)
            {
                AdminWindow adminWindow = new AdminWindow();
                adminWindow.Show();
                this.Hide();
                return;
            }
            var users = await _userService.GetAllAsync();
            var user = users.FirstOrDefault(u => u.Email == email && u.PasswordHash == password);

            if (user != null)
            {
                CustomerHomeWindow customerHomeWindow = new CustomerHomeWindow(user);
                customerHomeWindow.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid email or password.", "Login Failed", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private async void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            var registerWindow = new RegisterWindow();  
            registerWindow.Show();
            this.Close();
        }

        private (string Email, string Password) GetAdminCredentials()
        {
            var exePath = AppDomain.CurrentDomain.BaseDirectory;
            var builder = new ConfigurationBuilder()
                .SetBasePath(exePath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            IConfiguration config = builder.Build();
            var email = config["DefaultAdminAccount:Email"];
            var password = config["DefaultAdminAccount:Password"];
            return (email, password);
        }
    }
}
