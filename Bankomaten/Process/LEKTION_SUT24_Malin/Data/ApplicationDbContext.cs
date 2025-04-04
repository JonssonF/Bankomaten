using LEKTION_SUT24_Malin.Models;
using Microsoft.EntityFrameworkCore;

namespace LEKTION_SUT24_Malin.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost;Database=EFCodeFirstDB;Integrated Security=True; Trust Server Certificate=true;");
        }

    }
}
