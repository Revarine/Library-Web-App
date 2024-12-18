using ErrorOr;
using Library.Application.Common.DTO;
using Library.Domain.Entities;
using MediatR;

namespace Library.Application.Authors.Queries;

public record GetAuthorQuery(Guid authorId) : IRequest<ErrorOr<AuthorDTO>>;