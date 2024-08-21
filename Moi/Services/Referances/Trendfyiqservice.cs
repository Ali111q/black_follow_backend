using System.Text;
using GaragesStructure.DATA.DTOs.Convertors;
using GaragesStructure.DATA.DTOs.Convertors.Request;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace GaragesStructure.Services.Referances;

public interface ITrendfyiqService
{
    Task<(List<ServiceResponseConvertor>? data, string? error)> GetService(ServiceRequestConvertor request);
    Task<(AddOrderResponseConvertor? data, string? error)> AddOrder(AddOrderRequestConvertor request);
    Task<(BalanceResponseConvertor? data, string? error)> GetBalance(BalanceRequestConvertor request);
    Task<(OrderStatusResponseConvertor? data, string? error)> GetOrderState(OrderStatusRequestConvertor request);
    Task<(CancelOrderResponse? data, string? error)> CancelOrder(CancelOrderRequestConvertor request);
}

public class TrendfyiqService : ITrendfyiqService
{
    private readonly IConfiguration _configuration;
    private readonly IHttpClientFactory _httpClient;
    private readonly string _baseUrl;
    private readonly string _apiKey;

    public TrendfyiqService(IConfiguration configuration, IHttpClientFactory httpClient)
    {
        _configuration = configuration;
        _baseUrl = _configuration["Providers:trendfyiq:BaseUrl"]!;
        _apiKey = _configuration["Providers:trendfyiq:ApiKey"]!;
        _httpClient = httpClient;
    }

    private async Task<(T? data, string? error)> PostRequestAsync<T>(object request)
    {
        try
        {
            var data = JsonConvert.SerializeObject(request);
            var content = new StringContent(data, Encoding.UTF8, "application/json");
            var client = _httpClient.CreateClient();
            client.BaseAddress = new Uri(_baseUrl);
            var response = await client.PostAsync(string.Empty, content);
            var responseString = await response.Content.ReadAsStringAsync();
            if (responseString.Contains("\"error\""))
            {
                var errorToken = JObject.Parse(responseString);
                string errorMessage = errorToken["error"]?.ToString() ?? "Unknown error occurred";
                return (default, errorMessage);
            }

            var result = JsonConvert.DeserializeObject<T>(responseString);
            return (result, null);
        }
        catch (Exception ex)
        {
            return (default, ex.Message);
        }
    }

    public async Task<(List<ServiceResponseConvertor>? data, string? error)> GetService(ServiceRequestConvertor request)
    {
        request.action = _configuration["Providers:trendfyiq:Actions:GetService"]!;
        request.key = _apiKey;
        return await PostRequestAsync<List<ServiceResponseConvertor>>(request);
    }

    public async Task<(AddOrderResponseConvertor? data, string? error)> AddOrder(AddOrderRequestConvertor request)
    {
        request.action = _configuration["Providers:trendfyiq:Actions:AddOrder"]!;
        request.key = _apiKey;
        return await PostRequestAsync<AddOrderResponseConvertor>(request);
    }

    public async Task<(BalanceResponseConvertor? data, string? error)> GetBalance(BalanceRequestConvertor request)
    {
        request.action = _configuration["Providers:trendfyiq:Actions:GetBalance"]!;
        request.key = _apiKey;
        return await PostRequestAsync<BalanceResponseConvertor>(request);
    }

    public async Task<(OrderStatusResponseConvertor? data, string? error)> GetOrderState(
        OrderStatusRequestConvertor request)
    {
        request.action = _configuration["Providers:trendfyiq:Actions:GetOrderState"]!;
        request.key = _apiKey;
        return await PostRequestAsync<OrderStatusResponseConvertor>(request);
    }

    public async Task<(CancelOrderResponse? data, string? error)> CancelOrder(CancelOrderRequestConvertor request)
    {
        request.action = _configuration["Providers:trendfyiq:Actions:CancelOrder"]!;
        request.key = _apiKey;
        var (cancelOrderResponses, error) = await PostRequestAsync<List<JToken>>(request);
        if (cancelOrderResponses is { Count: > 0 })
            return (CancelOrderResponseConvertor.ConvertCancelOrderResponse(cancelOrderResponses[0]), null);
        return (null, error ?? "No data found");
    }
}