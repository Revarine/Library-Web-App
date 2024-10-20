using AutoMapper;
using ErrorOr;
using FluentValidation;
using Library.Application.Common.DTO;
using Library.Application.Common.Interfaces;
using Library.Domain.Entities;
using MediatR;

namespace Library.Application.Genres.Commands.UpdateGenre;

public class UpdateGenreCommandHandler : IRequestHandler<UpdateGenreCommand, ErrorOr<Updated>>
{
    private readonly IGenreRepository _genreRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IValidator<GenreDTO> _validator;
    public UpdateGenreCommandHandler(IGenreRepository genreRepository, IUnitOfWork unitOfWork, IMapper mapper, IValidator<GenreDTO> validator)
    {
        _genreRepository = genreRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _validator = validator;
    }
    public async Task<ErrorOr<Updated>> Handle(UpdateGenreCommand request, CancellationToken cancellationToken)
    {
        var genre = await _genreRepository.GetElementByIdAsync(request.genreId, cancellationToken); // maybe I need to use DTO in commands instead

        if (genre == null) Error.NotFound("Genre to update not found");

        var genreDTO = _mapper.Map<GenreDTO>(new Genre(request.genreId, request.genreName));
        var validationResult = await _validator.ValidateAsync(genreDTO, cancellationToken);

        if (!validationResult.IsValid)
        {
            return Error.Validation("Bad Request: Validation Failure", string.Join("\n", validationResult.Errors.Select(e => e.ErrorMessage)));
        }

        await _genreRepository.UpdateAsync(request.genreId, request.genreName);
        await _unitOfWork.CommitChangesAsync();

        return Result.Updated;
    }
}