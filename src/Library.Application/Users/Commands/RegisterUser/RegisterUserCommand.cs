using ErrorOr;
using Library.Application.Common.DTO;
using MediatR;

namespace Library.Application.Users.Commands.RegisterUser;
public record RegisterUserCommand(string username, string email, string passwordHash) : IRequest<ErrorOr<UserDTO>>;