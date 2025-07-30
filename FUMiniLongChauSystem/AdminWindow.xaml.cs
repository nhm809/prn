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
using BLL.Services;
using DAL.Entities;

namespace FUMiniLongChauSystem
{
    /// <summary>
    /// Interaction logic for AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        private UserService _userService;

        public AdminWindow()
        {
            InitializeComponent();
            LoadUsers();
        }

        private async void LoadUsers()
        {
            _userService = new();
            var users = await _userService.GetAllAsync();
            UsersDataGrid.ItemsSource = users;
        }

        private void AddUser_Click(object sender, RoutedEventArgs e)
        {
            var addWindow = new AddAndUpdateWindow();
            if (addWindow.ShowDialog() == true)
            {
                LoadUsers();
            }
        }

        private void EditUser_Click(object sender, RoutedEventArgs e)
        {
            var selectedUser = UsersDataGrid.SelectedItem as User;
            if (selectedUser == null)
            {
                MessageBox.Show("Vui lòng chọn user.", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            if (selectedUser != null)
            {
                var editWindow = new AddAndUpdateWindow(selectedUser);
                if (editWindow.ShowDialog() == true)
                    LoadUsers();
            }
        }

        private async void DeleteUser_Click(object sender, RoutedEventArgs e)
        {
            var selectedUser = UsersDataGrid.SelectedItem as User;
            if (selectedUser == null)
            {
                MessageBox.Show("Vui lòng chọn user.", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            if (selectedUser != null)
            {
                // Lấy user từ DB kèm Orders và Reviews
                var userWithRelations = await _userService.GetWithOrdersAsync(selectedUser.UserId);
                if (userWithRelations != null &&
                    ((userWithRelations.Orders != null && userWithRelations.Orders.Any()) ||
                     (userWithRelations.Reviews != null && userWithRelations.Reviews.Any())))
                {
                    MessageBox.Show("Không thể xóa người dùng này vì đã có đơn hàng hoặc đánh giá liên quan.Vui lòng kiểm tra lại", "Không thể xóa", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                var result = MessageBox.Show($"Bạn có chắc muốn xóa user {selectedUser.FullName}?", "Xác nhận xóa", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    await _userService.DeleteAsync(selectedUser);
                    LoadUsers();
                }
            }
        }

        private void DetailsUser_Click(object sender, RoutedEventArgs e)
        {
            var selectedUser = UsersDataGrid.SelectedItem as User;
            if (selectedUser == null)
            {
                MessageBox.Show("Vui lòng chọn user.", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            if (selectedUser != null)
            {
                var detailWindow = new AddAndUpdateWindow(selectedUser);

                detailWindow.FullNameTextBox.IsReadOnly = true;
                detailWindow.EmailTextBox.IsReadOnly = true;
                detailWindow.PhoneTextBox.IsReadOnly = true;
                detailWindow.RoleComboBox.IsEnabled = false;
                detailWindow.PasswordBox.IsEnabled = false;
                detailWindow.btnSave.IsEnabled = false; 
                detailWindow.btnCancel.IsEnabled = false;
                detailWindow.ShowDialog();
            }
        }

        private void ManageProductButton_Click(object sender, RoutedEventArgs e)
        {
            var productWindow = new ProductManagementWindow();
            productWindow.ShowDialog();
        }

        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show(
                "Bạn có chắc chắn muốn đăng xuất không?",
                "Xác nhận đăng xuất",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                this.Close();
                var loginWindow = new LoginWindow();
                loginWindow.Show();
            }
        }
    }
}
