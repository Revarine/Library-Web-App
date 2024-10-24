using Library.Application.Common.Interfaces;
using Library.Domain.Entities;
using Library.Infrastructure.Common.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Repositories.Users.Persistence;

public class UserRepository : IUserRepository
{
    private readonly LibraryDbContext _dbContext;

    public UserRepository(LibraryDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task CreateAsync(User user, CancellationToken cancellationToken = default)
    {
        await _dbContext.Users.AddAsync(user, cancellationToken);
    }

    public async Task DeleteAsync(Guid userId, CancellationToken cancellationToken = default)
    {
        await _dbContext.Users.Where(user => user.Id == userId).ExecuteDeleteAsync(cancellationToken);
    }

    public async Task<User> GetElementByIdAsync(Guid userId, CancellationToken cancellationToken = default)
    {
        return await _dbContext.Users.FirstAsync(user => user.Id == userId);
    }

    public async Task<IEnumerable<User>> GetElementsAsync(CancellationToken cancellationToken = default)
    {
        return await _dbContext.Users.ToListAsync(cancellationToken);
    }

    public async Task UpdateAsync(Guid userId, User user, CancellationToken cancellationToken = default)
    {
        await _dbContext.Users.Where(user => user.Id == userId).ExecuteUpdateAsync
        (
            p => p
                .SetProperty(e => e.Id, user.Id)
                .SetProperty(e => e.Username, user.Username)
                .SetProperty(e => e.Email, user.Email)
                .SetProperty(e => e.Password, user.Password)
                .SetProperty(e => e.IsAdmin, user.IsAdmin),
                cancellationToken
        );
    }

    public async Task<User> GetUserByEmailAsync(string email, CancellationToken cancellationToken = default)
    {
        return await _dbContext.Users.FirstAsync(user => user.Email == email);
    }
}