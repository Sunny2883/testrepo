using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Book> Books { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Seed data
        modelBuilder.Entity<Book>().HasData(
            new Book { Id = 1, Title = "1984", Author = "George Orwell", PublicationYear = 1949 },
            new Book { Id = 2, Title = "To Kill a Mockingbird", Author = "Harper Lee", PublicationYear = 1960 },
            new Book { Id = 3, Title = "The Great Gatsby", Author = "F. Scott Fitzgerald", PublicationYear = 1925 }
        );
    }
}