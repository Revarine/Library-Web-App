using ErrorOr;
using MediatR;

namespace Library.Application.Books.Commands.DeleteBook;

public record DeleteBookCommand(Guid bookId) : IRequest<ErrorOr<Deleted>>;