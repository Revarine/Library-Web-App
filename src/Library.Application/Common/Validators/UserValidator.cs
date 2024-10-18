using FluentValidation;
using Library.Application.Common.DTO.Books;
using Library.Domain.Entities;

namespace Library.Application.Common.Validators;

public class UserValidator : AbstractValidator<UserDTO>
{
    public UserValidator()
    {
        RuleFor(user => user.Id).NotNull().NotEmpty();
        RuleFor(user => user.Username).NotNull().NotEmpty().MinimumLength(1).MaximumLength(30);
        RuleFor(user => user.Email).NotNull().NotEmpty().EmailAddress(FluentValidation.Validators.EmailValidationMode.AspNetCoreCompatible);
        RuleFor(user => user.Password).NotNull().NotEmpty().MinimumLength(8).MaximumLength(100)
                    .Matches(@"[A-Z]+").WithMessage("Your password must contain at least one uppercase letter.")
                    .Matches(@"[a-z]+").WithMessage("Your password must contain at least one lowercase letter.")
                    .Matches(@"[0-9]+").WithMessage("Your password must contain at least one number.")
                    .Matches(@"[\!\?\*\.]+").WithMessage("Your password must contain at least one (!? *.).");
        // isAdmin'a не будет
    }
}