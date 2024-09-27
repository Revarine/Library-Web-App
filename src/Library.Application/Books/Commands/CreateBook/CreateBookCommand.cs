using ErrorOr;
using Library.Domain.Entities;
using MediatR;

namespace Library.Application.Books.Commands.CreateBook;

public record CreateBookCommand(Guid id, string title, string description, short genreId, Guid authorId, string isbn, int amount) : IRequest<ErrorOr<Book>>;