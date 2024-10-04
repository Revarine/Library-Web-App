using ErrorOr;
using Library.Domain.Entities;
using MediatR;

namespace Library.Application.Authors.Commands.CreateAuthor;

public record CreateAuthorCommand(string name, string surname, Guid? id = null) : IRequest<ErrorOr<Author>>;