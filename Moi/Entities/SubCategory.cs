using GaragesStructure.Entities;

namespace BackEndStructuer.Entities
{
    public class SubCategory : BaseEntity<Guid>
    {
        public string? Icon { get; set; }
        public string? Name { get; set; }

        public Guid CategoriesId { get; set; }
        public Categories Categories { get; set; }
        public List<Service> Services { get; set; }
    }
}
