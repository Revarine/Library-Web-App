using ErrorOr;
using Library.Application.Common.DTO;
using Library.Domain.Entities;
using MediatR;

namespace Library.Application.Authors.Commands.CreateAuthor;

public record CreateAuthorCommand(string name, string surname, Guid? id = null) : IRequest<ErrorOr<AuthorDTO>>;