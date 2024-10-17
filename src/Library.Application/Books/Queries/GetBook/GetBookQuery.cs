using ErrorOr;
using Library.Application.Common.DTO.Books;
using Library.Domain.Entities;
using MediatR;

namespace Library.Application.Books.Queries.GetBook;

public record GetBookQuery(Guid bookId) : IRequest<ErrorOr<BookDTO>>;