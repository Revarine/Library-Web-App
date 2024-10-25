using ErrorOr;
using Library.Application.Common.Interfaces;
using MediatR;

namespace Library.Application.Genres.Commands.DeleteGenre;

public class DeleteGenreCommandHandler : IRequestHandler<DeleteGenreCommand, ErrorOr<Deleted>>
{
    private readonly IGenreRepository _genreRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteGenreCommandHandler(IGenreRepository genreRepository, IUnitOfWork unitOfWork)
    {
        _genreRepository = genreRepository;
        _unitOfWork = unitOfWork;
    }
    public async Task<ErrorOr<Deleted>> Handle(DeleteGenreCommand request, CancellationToken cancellationToken)
    {
        var genre = await _genreRepository.GetElementByIdAsync(request.genreId, cancellationToken);

        if (genre == null) Error.NotFound("Genre not found");

        await _genreRepository.DeleteAsync(request.genreId, cancellationToken);
        await _unitOfWork.CommitChangesAsync();

        return Result.Deleted;
    }
}
