using FluentValidation;
using Library.Application.Common.DTO;

namespace Library.Application.Common.Validators;

public class AuthorValidator : AbstractValidator<AuthorDTO>
{
    public AuthorValidator()
    {
        RuleFor(author => author.Name).NotNull().NotEmpty().MinimumLength(1).MaximumLength(30);
        RuleFor(author => author.Surname).NotNull().NotEmpty().MinimumLength(1).MaximumLength(30);
        RuleFor(author => author.Id).NotNull().NotEmpty();
    }
}