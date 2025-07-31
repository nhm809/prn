using System.Web;
using DAL.Entities;
using DAL.Repositories;

namespace BLL.Services;

public class PaymentService
{
    private readonly PaymentRepository _paymentRepo;
    private readonly OrderRepository _orderRepo;
    private readonly PayPalService _paypalService;

    public PaymentService()
    {
        _paymentRepo = new PaymentRepository();
        _orderRepo = new OrderRepository();
        _paypalService = new PayPalService();
    }

    public async Task<string> CreatePaymentUrlAsync(int orderId, decimal amount)
    {
        await _paymentRepo.CreatePendingPaymentAsync(orderId);

        // Tạo đường dẫn thanh toán PayPal
        string returnUrl = "https://example.com/paypal_return";
        string cancelUrl = "https://example.com/paypal_cancel";
        string? paypalUrl = await _paypalService.CreatePaymentUrlAsync(amount, returnUrl);

        if (paypalUrl == null)
            throw new Exception("Không thể tạo liên kết thanh toán PayPal.");

        return paypalUrl;
    }

    public async Task<bool> ProcessReturnUrlAsync(Uri uri)
    {
        var query = HttpUtility.ParseQueryString(uri.Query);
        string? token = query["token"];
        string? orderIdStr = query["orderId"];

        if (string.IsNullOrEmpty(token) || string.IsNullOrEmpty(orderIdStr))
            return false;

        if (!int.TryParse(orderIdStr, out int orderId))
            return false;

        bool result = await _paypalService.CapturePaymentAsync(token);

        if (result)
        {
            await _paymentRepo.UpdatePaymentStatusAsync(orderId, "Paid");
            await _orderRepo.UpdateOrderStatusAsync(orderId, "Completed");
        }
        else
        {
            await _paymentRepo.UpdatePaymentStatusAsync(orderId, "Failed");
        }

        return result;
    }

}
