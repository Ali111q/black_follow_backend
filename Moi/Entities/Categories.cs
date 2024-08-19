using GaragesStructure.Entities;

namespace BackEndStructuer.Entities
{
    public class Categories : BaseEntity<Guid>
    {
        public string? Icon { get; set; }
        public string? Name { get; set; }
        public List<SubCategory> SubCategories { get; set; }
    }
}
