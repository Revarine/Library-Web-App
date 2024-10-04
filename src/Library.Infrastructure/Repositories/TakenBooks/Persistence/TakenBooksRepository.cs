using Library.Application.Common.Interfaces;
using Library.Domain.Entities;
using Library.Infrastructure.Common.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Repositories.TakenBooks.Persistence;

public class TakenBooksRepository : ITakenBooksRepository
{
    private readonly LibraryDbContext _dbContext;

    public TakenBooksRepository(LibraryDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task CreateAsync(Guid bookId, Guid userId, DateTime returnTime, CancellationToken cancellationToken = default)
    {
        var takenBook = new TakenBook(bookId, userId, DateTime.Now, returnTime);
        await _dbContext.TakenBooks.AddAsync(takenBook, cancellationToken);
    }

    public async Task DeleteAsync(Guid bookId, Guid userId, CancellationToken cancellationToken = default)
    {
        await _dbContext.TakenBooks.Where(takenBook => takenBook.UserId == userId && takenBook.BookId == bookId).ExecuteDeleteAsync(cancellationToken);
    }


    public async Task<TakenBook> GetElementByIdAsync(Guid bookId, Guid userId, CancellationToken cancellationToken = default)
    {
        return await _dbContext.TakenBooks.FirstAsync(takenBooks => takenBooks.BookId == bookId && takenBooks.UserId == userId, cancellationToken);
    }


    public async Task<IEnumerable<TakenBook>> GetElementsAsync(CancellationToken cancellationToken = default)
    {
        return await _dbContext.TakenBooks.AsNoTracking().ToListAsync(cancellationToken);
    }

    public async Task UpdateAsync(Guid bookId, Guid userId, CancellationToken cancellationToken = default)
    {
        await _dbContext.TakenBooks.Where(takenBook => takenBook.BookId == bookId && takenBook.UserId == userId).ExecuteUpdateAsync
        (
            p => p
                .SetProperty(e => e.BookId, bookId)
                .SetProperty(e => e.UserId, userId),
                cancellationToken
        );
    }
}