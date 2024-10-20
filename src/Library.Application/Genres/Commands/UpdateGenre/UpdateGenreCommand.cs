using ErrorOr;
using MediatR;

namespace Library.Application.Genres.Commands.UpdateGenre;

public record UpdateGenreCommand(int genreId, string genreName) : IRequest<ErrorOr<Updated>>;