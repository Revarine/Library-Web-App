using Library.Domain.Entities;

namespace Library.Application.Common.Interfaces;

public interface ITakenBooksRepository
{
    Task<TakenBook> GetElementByIdAsync(Guid bookId, Guid UserId, CancellationToken cancellationToken = default);
    Task<IEnumerable<TakenBook>> GetElementsAsync(CancellationToken cancellationToken = default);
    Task CreateAsync(TakenBook takenBook, CancellationToken cancellationToken = default);
    Task UpdateAsync(Guid bookId, Guid userId, CancellationToken cancellationToken = default);
    Task DeleteAsync(Guid bookId, Guid userId, CancellationToken cancellationToken = default);
}