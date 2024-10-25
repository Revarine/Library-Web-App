
using Library.Application.Common.Interfaces;
using MediatR;

namespace Library.Application.Utils.VerifyHash;

public class VerifyHashCommandHandler : IRequestHandler<VerifyHashCommand, bool>
{
    private readonly IUserRepository _userRepository;
    public VerifyHashCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    public async Task<bool> Handle(VerifyHashCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetElementByIdAsync(request.userId, cancellationToken);
        return BCrypt.Net.BCrypt.EnhancedVerify(request.password, user.Password);
    }
}