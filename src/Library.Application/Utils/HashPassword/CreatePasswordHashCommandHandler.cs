using ErrorOr;
using MediatR;

namespace Library.Application.Utils.HashPassword;

public class CreatePasswordHashCommandHandler : IRequestHandler<CreatePasswordHashCommand, string>
{
    public async Task<string> Handle(CreatePasswordHashCommand request, CancellationToken cancellationToken)
    {
        return BCrypt.Net.BCrypt.EnhancedHashPassword(request.password);
    }
}