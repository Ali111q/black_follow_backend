using GaragesStructure.Entities;

namespace BackEndStructuer.Entities
{
    public class SubCategory : BaseEntity<Guid>
    {
        public string? Icon { get; set; }
        public string? Name { get; set; }
    }
}
