using AutoMapper;
using ErrorOr;
using Library.Application.Common.DTO.Books;
using Library.Application.Common.Interfaces;
using MediatR;

namespace Library.Application.Authors.Queries;

public class GetAuthorQueryHandler : IRequestHandler<GetAuthorQuery, ErrorOr<AuthorDTO>>
{
    private readonly IAuthorRepository _authorRepository;
    private readonly IMapper _mapper;

    public GetAuthorQueryHandler(IAuthorRepository authorRepository, IMapper mapper)
    {
        _authorRepository = authorRepository;
        _mapper = mapper;
    }
    public async Task<ErrorOr<AuthorDTO>> Handle(GetAuthorQuery request, CancellationToken cancellationToken)
    {
        var author = await _authorRepository.GetElementByIdAsync(request.authorId, cancellationToken);
        return author is null
        ? Error.NotFound(description: "Author not found")
        : _mapper.Map<AuthorDTO>(author);
    }
}