using AutoMapper;
using ErrorOr;
using Library.Application.Common.DTO;
using Library.Application.Common.Interfaces;
using Library.Domain.Entities;
using MediatR;

namespace Library.Application.Genres.Queries.GetGenre;

public class GetGenreQueryHandler : IRequestHandler<GetGenreQuery, ErrorOr<GenreDTO>>
{
    private readonly IGenreRepository _genreRepository;
    private readonly IMapper _mapper;

    public GetGenreQueryHandler(IGenreRepository genreRepository, IMapper mapper)
    {
        _genreRepository = genreRepository;
        _mapper = mapper;
    }
    public async Task<ErrorOr<GenreDTO>> Handle(GetGenreQuery request, CancellationToken cancellationToken)
    {
        var genre = await _genreRepository.GetElementByIdAsync(request.id, cancellationToken);
        return genre is null
        ? Error.NotFound("Genre not found")
        : _mapper.Map<GenreDTO>(genre);
    }
}
