using Library.Domain.Entities;

namespace Library.Application.Common.Interfaces;

public interface IUserRepository
{
    Task<User> GetElementByIdAsync(Guid userId, CancellationToken cancellationToken = default);
    Task<IEnumerable<User>> GetElementsAsync(CancellationToken cancellationToken = default);
    Task CreateAsync(User user, CancellationToken cancellationToken = default);
    Task UpdateAsync(Guid userId, User user, CancellationToken cancellationToken = default);
    Task DeleteAsync(Guid userId, CancellationToken cancellationToken = default);
}