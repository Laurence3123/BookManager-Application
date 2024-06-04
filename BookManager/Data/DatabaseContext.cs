using BookManager.Models;
using Microsoft.EntityFrameworkCore;

namespace BookManager.Data
{
    public class DatabaseContext: DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Study> Studies { get; set; }
    }
}
