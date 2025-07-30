using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using DAL.Entities;
using BLL.Services;
using System.Text.RegularExpressions;

namespace FUMiniLongChauSystem
{
    /// <summary>
    /// Interaction logic for AddAndUpdateWindow.xaml
    /// </summary>
    public partial class AddAndUpdateWindow : Window
    {
        private readonly UserService _userService = new();
        private User? _editingUser;

        public AddAndUpdateWindow(User? user = null)
        {
            InitializeComponent();
            _editingUser = user;

            if (user == null)
            {
                // Add mode
                UserIdTextBox.Text = "Auto generated";
                PasswordBox.IsEnabled = true;
                RoleComboBox.SelectedIndex = 1; // Default to Customer
                PasswordLabel.Visibility = Visibility.Visible;
                PasswordBox.Visibility = Visibility.Visible;
            }
            else
            {
                // Update mode
                PasswordBox.IsEnabled = false;
                UserIdTextBox.Text = user.UserId.ToString();
                FullNameTextBox.Text = user.FullName;
                EmailTextBox.Text = user.Email;
                PhoneTextBox.Text = user.Phone;
                RoleComboBox.SelectedItem = RoleComboBox.Items
                    .Cast<ComboBoxItem>()
                    .FirstOrDefault(i => i.Content.ToString() == user.Role);

                // Hide password field in update mode
                PasswordLabel.Visibility = Visibility.Collapsed;
                PasswordBox.Visibility = Visibility.Collapsed;
            }
        }

        private async void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            string fullName = FullNameTextBox.Text.Trim();
            string email = EmailTextBox.Text.Trim();
            string phone = PhoneTextBox.Text.Trim();
            string role = (RoleComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();
            string password = PasswordBox.Password.Trim();

            if (string.IsNullOrWhiteSpace(fullName))
            {
                MessageBox.Show("Full Name is required.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            var words = fullName.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            foreach (var word in words)
            {
                foreach (char c in word)
                {
                    if (!char.IsLetter(c))
                    {
                        MessageBox.Show("Full Name must not contain numbers or special characters.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                        return;
                    }
                }
            }

            if (string.IsNullOrWhiteSpace(email))
            {
                MessageBox.Show("Email is required.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if (!Regex.IsMatch(email, @"^[A-Za-z0-9._%+-]+@gmail\.com$"))
            {
                MessageBox.Show("Email must be in the format ...@gmail.com", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if (!Regex.IsMatch(phone, @"^0\d{9}$"))
            {
                MessageBox.Show("Phone must start with 0 and have exactly 10 digits.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            var existingUser = await _userService.FindByEmailAsync(email);
            if (existingUser != null)
            {
                MessageBox.Show("Email already exists.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if (_editingUser == null)
            {
                if (string.IsNullOrWhiteSpace(password))
                {
                    MessageBox.Show("Password is required.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                var newUser = new User
                {
                    FullName = fullName,
                    Email = email,
                    Phone = phone,
                    Role = role,
                    PasswordHash = password  
                };
                await _userService.AddAsync(newUser);
            }
            else
            {
                _editingUser.FullName = fullName;
                _editingUser.Email = email;
                _editingUser.Phone = phone;
                _editingUser.Role = role;

                await _userService.UpdateAsync(_editingUser);
            }

            DialogResult = true;
            Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
