using ErrorOr;
using Library.Application.Common.DTO;
using MediatR;

public record GetBookByAuthorIdQuery(Guid authorId) : IRequest<ErrorOr<List<BookDTO>>>;