using ErrorOr;
using Library.Domain.Entities;
using MediatR;

namespace Library.Application.Genres.Queries.GetGenre;

public record GetGenreQuery(short id) : IRequest<ErrorOr<Genre>>;