using Library.Application.Common.Interfaces;
using Library.Domain.Entities;
using Library.Infrastructure.Common.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Repositories.Authors.Persistence;

public class AuthorRepository : IAuthorRepository
{
    private readonly LibraryDbContext _dbContext;

    public AuthorRepository(LibraryDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task CreateAsync(Author author, CancellationToken cancellationToken = default)
    {
        await _dbContext.Authors.AddAsync(author, cancellationToken);
    }

    public async Task DeleteAsync(Guid authorId, CancellationToken cancellationToken = default)
    {
        await _dbContext.Authors.Where(author => author.Id == authorId).ExecuteDeleteAsync(cancellationToken);
    }

    public async Task<Author> GetElementByIdAsync(Guid authorId, CancellationToken cancellationToken = default)
    {
        return await _dbContext.Authors.FirstAsync(author => author.Id == authorId, cancellationToken);
    }

    public async Task<IEnumerable<Author>> GetElementsAsync(CancellationToken cancellationToken = default)
    {
        return await _dbContext.Authors.AsNoTracking().ToListAsync(cancellationToken);
    }

    public async Task UpdateAsync(Guid authorId, Author author, CancellationToken cancellationToken = default)
    {
        await _dbContext.Authors.Where(author => author.Id == authorId).ExecuteUpdateAsync
        (
            p =>
                p
                    .SetProperty(e => e.Id, author.Id)
                    .SetProperty(e => e.DateOfBirth, author.DateOfBirth)
                    .SetProperty(e => e.Country, author.Country)
                    .SetProperty(e => e.Name, author.Name)
                    .SetProperty(e => e.Surname, author.Surname),
                    cancellationToken
        );
    }
}