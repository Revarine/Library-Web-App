using ErrorOr;
using Library.Application.Common.Interfaces;
using Library.Domain.Entities;
using MediatR;

namespace Library.Application.Authors.Queries;

public class GetAuthorQueryHandler : IRequestHandler<GetAuthorQuery, ErrorOr<Author>>
{
    private readonly IAuthorRepository _authorRepository;

    public GetAuthorQueryHandler(IAuthorRepository authorRepository)
    {
        _authorRepository = authorRepository;
    }
    public async Task<ErrorOr<Author>> Handle(GetAuthorQuery request, CancellationToken cancellationToken)
    {
        var author = await _authorRepository.GetElementByIdAsync(request.authorId, cancellationToken);
        return author is null
        ? Error.NotFound(description: "Author not found")
        : author;
    }
}