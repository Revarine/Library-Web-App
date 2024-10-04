using ErrorOr;
using Library.Application.Common.Interfaces;
using Library.Domain.Entities;
using MediatR;

namespace Library.Application.Genres.Queries.GetGenre;

public class GetGenreQueryHandler : IRequestHandler<GetGenreQuery, ErrorOr<Genre>>
{
    private readonly IGenreRepository _genreRepository;

    public GetGenreQueryHandler(IGenreRepository genreRepository)
    {
        _genreRepository = genreRepository;
    }
    public async Task<ErrorOr<Genre>> Handle(GetGenreQuery request, CancellationToken cancellationToken)
    {
        var genre = await _genreRepository.GetElementByIdAsync(request.id, cancellationToken);
        return genre is null
        ? Error.NotFound("Genre not found")
        : genre;
    }
}
