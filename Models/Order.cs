namespace RestDemoMVC.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
        public string UserId { get; set; }
        public int CartId { get; set; }
        public Cart? Cart { get; set; }
    }
}
