using AutoMapper;
using ErrorOr;
using Library.Application.Common.DTO;
using Library.Application.Common.Interfaces;
using MediatR;

namespace Library.Application.Books.Queries.GetBookByAuthorId;

public class GetBookByAuthorIdQueryHandler : IRequestHandler<GetBookByAuthorIdQuery, ErrorOr<List<BookDTO>>>
{
    private readonly IBookRepository _bookRepository;
    private readonly IMapper _mapper;

    public async Task<ErrorOr<List<BookDTO>>> Handle(GetBookByAuthorIdQuery request, CancellationToken cancellationToken)
    {
        var books = await _bookRepository.GetBooksByAuthorIdAsync(request.authorId, cancellationToken);

        return books is null
        ? Error.NotFound(description: "There is no books with this author")
        : _mapper.Map<List<BookDTO>>(books);
    }
}