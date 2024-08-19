using GaragesStructure.Entities;

namespace BackEndStructuer.Entities
{
    public class Service : BaseEntity<Guid>
    {
        public string? Icon { get; set; }
        public string? Name { get; set; }
        public string? Minimum { get; set; }
        public string? Maximum { get; set; }

        public decimal? ServicePrice { get; set; }
        public Guid SubCategoryId { get; set; }
        public SubCategory SubCategory { get; set; }
        public List<Order> Orders { get; set; }
        
    }
}
