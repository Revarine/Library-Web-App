using ErrorOr;
using Library.Application.Common.Interfaces;
using MediatR;

namespace Library.Application.Books.Commands.DeleteBook;

public class DeleteBookCommandHandler : IRequestHandler<DeleteBookCommand, ErrorOr<Deleted>>
{
    private readonly IBookRepository _bookRepository;
    private readonly ITakenBooksRepository _takenBooksRepository;
    public DeleteBookCommandHandler(IBookRepository bookRepository, ITakenBooksRepository takenBooksRepository)
    {
        _bookRepository = bookRepository;
        _takenBooksRepository = takenBooksRepository;
    }
    public async Task<ErrorOr<Deleted>> Handle(DeleteBookCommand command, CancellationToken cancellationToken)
    {
        var book = await _bookRepository.GetElementByIdAsync(command.bookId);

        if (book == null)
        {
            return Error.NotFound(description: "Book not found");
        }
        await _bookRepository.DeleteAsync(book.Id, cancellationToken);

        return Result.Deleted;
    }
}