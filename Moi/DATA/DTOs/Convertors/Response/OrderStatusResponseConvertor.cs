namespace GaragesStructure.DATA.DTOs.Convertors;

public class OrderStatusResponseConvertor
{
    public decimal Charge { get; set; }
    public int StartCount { get; set; }
    public string Status { get; set; }
    public int Remains { get; set; }
    public string Currency { get; set; }
}