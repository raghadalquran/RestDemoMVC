using System.ComponentModel.DataAnnotations.Schema;

namespace RestDemoMVC.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public double Price { get; set; }
        public string? ImagePath { get; set; }
        [NotMapped]
        public virtual IFormFile ImageFile { get; set; }
        public int CategoryId { get; set; }
        public Category? Category { get; set; }


    }
}
