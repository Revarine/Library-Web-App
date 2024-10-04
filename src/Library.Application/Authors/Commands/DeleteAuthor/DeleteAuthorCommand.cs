using ErrorOr;
using MediatR;

namespace Library.Application.Authors.Commands.DeleteAuthor;

public record DeleteAuthorCommand(Guid authorId) : IRequest<ErrorOr<Deleted>>;