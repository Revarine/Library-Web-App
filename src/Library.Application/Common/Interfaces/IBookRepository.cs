using Library.Domain.Entities;

namespace Library.Application.Common.Interfaces;

public interface IBookRepository
{
    Task<Book> GetElementByIdAsync(Guid bookId, CancellationToken cancellationToken = default);
    Task<IEnumerable<Book>> GetElementsAsync(int skip, int take, CancellationToken cancellationToken = default);
    Task CreateAsync(Book book, CancellationToken cancellationToken = default);
    Task UpdateAsync(Guid bookId, Book book, CancellationToken cancellationToken = default);
    Task DeleteAsync(Guid bookId, CancellationToken cancellationToken = default);

    Task<Book> GetElementByISBNAsync(string ISBN, CancellationToken cancellationToken = default);

    Task<IEnumerable<Book>> GetBooksByAuthorIdAsync(Guid authorId, CancellationToken cancellationToken = default);
}