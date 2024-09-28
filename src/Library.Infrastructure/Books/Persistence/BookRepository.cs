using Library.Application.Common.Interfaces;
using Library.Domain.Entities;
using Library.Infrastructure.Common.Persistence;

namespace Library.Infrastructure.Books.Persistence;

public class BookRepository : IBookRepository
{
    private readonly LibraryDbContext _dbContext;

    public BookRepository(LibraryDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task CreateAsync(Book book, CancellationToken cancellationToken = default)
    {
        await _dbContext.Books.AddAsync(book);
    }

    public Task DeleteAsync(Guid bookId)
    {
        throw new NotImplementedException();
    }

    public Task<Book> GetElementByIdAsync(Guid bookId, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Book>> GetElementsAsync(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(Guid bookId, Book book, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}