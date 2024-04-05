using Microsoft.EntityFrameworkCore;
using LMS_project_5.Models; 

namespace LMS_project_5.Data
{
    public class LibraryContext : DbContext
    {
        public LibraryContext(DbContextOptions<LibraryContext> options)
            : base(options)
        {
        }

        // DbSet properties for each entity model
        public DbSet<Book> Books { get; set; }
        public DbSet<Reader> Readers { get; set; }
        public DbSet<Borrowing> Borrowings { get; set; }

        
    }
}
