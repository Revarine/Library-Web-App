using ErrorOr;
using MediatR;

namespace Library.Application.TakenBooks.Commands.DeleteTakenBook;
public record DeleteTakenBookCommand(Guid bookId, Guid userId) : IRequest<ErrorOr<Deleted>>;