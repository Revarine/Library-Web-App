using AutoMapper;
using ErrorOr;
using Library.Application.Common.DTO.Books;
using Library.Application.Common.Interfaces;
using Library.Domain.Entities;
using MediatR;

namespace Library.Application.Authors.Commands.CreateAuthor;

public class CreateAuthorCommandHandler : IRequestHandler<CreateAuthorCommand, ErrorOr<AuthorDTO>>
{
    private readonly IAuthorRepository _authorRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateAuthorCommandHandler(IAuthorRepository authorRepository, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _authorRepository = authorRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<ErrorOr<AuthorDTO>> Handle(CreateAuthorCommand request, CancellationToken cancellationToken)
    {
        var author = new Author(request.id, request.name, request.surname);

        await _authorRepository.CreateAsync(author, cancellationToken);
        await _unitOfWork.CommitChangesAsync();

        return _mapper.Map<AuthorDTO>(author);
    }
}