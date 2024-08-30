using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WhereMyBooks.Core.Entities;

namespace WhereMyBooks.Infrastructure.Persistence.Configurations;

public class MarkupConfiguration : IEntityTypeConfiguration<Markup>
{
    public void Configure(EntityTypeBuilder<Markup> builder)
    {
        builder.HasKey(m => m.Id);

        builder
            .HasOne(m => m.Book)
            .WithMany(b => b.Markups)
            .HasForeignKey(m => m.IdBook)
            .OnDelete(DeleteBehavior.Restrict);
    }
}