using GaragesStructure.Entities;

namespace BackEndStructuer.Entities
{
    public class FinancialMovement : BaseEntity<Guid>
    {
        public AppUser User { get; set; }
        public Guid UserId { get; set; }
        public decimal Amount { get; set; }
    }
}
