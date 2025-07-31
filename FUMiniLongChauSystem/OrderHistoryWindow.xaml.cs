using BLL.DTOs;
using BLL.Services;
using DAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace FUMiniLongChauSystem
{
    public partial class OrderHistoryWindow : Window
    {
        private readonly OrderService _orderService = new();
        private int _currentUserId;

        public OrderHistoryWindow(int userId)
        {
            InitializeComponent();
            _currentUserId = userId;
            LoadOrders();
        }

        private async void LoadOrders()
        {
            var allOrders = await _orderService.GetAllAsync();
            var userOrders = allOrders.FindAll(o => o.UserId == _currentUserId);
            OrderListView.ItemsSource = userOrders;
            this.UpdateLayout(); // Đảm bảo layout đã cập nhật chiều cao
            CenterWindowOnScreen(); // Rồi căn lại giữa

        }

        private void ViewDetail_Click(object sender, RoutedEventArgs e)
        {
            if (OrderListView.SelectedItem is Order selectedOrder)
            {
                var detailWindow = new OrderDetailWindow(selectedOrder.OrderId);
                detailWindow.ShowDialog();
            }
        }

        private void CenterWindowOnScreen()
        {
            this.Left = (SystemParameters.WorkArea.Width - this.ActualWidth) / 2 + SystemParameters.WorkArea.Left;
            this.Top = (SystemParameters.WorkArea.Height - this.ActualHeight) / 2 + SystemParameters.WorkArea.Top;
        }

    }
}
