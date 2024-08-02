using BookVerseAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BookVerseAPI.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Book> Books { get; set; }
    public DbSet<Rental> Rentals { get; set; }
}
