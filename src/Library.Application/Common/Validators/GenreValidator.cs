using FluentValidation;
using Library.Application.Common.DTO;

namespace Library.Application.Common.Validators;

public class GenreValidator : AbstractValidator<GenreDTO>
{
    public GenreValidator()
    {
        RuleFor(genre => genre.Id).NotEmpty().GreaterThan(-1);
        RuleFor(genre => genre.Name).NotNull().NotEmpty().MinimumLength(1).MaximumLength(20);
    }
}