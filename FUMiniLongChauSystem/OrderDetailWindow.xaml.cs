using BLL.Services;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace FUMiniLongChauSystem
{
    public partial class OrderDetailWindow : Window
    {
        private readonly OrderService _orderService = new();

        public OrderDetailWindow(int orderId)
        {
            InitializeComponent();
            LoadOrderDetails(orderId);
        }

        private async void LoadOrderDetails(int orderId)
        {
            var order = await _orderService.GetByIdAsync(orderId);
            if (order != null && order.OrderDetails != null)
            {
                var details = order.OrderDetails.Select(d => new
                {
                    d.ProductId,
                    d.Quantity,
                    d.Price,
                    TotalPrice = d.Quantity * d.Price
                }).ToList();

                OrderDetailListView.ItemsSource = details;
            }
            else
            {
                MessageBox.Show("Không tìm thấy chi tiết đơn hàng.");
                Close();
            }
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
