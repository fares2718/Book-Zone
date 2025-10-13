using BookZone.Models;
using Microsoft.EntityFrameworkCore;

namespace BookZone.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> contextOptions)
            :base(contextOptions)
        {
                
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Languge> Languges { get; set; }
        public DbSet<BookLanguge> BookLanguges { get; set; }
        public DbSet<Category> Categories { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasData(new Category[] {
                     new Category { Id = 1, Name = "Fiction" },
                     new Category { Id = 2, Name = "Science Fiction & Fantasy" },
                     new Category { Id = 3, Name = "Biography & Memoir" },
                     new Category { Id = 4, Name = "Self-Help" },
                     new Category { Id = 5, Name = "History" }
                });

            modelBuilder.Entity<Languge>()
                .HasData(new Languge[] {
                     new Languge { Id = 1, Name = "English", Icon = "bi-globe2" },
                     new Languge { Id = 2, Name = "Spanish", Icon = "bi-translate" },
                     new Languge { Id = 3, Name = "Arabic", Icon = "bi-type-h1" },
                     new Languge { Id = 4, Name = "French", Icon = "bi-chat-left-text" },
                     new Languge { Id = 5, Name = "German", Icon = "bi-flag" }
                });
            modelBuilder.Entity<BookLanguge>()
                .HasKey(e => new { e.LangugeId, e.BookId });
            base.OnModelCreating(modelBuilder);
        }
    }
}
