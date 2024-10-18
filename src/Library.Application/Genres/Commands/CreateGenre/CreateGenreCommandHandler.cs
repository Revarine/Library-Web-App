using System.ComponentModel.DataAnnotations;
using System.Text;
using AutoMapper;
using ErrorOr;
using FluentValidation;
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

    private readonly IValidator<GenreDTO> _validator;

    public CreateGenreCommandHandler(IGenreRepository genreRepository, IUnitOfWork unitOfWork, IMapper mapper, IValidator<GenreDTO> validator)
    {
        _genreRepository = genreRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _validator = validator;
    }
    public async Task<ErrorOr<GenreDTO>> Handle(CreateGenreCommand request, CancellationToken cancellationToken)
    {

        var genre = new Genre(request.id, request.name);
        var genreDTO = _mapper.Map<GenreDTO>(genre);
        var validationResult = await _validator.ValidateAsync(genreDTO);
        if (!validationResult.IsValid)
        {
            return Error.Validation("Bad Request: Validation Failure", string.Join("\n", validationResult.Errors.Select(e => e.ErrorMessage)));
        }
        await _genreRepository.CreateAsync(genre);
        await _unitOfWork.CommitChangesAsync();

        return _mapper.Map<GenreDTO>(genre);
    }
}