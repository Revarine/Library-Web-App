using System.Runtime.Serialization;
using ErrorOr;
using Library.Application.Users.Commands.RegisterUser;
using Library.Application.Users.Queries.Login;
using Library.Application.Utils.HashPassword;
using Library.Application.Utils.JwtProvider;
using Library.Contracts.Users;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Validations.Rules;

namespace Library.API.Controllers;




[Route("[controller]")]
[AllowAnonymous]
public class UsersController : ControllerBase
{
    private readonly ISender _mediator;


    public UsersController(ISender mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("Register")]
    public async Task<IActionResult> Register(RegisterUserRequest request)
    {
        var hashingCommand = new CreatePasswordHashCommand(request.password);
        var hash = await _mediator.Send(hashingCommand);

        var command = new RegisterUserCommand(request.username, request.email, hash.ToString());

        var registerUserResult = await _mediator.Send(command);

        return registerUserResult.MatchFirst(user => Ok(new UserResponse(user.Id, user.Email, user.Password)), error => Problem(error.ToString()));
    }

    [HttpPost("Login")]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        var query = new LoginQuery(request.email, request.password);

        var user = await _mediator.Send(query);

        return user.MatchFirst<IActionResult>(
            _ =>
            {
                var accessTokenCommand = new JwtAccessTokenProviderCommand(user.Match(user => user, error => null));

                var accessToken = _mediator.Send(accessTokenCommand);

                var refreshTokenCommand = new JwtRefreshTokenProviderCommand();

                var refreshToken = _mediator.Send(refreshTokenCommand);

                return Ok(new TokenResponse(accessToken.Result, refreshToken.Result, DateTime.UtcNow.AddHours(12)));
            },
            error => Problem(error.ToString())
            );
    }

}