using ErrorOr;
using Library.Domain.Entities;
using MediatR;

namespace Library.Application.Authors.Queries;

public record GetAuthorQuery(Guid authorId) : IRequest<ErrorOr<Author>>; 