using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using BLL.Services;
using DAL.Data;
using DAL.Repositories;
using Microsoft.Web.WebView2.Core;

namespace FUMiniLongChauSystem
{
    /// <summary>
    /// Interaction logic for PaymentWindow.xaml
    /// </summary>
    public partial class PaymentWindow : Window
    {
        private readonly int _orderId;
        private readonly decimal _amount;
        private readonly PaymentService _paymentService;

        public bool IsPaymentSuccessful { get; private set; } = false;

        public PaymentWindow(int orderId, decimal amount)
        {
            InitializeComponent();
            _orderId = orderId;
            _amount = amount;
            _paymentService = new PaymentService();
            Loaded += PaymentWindow_Loaded;
        }

        private async void PaymentWindow_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                await WebView.EnsureCoreWebView2Async();
                string url = await _paymentService.CreatePaymentUrlAsync(_orderId, _amount);
                WebView.Source = new Uri(url);
                WebView.NavigationCompleted += WebView_NavigationCompleted;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khởi tạo thanh toán: " + ex.Message);
                this.Close();
            }
        }

        private async void WebView_NavigationCompleted(object? sender, CoreWebView2NavigationCompletedEventArgs e)
        {
            var uri = WebView.Source;

            if (uri != null && uri.AbsoluteUri.Contains("paypal_return"))
            {
                try
                {
                    using var context = new FuminiLongChauSystemContext();

                    // Cập nhật trạng thái đơn hàng
                    var order = await context.Orders.FindAsync(_orderId);
                    if (order != null)
                    {
                        order.Status = "Paid";

                        // Ghi nhận thông tin thanh toán
                        context.Payments.Add(new DAL.Entities.Payment
                        {
                            OrderId = _orderId,
                            PaymentDate = DateTime.Now,
                            PaymentType = "PayPal",
                            PaymentStatus = "Paid"
                        });

                        await context.SaveChangesAsync();
                    }

                    IsPaymentSuccessful = true;
                    MessageBox.Show("✅ Thanh toán thành công!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi cập nhật trạng thái thanh toán: " + ex.Message);
                }

                this.Close();
            }
            else if (uri != null && uri.AbsoluteUri.Contains("paypal_cancel"))
            {
                MessageBox.Show("❌ Đã hủy thanh toán.");
                this.Close();
            }
        }
    }
}
