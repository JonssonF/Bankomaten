using System.ComponentModel.DataAnnotations;

namespace Labb1___LINQ.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string? Name { get; set; }

        [Required]
        [MaxLength(250)]
        public string? Email { get; set; }

        [Required]
        public string? Phone { get; set; }

        [Required]
        [MaxLength(500)]
        public string? Adress { get; set; }

        //Navigational Propertys
        public ICollection<Order> Orders { get; set; } = new List<Order>();

    }
}
