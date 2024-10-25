using MediatR;

namespace Library.Application.Utils.JwtProvider;

public record JwtRefreshTokenProviderCommand() : IRequest<string>;