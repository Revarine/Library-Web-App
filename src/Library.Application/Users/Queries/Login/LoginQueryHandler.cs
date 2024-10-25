using ErrorOr;
using Library.Application.Common.Interfaces;
using Library.Application.Utils.JwtProvider;
using Library.Application.Utils.VerifyHash;
using Library.Domain.Entities;
using MediatR;

namespace Library.Application.Users.Queries.Login;

public class LoginQueryHandler : IRequestHandler<LoginQuery, ErrorOr<User>>
{
    private readonly IUserRepository _userRepository;
    private readonly ISender _mediator;
    public LoginQueryHandler(IUserRepository userRepository, ISender mediator)
    {
        _userRepository = userRepository;
        _mediator = mediator;
    }
    public async Task<ErrorOr<User>> Handle(LoginQuery request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetUserByEmailAsync(request.email);
        if (user == null) Error.NotFound("User not found");
        var verifyCommand = new VerifyHashCommand(user.Id, request.password);
        var verificationResult = await _mediator.Send(verifyCommand);

        if (!verificationResult)
        {
            return Error.Failure("Password is incorrect", "Try to use different password");
        }

        return user;
    }
}