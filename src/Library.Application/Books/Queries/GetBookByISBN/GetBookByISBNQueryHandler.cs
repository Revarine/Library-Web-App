using AutoMapper;
using ErrorOr;
using Library.Application.Common.DTO;
using Library.Application.Common.Interfaces;
using MediatR;

namespace Library.Application.Books.Queries.GetBookByISBN;

public class GetBookByISBNQueryHandler : IRequestHandler<GetBookByISBNQuery, ErrorOr<BookDTO>>
{
    private readonly IBookRepository _bookRepository;
    private readonly IMapper _mapper;

    public GetBookByISBNQueryHandler(IBookRepository bookRepository, IMapper mapper)
    {
        _bookRepository = bookRepository;
        _mapper = mapper;
    }
    public async Task<ErrorOr<BookDTO>> Handle(GetBookByISBNQuery request, CancellationToken cancellationToken)
    {
        var book = await _bookRepository.GetElementByISBNAsync(request.ISBN, cancellationToken);

        return book is null
        ? Error.NotFound(description: "Book not found")
        : _mapper.Map<BookDTO>(book);
    }
}