using ErrorOr;
using Library.Application.Common.Interfaces;
using Library.Domain.Entities;
using MediatR;

namespace Library.Application.Books.Queries.GetBooks;

public class GetBooksQueryHandler : IRequestHandler<GetBooksQuery, ErrorOr<List<Book>>>
{
    private readonly IBookRepository _bookRepository;
    public GetBooksQueryHandler(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    public async Task<ErrorOr<List<Book>>> Handle(GetBooksQuery request, CancellationToken cancellationToken)
    {
        var books = await _bookRepository.GetElementsAsync(cancellationToken);

        return books is null
        ? Error.NotFound(description: "There is no books")
        : books.ToList();
    }
}