using ErrorOr;
using Library.Application.Common.DTO.Books;
using Library.Domain.Entities;
using MediatR;

namespace Library.Application.Books.Commands.CreateBook;

public record CreateBookCommand(string title, string description, int genreId, Guid authorId, string isbn, int amount, Guid? id = null) : IRequest<ErrorOr<BookDTO>>;