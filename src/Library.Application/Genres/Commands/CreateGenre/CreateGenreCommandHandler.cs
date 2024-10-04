using ErrorOr;
using Library.Application.Common.Interfaces;
using Library.Domain.Entities;
using MediatR;

namespace Library.Application.Genres.Commands.CreateGenre;

public class CreateGenreCommandHandler : IRequestHandler<CreateGenreCommand, ErrorOr<Genre>>
{
    private readonly IGenreRepository _genreRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateGenreCommandHandler(IGenreRepository genreRepository, IUnitOfWork unitOfWork)
    {
        _genreRepository = genreRepository;
        _unitOfWork = unitOfWork;
    }
    public async Task<ErrorOr<Genre>> Handle(CreateGenreCommand request, CancellationToken cancellationToken)
    {
        var genre = new Genre(request.id, request.name);

        await _genreRepository.CreateAsync(genre);
        await _unitOfWork.CommitChangesAsync();

        return genre;
    }
}