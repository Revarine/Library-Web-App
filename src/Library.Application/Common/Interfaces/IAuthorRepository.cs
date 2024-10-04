using Library.Domain.Entities;

namespace Library.Application.Common.Interfaces;

public interface IAuthorRepository
{
    Task<Author> GetElementByIdAsync(Guid authorId, CancellationToken cancellationToken = default);
    Task<IEnumerable<Author>> GetElementsAsync(CancellationToken cancellationToken = default);
    Task CreateAsync(Author author, CancellationToken cancellationToken = default);
    Task UpdateAsync(Guid authorId, Author author, CancellationToken cancellationToken = default);
    Task DeleteAsync(Guid authorId, CancellationToken cancellationToken = default);

}