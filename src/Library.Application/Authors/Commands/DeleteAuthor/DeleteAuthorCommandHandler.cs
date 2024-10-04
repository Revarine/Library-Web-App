using ErrorOr;
using Library.Application.Common.Interfaces;
using Library.Domain.Entities;
using MediatR;

namespace Library.Application.Authors.Commands.DeleteAuthor;

public class DeleteAuthorCommandHandler : IRequestHandler<DeleteAuthorCommand, ErrorOr<Deleted>>
{
    private readonly IAuthorRepository _authorRepository;

    public DeleteAuthorCommandHandler(IAuthorRepository authorRepository)
    {
        _authorRepository = authorRepository;
    }
    public async Task<ErrorOr<Deleted>> Handle(DeleteAuthorCommand request, CancellationToken cancellationToken)
    {
        var author = _authorRepository.GetElementByIdAsync(request.authorId, cancellationToken);

        if (author == null)
        {
            return Error.NotFound(description: "Author not found");
        }

        await _authorRepository.DeleteAsync(request.authorId);

        return Result.Deleted;
    }
}