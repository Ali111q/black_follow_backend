namespace GaragesStructure.DATA.DTOs.Convertors.Request;

public class AddOrderRequestConvertor : BaseRequestConvertor
{
    public int service { get; set; }
    public string link { get; set; }
    public int quantity { get; set; }
    public int? runs { get; set; }
    public int? interval { get; set; }
}
