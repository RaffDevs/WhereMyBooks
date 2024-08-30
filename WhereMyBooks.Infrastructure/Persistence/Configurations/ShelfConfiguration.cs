using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WhereMyBooks.Core.Entities;

namespace WhereMyBooks.Infrastructure.Persistence.Configurations;

public class ShelfConfiguration : IEntityTypeConfiguration<Shelf>
{
    public void Configure(EntityTypeBuilder<Shelf> builder)
    {
        builder.HasKey(s => s.Id);

        builder
            .HasOne(s => s.BookShelf)
            .WithMany(bs => bs.Shelves)
            .HasForeignKey(s => s.IdBookShelf)
            .OnDelete(DeleteBehavior.Restrict);
    }
}