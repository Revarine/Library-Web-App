using ErrorOr;
using MediatR;

namespace Library.Application.Genres.Commands.DeleteGenre;

public record DeleteGenreCommand(short genreId) : IRequest<ErrorOr<Deleted>>;