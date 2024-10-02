using Library.Domain.Entities;

namespace Library.Application.Common.Interfaces;

public interface IGenreRepository
{
    Task<Genre> GetElementByIdAsync(short genreId, CancellationToken cancellationToken = default);
    Task<IEnumerable<Genre>> GetElementsAsync(CancellationToken cancellationToken = default);
    Task CreateAsync(Genre genre, CancellationToken cancellationToken = default);
    Task UpdateAsync(short genreId, string name, CancellationToken cancellationToken = default);
    Task DeleteAsync(short genreId, CancellationToken cancellationToken = default);
}