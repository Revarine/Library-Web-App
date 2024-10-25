using ErrorOr;
using Library.Domain.Entities;
using MediatR;

namespace Library.Application.Users.Queries.Login;

public record LoginQuery(string email, string password) : IRequest<ErrorOr<User>>;