namespace BackEndStructuer.DATA.DTOs
{

    public class OrderForm 
    {
        public Guid ServiceId { get; set; }
        public int Quantity { get; set; }
        public string Link { get; set; }
    }
}
