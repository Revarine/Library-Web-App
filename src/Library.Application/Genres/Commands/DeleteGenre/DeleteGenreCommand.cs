using ErrorOr;
using MediatR;

namespace Library.Application.Genres.Commands.DeleteGenre;

public record DeleteGenreCommand(int genreId) : IRequest<ErrorOr<Deleted>>;