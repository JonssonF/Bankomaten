using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography.X509Certificates;

namespace LEKTION_SUT24_Malin.Models
{
    [Table("Authors")]
    public class Author
    {
        [Key]

        public int AuthorId {  get; set; }
        
        public string FirstName { get; set; }  

        public string LastName { get; set; }

        public ICollection<Book> Books { get; set; }
    }
}
