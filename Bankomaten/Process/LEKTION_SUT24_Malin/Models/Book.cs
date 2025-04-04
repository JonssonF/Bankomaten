using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LEKTION_SUT24_Malin.Models
{
    public class Book
    {
        [Key]

        public int BookId { get; set; }

        public string Title { get; set; }

        public string Genre { get; set; }

        [ForeignKey("Author")]

        public int AuthorId {  get; set; }
        //Navigation
        public Author Author { get; set; }


    }
}
