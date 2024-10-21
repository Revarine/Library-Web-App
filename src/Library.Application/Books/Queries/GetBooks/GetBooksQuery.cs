using ErrorOr;
using Library.Application.Common.DTO;
using Library.Domain.Entities;
using MediatR;

namespace Library.Application.Books.Queries.GetBooks;

public record GetBooksQuery(int skip, int take) : IRequest<ErrorOr<List<BookDTO>>>;