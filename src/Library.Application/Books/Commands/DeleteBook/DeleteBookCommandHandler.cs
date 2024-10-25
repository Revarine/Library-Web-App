using AutoMapper;
using ErrorOr;
using Library.Application.Common.Interfaces;
using MediatR;

namespace Library.Application.Books.Commands.DeleteBook;

public class DeleteBookCommandHandler : IRequestHandler<DeleteBookCommand, ErrorOr<Deleted>>
{
    private readonly IBookRepository _bookRepository;
    private readonly IUnitOfWork _unitOfWork;
    public DeleteBookCommandHandler(IBookRepository bookRepository, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _bookRepository = bookRepository;
        _unitOfWork = unitOfWork;
    }
    public async Task<ErrorOr<Deleted>> Handle(DeleteBookCommand command, CancellationToken cancellationToken)
    {
        var book = await _bookRepository.GetElementByIdAsync(command.bookId);

        if (book == null)
        {
            return Error.NotFound(description: "Book not found");
        }
        await _bookRepository.DeleteAsync(book.Id, cancellationToken);
        await _unitOfWork.CommitChangesAsync();

        return Result.Deleted;
    }
}