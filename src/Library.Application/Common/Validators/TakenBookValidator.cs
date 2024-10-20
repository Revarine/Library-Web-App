using FluentValidation;
using Library.Application.Common.DTO;

namespace Library.Application.Common.Validators;

public class TakenBookValidator : AbstractValidator<TakenBookDTO>
{
    public TakenBookValidator()
    {
        RuleFor(takenbook => takenbook.BookId).NotNull().NotEmpty();
        RuleFor(takenbook => takenbook.UserId).NotNull().NotEmpty();
        RuleFor(takenbook => takenbook.TakeDate).NotNull().NotEmpty().GreaterThanOrEqualTo(DateTime.Now);
        RuleFor(takenbook => takenbook.ReturnDate).NotNull().NotEmpty().GreaterThanOrEqualTo(DateTime.Now);
    }
}