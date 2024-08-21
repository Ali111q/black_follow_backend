using Newtonsoft.Json.Linq;

namespace GaragesStructure.DATA.DTOs.Convertors;

public  class CancelOrderResponseConvertor
{
    public  static CancelOrderResponse ConvertCancelOrderResponse(JToken jsonResponse)
    {
        var cancelOrderResponse = new CancelOrderResponse
        {
            Order = (int)jsonResponse["order"] 
        };
        var cancelToken = jsonResponse["cancel"];
        if (cancelToken == null) return cancelOrderResponse;
        
        if (cancelToken["error"] != null) cancelOrderResponse.Error = cancelToken["error"]?.ToString();
        else cancelOrderResponse.Cancel = (int?)cancelToken;
        return cancelOrderResponse;
    }
}

public class CancelOrderResponse
{
    public int Order { get; set; } // Always present in both success and error cases
    public int? Cancel { get; set; } // Will be null in case of an error
    public string Error { get; set; } // Will be null in case of success
}