using ErrorOr;
using Library.Domain.Entities;
using MediatR;

namespace Library.Application.Books.Commands.CreateBook;

public record CreateBookCommand(string title, string description, short genreId, Guid authorId, string isbn, int amount, Guid? id = null) : IRequest<ErrorOr<Book>>;