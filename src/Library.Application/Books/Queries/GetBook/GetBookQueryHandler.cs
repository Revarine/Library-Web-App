using AutoMapper;
using ErrorOr;
using Library.Application.Common.DTO;
using Library.Application.Common.Interfaces;
using Library.Domain.Entities;
using MediatR;

namespace Library.Application.Books.Queries.GetBook;

public class GetBookQueryHandler : IRequestHandler<GetBookQuery, ErrorOr<BookDTO>>
{
    private readonly IBookRepository _bookRepository;
    private readonly IMapper _mapper;

    public GetBookQueryHandler(IBookRepository bookRepository, IMapper mapper)
    {
        _bookRepository = bookRepository;
        _mapper = mapper;
    }
    public async Task<ErrorOr<BookDTO>> Handle(GetBookQuery request, CancellationToken cancellationToken)
    {
        var book = await _bookRepository.GetElementByIdAsync(request.bookId, cancellationToken);
        return book is null
            ? Error.NotFound(description: "Book not found")
            : _mapper.Map<BookDTO>(book);
    }
}