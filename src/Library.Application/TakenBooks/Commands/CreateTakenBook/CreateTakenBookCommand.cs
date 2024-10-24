using ErrorOr;
using Library.Application.Common.DTO;
using MediatR;

namespace Library.Application.TakenBooks.Commands.CreateTakenBook;

public record CreateTakenBookCommand(Guid bookId, Guid userId, DateTime returnTime) : IRequest<ErrorOr<TakenBookDTO>>;