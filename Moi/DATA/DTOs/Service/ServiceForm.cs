namespace BackEndStructuer.DATA.DTOs
{

    public class ServiceForm 
    {
        public string? Icon { get; set; }
        public string? Name { get; set; }
        public string? Minimum { get; set; }
        public string? Maximum { get; set; }
        public string? Description { get; set; }
        public string? ServiceId { get; set; }
        public decimal? ServicePrice { get; set; }
        public Guid SubCategoryId { get; set; }
    }
}
