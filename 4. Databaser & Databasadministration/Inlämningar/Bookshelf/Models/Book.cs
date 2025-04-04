using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net;

namespace Bookshelf.Models
{
    [Table("Books")]
    public class Book
    {
        [Key]
        public int BookId { get; set; } 

        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        [Required]
        public string Genre { get; set; }

        [ForeignKey("Author")]
        public int AuthorId { get; set; }

        public Author Author { get; set; } = null!;


    }
}
