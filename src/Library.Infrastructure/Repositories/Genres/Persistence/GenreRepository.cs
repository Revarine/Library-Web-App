using Library.Application.Common.Interfaces;
using Library.Domain.Entities;
using Library.Infrastructure.Common.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Repositories.Genres.Persistence;

public class GenreRepository : IGenreRepository
{
    private readonly LibraryDbContext _dbContext;

    public GenreRepository(LibraryDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task CreateAsync(Genre genre, CancellationToken cancellationToken = default)
    {
        await _dbContext.Genres.AddAsync(genre, cancellationToken);
    }

    public async Task DeleteAsync(short genreId, CancellationToken cancellationToken = default)
    {
        await _dbContext.Genres.Where(genre => genre.Id == genreId).ExecuteDeleteAsync(cancellationToken);
    }

    public async Task<Genre> GetElementByIdAsync(short genreId, CancellationToken cancellationToken = default)
    {
        return await _dbContext.Genres.FirstAsync(genre => genre.Id == genreId, cancellationToken);
    }

    public async Task<IEnumerable<Genre>> GetElementsAsync(CancellationToken cancellationToken = default)
    {
        return await _dbContext.Genres.AsNoTracking().ToListAsync(cancellationToken);
    }

    public async Task UpdateAsync(short genreId, string name, CancellationToken cancellationToken = default)
    {
        await _dbContext.Genres.Where(genre => genre.Id == genreId).ExecuteUpdateAsync
        (
            p => p
            .SetProperty(e => e.Name, name),
            cancellationToken
        );
    }
}