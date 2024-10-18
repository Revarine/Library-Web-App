using ErrorOr;
using Library.Application.Common.DTO.Books;
using Library.Domain.Entities;
using MediatR;

namespace Library.Application.Genres.Queries.GetGenre;

public record GetGenreQuery(int id) : IRequest<ErrorOr<GenreDTO>>;