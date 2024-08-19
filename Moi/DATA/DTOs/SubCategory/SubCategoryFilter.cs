using GaragesStructure.DATA.DTOs;

namespace BackEndStructuer.DATA.DTOs
{

    public class SubCategoryFilter : BaseFilter 
    {
        public string Name { get; set; }
        public Guid? CategoriesId { get; set; }
    }
}
