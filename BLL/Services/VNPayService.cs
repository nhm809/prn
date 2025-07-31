using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Diagnostics;

public class VNPayService
{
    private readonly string _vnp_TmnCode = "O5JCB6EV"; // demo
    private readonly string _vnp_HashSecret = "SHMML59GNRD3LSNJ9T90MWMI6VD0HO6Z";
    private readonly string _vnp_Url = "https://sandbox.vnpayment.vn/paymentv2/vpcpay.html";
    private readonly string _vnp_ReturnUrl = "https://example.com/return";

    public string CreatePaymentUrl(int orderId, decimal amount, string description)
    {
        var inputData = new SortedDictionary<string, string>
        {
            { "vnp_Version", "2.1.0" },
            { "vnp_Command", "pay" },
            { "vnp_TmnCode", _vnp_TmnCode },
            { "vnp_Amount", ((int)(amount * 100)).ToString() },
            { "vnp_CreateDate", DateTime.Now.ToString("yyyyMMddHHmmss") },
            { "vnp_CurrCode", "VND" },
            { "vnp_IpAddr", "127.0.0.1" },
            { "vnp_Locale", "vn" },
            { "vnp_OrderInfo", description.Replace("#", "No.") },
            { "vnp_OrderType", "other" },
            { "vnp_ReturnUrl", _vnp_ReturnUrl },
            { "vnp_TxnRef", orderId.ToString() }
        };

        // 1. Tạo raw data string để ký (KHÔNG encode!)
        var rawData = string.Join("&", inputData.Select(x => $"{x.Key}={x.Value}"));

        // 2. Tính SecureHash
        var secureHash = HmacSHA512(_vnp_HashSecret, rawData);

        // 3. Encode dữ liệu để đưa vào URL
        var queryString = string.Join("&", inputData.Select(x =>
            $"{HttpUtility.UrlEncode(x.Key)}={HttpUtility.UrlEncode(x.Value)}"));

        // 4. Gắn hash cuối cùng
        var paymentUrl = $"{_vnp_Url}?{queryString}&vnp_SecureHash={secureHash}";

        System.Diagnostics.Debug.WriteLine("RawData: " + rawData);
        System.Diagnostics.Debug.WriteLine("SecureHash: " + secureHash);
        System.Diagnostics.Debug.WriteLine("PaymentUrl: " + paymentUrl);

        return paymentUrl;
    }

    public string HmacSHA512(string key, string inputData)
    {
        using var hmac = new HMACSHA512(Encoding.UTF8.GetBytes(key));
        return BitConverter.ToString(hmac.ComputeHash(Encoding.UTF8.GetBytes(inputData))).Replace("-", "").ToLower();
    }
}
