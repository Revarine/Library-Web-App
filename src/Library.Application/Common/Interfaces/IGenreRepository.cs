using Library.Domain.Entities;

namespace Library.Application.Common.Interfaces;

public interface IGenreRepository
{
    Task<Genre> GetElementByIdAsync(int genreId, CancellationToken cancellationToken = default);
    Task<IEnumerable<Genre>> GetElementsAsync(CancellationToken cancellationToken = default);
    Task CreateAsync(Genre genre, CancellationToken cancellationToken = default);
    Task UpdateAsync(int genreId, string name, CancellationToken cancellationToken = default);
    Task DeleteAsync(int genreId, CancellationToken cancellationToken = default);
}