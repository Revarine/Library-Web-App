using Library.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.Infrastructure.Repositories.Genres.Persistence;

public class GenreConfiguration : IEntityTypeConfiguration<Genre>
{
    public void Configure(EntityTypeBuilder<Genre> builder)
    {
        builder.HasKey(genre => genre.Id);
        builder.Property(genre => genre.Id).ValueGeneratedNever();
        builder.HasMany(genre => genre.Books).WithOne(book => book.Genre).HasForeignKey(book => book.GenreId);
        // TODO: potom
    }
}