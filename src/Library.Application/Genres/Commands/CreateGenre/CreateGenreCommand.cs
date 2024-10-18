using ErrorOr;
using Library.Application.Common.DTO.Books;
using Library.Domain.Entities;
using MediatR;

namespace Library.Application.Genres.Commands.CreateGenre;

public record CreateGenreCommand(string name, int? id = null) : IRequest<ErrorOr<GenreDTO>>;