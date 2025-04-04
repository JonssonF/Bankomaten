using Bookshelf.Models;
using Microsoft.EntityFrameworkCore;

namespace Bookshelf.Data
{
    public class BookShelfContext : DbContext
    {

        public DbSet<Book> Books { get; set; }

        public DbSet<Author> Authors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost;Database=BookShelfDb;Integrated Security=True; Trust Server Certificate=true;");
        }
    }
}
