using Library.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Repositories.TakenBooks.Persistence;

public class TakenBooksConfiguration : IEntityTypeConfiguration<TakenBook>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<TakenBook> builder)
    {
        builder.HasNoKey();
    }
}