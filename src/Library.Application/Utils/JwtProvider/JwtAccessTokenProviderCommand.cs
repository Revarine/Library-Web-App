using Library.Domain.Entities;
using MediatR;

public record JwtAccessTokenProviderCommand(User user) : IRequest<string>;