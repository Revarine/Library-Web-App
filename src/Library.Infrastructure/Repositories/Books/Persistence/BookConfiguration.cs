using Library.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.Infrastructure.Repositories.Books.Persistence;

public class BookConfiguration : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder.HasKey(book => book.Id);
        builder.Property(book => book.Id).ValueGeneratedNever();
        builder.HasOne(book => book.Author).WithMany(a => a.Books).HasForeignKey(book => book.AuthorId);
        builder.HasOne(book => book.Genre).WithMany(g => g.Books).HasForeignKey(book => book.GenreId);
        builder.HasMany(book => book.TakenBooks).WithOne(takenBook => takenBook.Book).HasForeignKey(takenBook => takenBook.BookId);
    }
}