using System.Security.Cryptography;
using MediatR;

namespace Library.Application.Utils.JwtProvider;

public class JwtRefreshTokenProviderCommandHandler : IRequestHandler<JwtRefreshTokenProviderCommand, string>
{
    public Task<string> Handle(JwtRefreshTokenProviderCommand request, CancellationToken cancellationToken)
    {
        var randomNumber = new byte[32];
        using (var randomNumberGenerator = RandomNumberGenerator.Create())
        {
            randomNumberGenerator.GetBytes(randomNumber);
            return Task.FromResult(Convert.ToBase64String(randomNumber));
        }
    }
}