using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WhereMyBooks.Core.Entities;

namespace WhereMyBooks.Infrastructure.Persistence.Configurations;

public class BookConfiguration : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder.HasKey(b => b.Id);

        builder
            .HasOne(b => b.Shelf)
            .WithMany(s => s.Books)
            .HasForeignKey(b => b.IdShelf)
            .OnDelete(DeleteBehavior.Restrict);
    }
}