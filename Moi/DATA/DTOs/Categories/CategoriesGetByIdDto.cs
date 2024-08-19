namespace BackEndStructuer.DATA.DTOs;

public class CategoriesGetByIdDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Icon { get; set; }
    public List<SubCategoryDto> SubCategories { get; set; }
    public List<ServiceDto> Services { get; set; }

}