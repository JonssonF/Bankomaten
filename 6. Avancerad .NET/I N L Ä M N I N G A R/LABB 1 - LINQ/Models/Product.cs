using System.ComponentModel.DataAnnotations;

namespace Labb1___LINQ.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string? Name { get; set; }

        [MaxLength(500)]
        public string? Description { get; set; } = string.Empty;

        public decimal Price { get; set; }

        [Required]
        public int CategoryId { get; set; }

        public int StockQuantity { get; set; }

        [Required]
        public int SupplierId { get; set; }

        //Navigation Propertys
        public Category Category { get; set; } = null!;

        public Supplier Supplier { get; set; } = null!;

    }
}