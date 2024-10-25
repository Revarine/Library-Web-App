using MediatR;

namespace Library.Application.Utils.HashPassword;

public record CreatePasswordHashCommand(string password) : IRequest<string>;