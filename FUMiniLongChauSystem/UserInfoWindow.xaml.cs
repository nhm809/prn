using BLL.Services;
using DAL.Entities;
using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;

namespace FUMiniLongChauSystem
{
    public partial class UserInfoWindow : Window
    {
        private User _user;
        private readonly UserService _userService = new();

        public UserInfoWindow(User user)
        {
            InitializeComponent();
            _user = user;

            txtFullName.Text = _user.FullName;
            txtEmail.Text = _user.Email;
            txtPhone.Text = _user.Phone;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private async void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            string fullName = txtFullName.Text.Trim();
            string phone = txtPhone.Text.Trim();
            string oldPass = OldPasswordBox.Password.Trim();
            string newPass = NewPasswordBox.Password.Trim();
            string confirmPass = ConfirmPasswordBox.Password.Trim();

            // Kiểm tra số điện thoại
            if (!Regex.IsMatch(phone, @"^0\d{9}$"))
            {
                MessageBox.Show("Số điện thoại phải có 10 chữ số và bắt đầu bằng số 0.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            _user.FullName = fullName;
            _user.Phone = phone;

            try
            {
                if (!string.IsNullOrEmpty(oldPass) || !string.IsNullOrEmpty(newPass) || !string.IsNullOrEmpty(confirmPass))
                {
                    if (oldPass != _user.PasswordHash)
                    {
                        MessageBox.Show("Mật khẩu hiện tại không đúng!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Warning);
                        return;
                    }

                    if (!IsStrongPassword(newPass))
                    {
                        MessageBox.Show("Mật khẩu mới phải có ít nhất 8 ký tự, bao gồm chữ hoa và ký tự đặc biệt.", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Warning);
                        return;
                    }

                    if (newPass != confirmPass)
                    {
                        MessageBox.Show("Xác nhận mật khẩu không khớp!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Warning);
                        return;
                    }

                    _user.PasswordHash = newPass;
                }

                await _userService.UpdateAsync(_user);
                MessageBox.Show("Thông tin đã được cập nhật!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi cập nhật: " + ex.Message, "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private bool IsStrongPassword(string password)
        {
            if (password.Length < 8)
                return false;

            bool hasUpper = password.Any(char.IsUpper);
            bool hasSpecial = password.Any(ch => !char.IsLetterOrDigit(ch));

            return hasUpper && hasSpecial;
        }
    }
}
