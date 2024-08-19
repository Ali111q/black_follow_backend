using GaragesStructure.Entities;

namespace BackEndStructuer.Entities
{
    public class Order : BaseEntity<Guid>
    {
        public string Link { get; set; }  
        public int Count { get; set; }    
        public decimal Price { get; set; } 
        public string State { get; set; }  
        public DateTime Date { get; set; }  
    }
}
