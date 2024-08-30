using System.Reflection;
using Microsoft.EntityFrameworkCore;
using WhereMyBooks.Core.Entities;

namespace WhereMyBooks.Infrastructure.Persistence;

public class WhereMyBookDbContext : DbContext
{
    public WhereMyBookDbContext(DbContextOptions<WhereMyBookDbContext> options) : base(options) {}
    
    public DbSet<Owner> Owners { get; set; }
    public DbSet<BookShelf> BookShelves { get; set; }
    public DbSet<Shelf> Shelves { get; set; }
    public DbSet<Book> Books { get; set; }
    public DbSet<Markup> Markups { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }
}