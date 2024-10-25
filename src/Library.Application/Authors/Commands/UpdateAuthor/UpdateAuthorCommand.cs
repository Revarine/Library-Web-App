using ErrorOr;
using MediatR;

namespace Library.Application.Authors.Commands.UpdateAuthor;

public record UpdateAuthorCommand(Guid authorId, DateTime dateOfBirth, string country, string authorName, string authorSurname) : IRequest<ErrorOr<Updated>>;