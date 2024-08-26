using GaragesStructure.Entities;
using GaragesStructure.Respository.Utils;

namespace BackEndStructuer.Entities
{
    public class Order : BaseEntity<Guid>
    {
        public string Link { get; set; }  
        public int Count { get; set; }    
        // public decimal Price { get; set; } 
        public OrderState State { get; set; } = OrderState.Pending;
        public DateTime Date { get; set; }  
        public Guid UserId { get; set; }
        public AppUser User { get; set; }
        public Guid ServiceId { get; set; }
        public Service Service { get; set; }
        public FinancialMovement FinancialMovement { get; set; }
        public Guid FinancialMovementId { get; set; }
    }
}
