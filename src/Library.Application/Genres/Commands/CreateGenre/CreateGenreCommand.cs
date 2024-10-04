using ErrorOr;
using Library.Domain.Entities;
using MediatR;

namespace Library.Application.Genres.Commands.CreateGenre;

public record CreateGenreCommand(string name, short? id = null) : IRequest<ErrorOr<Genre>>;