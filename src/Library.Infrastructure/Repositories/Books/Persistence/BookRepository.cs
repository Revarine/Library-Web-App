using Library.Application.Common.Interfaces;
using Library.Domain.Entities;
using Library.Infrastructure.Common.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Repositories.Books.Persistence;

public class BookRepository : IBookRepository
{
    private readonly LibraryDbContext _dbContext;

    public BookRepository(LibraryDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task CreateAsync(Book book, CancellationToken cancellationToken = default)
    {
        await _dbContext.Books.AddAsync(book, cancellationToken);
    }

    public async Task DeleteAsync(Guid bookId, CancellationToken cancellationToken = default)
    {
        await _dbContext.Books.Where(x => x.Id == bookId).ExecuteDeleteAsync(cancellationToken);
    }

    public async Task<Book> GetElementByIdAsync(Guid bookId, CancellationToken cancellationToken = default)
    {
        return await _dbContext.Books.FirstAsync(book => book.Id == bookId, cancellationToken);
    }

    public async Task<IEnumerable<Book>> GetElementsAsync(CancellationToken cancellationToken = default)
    {
        return await _dbContext.Books.AsNoTracking().ToListAsync(cancellationToken);
    }

    public async Task UpdateAsync(Guid bookId, Book book, CancellationToken cancellationToken = default)
    {
        await _dbContext.Books.Where(book => book.Id == bookId).ExecuteUpdateAsync
        (
            p =>
                p
                    .SetProperty(e => e.Id, book.Id)
                    .SetProperty(e => e.Title, book.Title)
                    .SetProperty(e => e.Description, book.Description)
                    .SetProperty(e => e.AuthorId, book.AuthorId)
                    .SetProperty(e => e.ISBN, book.ISBN)
                    .SetProperty(e => e.GenreId, book.GenreId)
                    .SetProperty(e => e.Amount, book.Amount),
                    cancellationToken
        );
    }
}