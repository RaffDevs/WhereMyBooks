using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WhereMyBooks.Core.Entities;

namespace WhereMyBooks.Infrastructure.Persistence.Configurations;

public class BookShelfConfiguration : IEntityTypeConfiguration<BookShelf>
{
    public void Configure(EntityTypeBuilder<BookShelf> builder)
    {
        builder
            .HasKey(bs => bs.Id);

        builder
            .HasOne(bs => bs.Owner)
            .WithOne(o => o.BookShelf)
            .HasForeignKey<BookShelf>(bs => bs.IdOwner)
            .OnDelete(DeleteBehavior.Restrict);
    }
}