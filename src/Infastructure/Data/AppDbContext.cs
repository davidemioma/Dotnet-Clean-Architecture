using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seeding some data to db.
            modelBuilder.Entity<Book>().HasData(
                new Book { Id = new Guid("11111111-1111-1111-1111-111111111111"), Title = "To Kill a Mockingbird", Author = "Harper Lee", YearPublished = 1960 },
                new Book { Id = new Guid("22222222-2222-2222-2222-222222222222"), Title = "1984", Author = "George Orwell", YearPublished = 1949 },
                new Book { Id = new Guid("33333333-3333-3333-3333-333333333333"), Title = "The Great Gatsby", Author = "F. Scott Fitzgerald", YearPublished = 1925 },
                new Book { Id = new Guid("44444444-4444-4444-4444-444444444444"), Title = "Pride and Prejudice", Author = "Jane Austen", YearPublished = 1813 },
                new Book { Id = new Guid("55555555-5555-5555-5555-555555555555"), Title = "The Hobbit", Author = "J.R.R. Tolkien", YearPublished = 1937 }
            );
        }

        public DbSet<Book> Books { get; set; }

    }
}