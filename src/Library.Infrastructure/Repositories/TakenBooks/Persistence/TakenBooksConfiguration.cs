using Library.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Repositories.TakenBooks.Persistence;

public class TakenBooksConfiguration : IEntityTypeConfiguration<TakenBook>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<TakenBook> builder)
    {
        builder.HasKey(takenBook => new { takenBook.UserId, takenBook.BookId });
        builder.HasOne(takenBook => takenBook.Book).WithMany(book => book.TakenBooks).HasForeignKey(takenBook => takenBook.BookId);
        builder.HasOne(takenBook => takenBook.User).WithMany(user => user.TakenBooks).HasForeignKey(takenBook => takenBook.UserId);

        builder.Property(takenBook => takenBook.UserId).IsRequired();
        builder.Property(takenBook => takenBook.BookId).IsRequired();
    }
}