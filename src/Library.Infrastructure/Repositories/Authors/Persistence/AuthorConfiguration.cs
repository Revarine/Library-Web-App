using Library.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.Infrastructure.Repositories.Authors.Persistence;

public class AuthorConfiguration : IEntityTypeConfiguration<Author>
{
    public void Configure(EntityTypeBuilder<Author> builder)
    {
        builder.HasKey(author => author.Id);
        builder.Property(author => author.Id).ValueGeneratedNever();
        builder.HasMany(author => author.Books).WithOne(book => book.Author).HasForeignKey(author => author.Id);
    }
}