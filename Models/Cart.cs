using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RestDemoMVC.Models
{
    public class Cart
    {
        [Key]
        public int Id { get; set; }
        public DateTime? Date { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Display(Name = "Total Price")]
        [Required]
        public double TotalPrice { get; set; }

        public string UserId { get; set; }
        public Order? Order { get; set; }

        public int ProductId { get; set; }
        public Product? Product { get; set; }


    }
}
