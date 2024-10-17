using AutoMapper;
using ErrorOr;
using Library.Application.Common.DTO.Books;
using Library.Application.Common.Interfaces;
using Library.Domain.Entities;
using MediatR;

namespace Library.Application.Genres.Commands.CreateGenre;

public class CreateGenreCommandHandler : IRequestHandler<CreateGenreCommand, ErrorOr<GenreDTO>>
{
    private readonly IGenreRepository _genreRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateGenreCommandHandler(IGenreRepository genreRepository, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _genreRepository = genreRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    public async Task<ErrorOr<GenreDTO>> Handle(CreateGenreCommand request, CancellationToken cancellationToken)
    {
        var genre = new Genre(request.id, request.name);

        await _genreRepository.CreateAsync(genre);
        await _unitOfWork.CommitChangesAsync();

        return _mapper.Map<GenreDTO>(genre);
    }
}