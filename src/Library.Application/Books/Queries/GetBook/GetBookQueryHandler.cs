using ErrorOr;
using Library.Application.Common.Interfaces;
using Library.Domain.Entities;
using MediatR;

namespace Library.Application.Books.Queries.GetBook;

public class GetBookQueryHandler : IRequestHandler<GetBookQuery, ErrorOr<Book>>
{
    private readonly IBookRepository _bookRepository;

    public GetBookQueryHandler(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }
    public async Task<ErrorOr<Book>> Handle(GetBookQuery request, CancellationToken cancellationToken)
    {
        var book = await _bookRepository.GetElementByIdAsync(request.bookId, cancellationToken);
        return book is null
            ? Error.NotFound(description: "Book not found")
            : book;
    }
}