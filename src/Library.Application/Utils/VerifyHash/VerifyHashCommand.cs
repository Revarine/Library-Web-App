
using MediatR;

namespace Library.Application.Utils.VerifyHash;

public record VerifyHashCommand(Guid userId, string password) : IRequest<bool>;