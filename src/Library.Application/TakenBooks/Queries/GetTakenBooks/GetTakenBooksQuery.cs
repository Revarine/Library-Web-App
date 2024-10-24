using ErrorOr;
using Library.Application.Common.DTO;
using MediatR;

namespace Library.Application.TakenBooks.Queries.GetTakenBooks;

public record GetTakenBooksQuery() : IRequest<ErrorOr<List<TakenBookDTO>>>;