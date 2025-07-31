using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class PayPalService
    {
        private readonly string _clientId = "AcUHawbN0POlNQzLipFEFAUXYOFx08Uwuv806TPHvvo5eNdbMiGwIkP1_Xv8uVxHk7f8hlMk22qIg_t4";
        private readonly string _secret = "EDfR9Qdx1DEwn0oXxl0GM76l-xKy5vRKDiEBdhqDreXsgpmVbSf2sfo4u1rUcAZTZAdmkGgURB4e2yus";
        private readonly string _baseUrl = "https://api-m.sandbox.paypal.com";
        private readonly HttpClient _http;

        public PayPalService()
        {
            _http = new HttpClient();
            _http.BaseAddress = new Uri(_baseUrl);
        }

        private async Task<string> GetAccessTokenAsync()
        {
            var authToken = Convert.ToBase64String(Encoding.UTF8.GetBytes($"{_clientId}:{_secret}"));

            using var request = new HttpRequestMessage(HttpMethod.Post, "/v1/oauth2/token");
            request.Headers.Authorization = new AuthenticationHeaderValue("Basic", authToken);
            request.Content = new StringContent("grant_type=client_credentials", Encoding.UTF8, "application/x-www-form-urlencoded");

            var response = await _http.SendAsync(request);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var json = JsonSerializer.Deserialize<JsonElement>(content);
            return json.GetProperty("access_token").GetString();
        }

        public async Task<string?> CreatePaymentUrlAsync(decimal amount, string returnUrl)
        {
            var token = await GetAccessTokenAsync();

            var payload = new
            {
                intent = "CAPTURE",
                purchase_units = new[]
                {
                new {
                    amount = new {
                        currency_code = "USD",
                        value = amount.ToString("F2", CultureInfo.InvariantCulture)
                    }
                }
            },
                application_context = new
                {
                    return_url = returnUrl,
                    cancel_url = returnUrl
                }
            };

            var json = JsonSerializer.Serialize(payload);
            using var request = new HttpRequestMessage(HttpMethod.Post, "/v2/checkout/orders");
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            request.Content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _http.SendAsync(request);
            response.EnsureSuccessStatusCode();

            var responseJson = JsonSerializer.Deserialize<JsonElement>(await response.Content.ReadAsStringAsync());

            return responseJson
                .GetProperty("links")
                .EnumerateArray()
                .First(link => link.GetProperty("rel").GetString() == "approve")
                .GetProperty("href").GetString();
        }

        public async Task<bool> CapturePaymentAsync(string orderId)
        {
            var token = await GetAccessTokenAsync();

            using var request = new HttpRequestMessage(HttpMethod.Post, $"/v2/checkout/orders/{orderId}/capture");
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            request.Content = new StringContent("{}", Encoding.UTF8, "application/json");

            var response = await _http.SendAsync(request);
            return response.IsSuccessStatusCode;
        }
    }
}
