using GaragesStructure.Respository.Utils;

namespace BackEndStructuer.DATA.DTOs;

public class AddOrderDto
{
    public Guid Id { get; set; }
    public OrderState State { get; set; }
    public int Count { get; set; }
    
}