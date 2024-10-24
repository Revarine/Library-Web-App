using AutoMapper;
using ErrorOr;
using FluentValidation;
using Library.Application.Common.DTO;
using Library.Application.Common.Interfaces;
using Library.Domain.Entities;
using MediatR;

namespace Library.Application.Authors.Commands.UpdateAuthor;

public class UpdateAuthorCommandHandler : IRequestHandler<UpdateAuthorCommand, ErrorOr<Updated>>
{
    private readonly IAuthorRepository _authorRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IValidator<AuthorDTO> _validator;
    private readonly IMapper _mapper;
    public UpdateAuthorCommandHandler(IAuthorRepository authorRepository, IUnitOfWork unitOfWork, IValidator<AuthorDTO> validator, IMapper mapper)
    {
        _authorRepository = authorRepository;
        _unitOfWork = unitOfWork;
        _validator = validator;
        _mapper = mapper;
    }
    public async Task<ErrorOr<Updated>> Handle(UpdateAuthorCommand request, CancellationToken cancellationToken)
    {
        var author = _authorRepository.GetElementByIdAsync(request.authorId);

        if (author == null) Error.NotFound("Author not found");
        var newAuthor = new Author(request.authorId, request.dateOfBirth, request.country, request.authorName, request.authorSurname);
        var authorDTO = _mapper.Map<AuthorDTO>(newAuthor);
        var validationResult = await _validator.ValidateAsync(authorDTO);

        if (!validationResult.IsValid)
        {
            return Error.Validation("Bad Request: Validation Failure", string.Join("\n", validationResult.Errors.Select(e => e.ErrorMessage)));
        }

        await _authorRepository.UpdateAsync(request.authorId, newAuthor);
        await _unitOfWork.CommitChangesAsync();

        return Result.Updated;
    }
}