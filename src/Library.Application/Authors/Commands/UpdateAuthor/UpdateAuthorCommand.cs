using ErrorOr;
using MediatR;

namespace Library.Application.Authors.Commands.UpdateAuthor;

public record UpdateAuthorCommand(Guid authorId, string authorName, string authorSurname) : IRequest<ErrorOr<Updated>>;