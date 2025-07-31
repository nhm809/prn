using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using BLL.DTOs;
using BLL.Services;
using DAL.Data;
using DAL.Entities;
using DAL.Repositories;

namespace FUMiniLongChauSystem
{
    /// <summary>
    /// Interaction logic for ConfirmCheckoutWindow.xaml
    /// </summary>
    public partial class ConfirmCheckoutWindow : Window
    {
        private readonly List<CartItemDto> _cartItems;
        private readonly User _user;

        public ConfirmCheckoutWindow(User user, List<CartItemDto> cartItems)
        {
            InitializeComponent();
            _user = user;
            CustomerNameRun.Text = _user.FullName ?? "(Không có)";
            CustomerPhoneRun.Text = _user.Phone ?? "(Không có)";
            _cartItems = cartItems;

            OrderItemsListView.ItemsSource = _cartItems.Select(i => new
            {
                i.Name,
                i.Quantity,
                i.Price,
                TotalPrice = i.Price * i.Quantity
            });

            decimal total = _cartItems.Sum(i => i.Quantity * i.Price);
            TotalAmountTextBlock.Text = $"{total:N0} đ";
        }

        private async void ConfirmAndPay_Click(object sender, RoutedEventArgs e)
        {
            string address = AddressTextBox.Text.Trim();
            if (string.IsNullOrEmpty(address))
            {
                MessageBox.Show("Vui lòng nhập địa chỉ giao hàng.");
                return;
            }

            try
            {
                using var context = new FuminiLongChauSystemContext();

                decimal total = _cartItems.Sum(i => i.Quantity * i.Price);

                var order = new Order
                {
                    UserId = _user.UserId,
                    OrderDate = DateTime.Now,
                    ShippingAddress = address,
                    Status = "Pending",
                    TotalAmount = total
                };

                context.Orders.Add(order);
                await context.SaveChangesAsync();

                foreach (var item in _cartItems)
                {
                    context.OrderDetails.Add(new OrderDetail
                    {
                        OrderId = order.OrderId,
                        ProductId = item.ProductId,
                        Quantity = item.Quantity,
                        Price = item.Price
                    });
                }

                await context.SaveChangesAsync();

                // Gọi cửa sổ thanh toán VNPay
                // Gọi cửa sổ thanh toán PayPal
                var paymentWindow = new PaymentWindow(order.OrderId, order.TotalAmount);
                paymentWindow.ShowDialog();

                if (paymentWindow.IsPaymentSuccessful)
                {
                    // Xóa giỏ hàng
                    var cartItems = context.CartItems.Where(c => c.UserId == _user.UserId);
                    context.CartItems.RemoveRange(cartItems);
                    await context.SaveChangesAsync();

                    MessageBox.Show("🎉 Đặt hàng và thanh toán thành công!");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("⚠ Thanh toán chưa hoàn tất hoặc bị hủy.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void AddressTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
