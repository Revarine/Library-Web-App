using AutoMapper;
using ErrorOr;
using FluentValidation;
using Library.Application.Common.DTO;
using Library.Application.Common.Interfaces;
using Library.Domain.Entities;
using MediatR;

namespace Library.Application.Authors.Commands.CreateAuthor;

public class CreateAuthorCommandHandler : IRequestHandler<CreateAuthorCommand, ErrorOr<AuthorDTO>>
{
    private readonly IAuthorRepository _authorRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IValidator<AuthorDTO> _validator;

    public CreateAuthorCommandHandler(IAuthorRepository authorRepository, IUnitOfWork unitOfWork, IMapper mapper, IValidator<AuthorDTO> validator)
    {
        _authorRepository = authorRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _validator = validator;
    }

    public async Task<ErrorOr<AuthorDTO>> Handle(CreateAuthorCommand request, CancellationToken cancellationToken)
    {
        var author = new Author(request.id, request.name, request.surname);
        var authorDTO = _mapper.Map<AuthorDTO>(author);

        var validationResult = await _validator.ValidateAsync(authorDTO);
        if (!validationResult.IsValid)
        {
            return Error.Validation("Bad Request: Validation Failure", string.Join("\n", validationResult.Errors.Select(e => e.ErrorMessage)));
        }

        await _authorRepository.CreateAsync(author, cancellationToken);
        await _unitOfWork.CommitChangesAsync();

        return authorDTO;
    }
}