using FluentValidation;
using Library.Application.Common.DTO;

namespace Library.Application.Common.Validators;

public class BookValidator : AbstractValidator<BookDTO>
{
    public BookValidator()
    {
        RuleFor(book => book.Title).NotNull().NotEmpty().MinimumLength(5).MaximumLength(200);
        RuleFor(book => book.Id).NotNull().NotEmpty();
        RuleFor(book => book.Description).NotNull().NotEmpty().MaximumLength(1000);
        RuleFor(book => book.Amount).LessThan(20).GreaterThan(0);
        RuleFor(book => book.ISBN).NotNull().NotEmpty().MaximumLength(13);
        RuleFor(book => book.AuthorId).NotEmpty();
        RuleFor(book => book.GenreId).GreaterThan(0);
    }
}