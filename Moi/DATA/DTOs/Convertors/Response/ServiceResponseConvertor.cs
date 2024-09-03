namespace GaragesStructure.DATA.DTOs.Convertors;

public class ServiceResponseConvertor
{
    public int Service { get; set; }
    public string Name { get; set; }
    public string Type { get; set; }
    public decimal Rate { get; set; }
    public int Min { get; set; }
    public int Max { get; set; }
    public bool DripFeed { get; set; }  
    public bool Refill { get; set; }
    public bool Cancel { get; set; }
    public string Category { get; set; }
}
