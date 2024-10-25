using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Library.Domain.Entities;
using MediatR;
using Microsoft.IdentityModel.Tokens;

namespace Library.Application.Utils.JWTProvider;

public class JwtAccessTokenProviderCommandHandler : IRequestHandler<JwtAccessTokenProviderCommand, string>
{
    public async Task<string> Handle(JwtAccessTokenProviderCommand request, CancellationToken cancellationToken)
    {
        Claim[] claims = [new("userId", request.user.Id.ToString()), new("adm", request.user.IsAdmin.ToString())];
        var signingCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes("secretsecretsecretsecretsecretsecretsecretsecretsecretsecretsecret")), SecurityAlgorithms.HmacSha256);
        var token = new JwtSecurityToken(signingCredentials: signingCredentials, expires: DateTime.UtcNow.AddHours(12), claims: claims);

        var tokenValue = new JwtSecurityTokenHandler().WriteToken(token);

        return tokenValue;
    }
}