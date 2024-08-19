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

   
    }
}
