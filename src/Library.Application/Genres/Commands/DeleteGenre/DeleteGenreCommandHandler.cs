using ErrorOr;
using Library.Application.Common.Interfaces;
using MediatR;

namespace Library.Application.Genres.Commands.DeleteGenre;

public class DeleteGenreCommandHandler : IRequestHandler<DeleteGenreCommand, ErrorOr<Deleted>>
{
    private readonly IGenreRepository _genreRepository;

    public DeleteGenreCommandHandler(IGenreRepository genreRepository)
    {
        _genreRepository = genreRepository;
    }
    public async Task<ErrorOr<Deleted>> Handle(DeleteGenreCommand request, CancellationToken cancellationToken)
    {
        var genre = await _genreRepository.GetElementByIdAsync(request.genreId, cancellationToken);

        if (genre == null) Error.NotFound("Genre not found");

        await _genreRepository.DeleteAsync(request.genreId, cancellationToken);

        return Result.Deleted;
    }
}
