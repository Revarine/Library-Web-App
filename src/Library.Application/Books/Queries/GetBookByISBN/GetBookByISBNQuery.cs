using ErrorOr;
using Library.Application.Common.DTO;
using MediatR;

namespace Library.Application.Books.Queries.GetBookByISBN;

public record GetBookByISBNQuery(string ISBN) : IRequest<ErrorOr<BookDTO>>;