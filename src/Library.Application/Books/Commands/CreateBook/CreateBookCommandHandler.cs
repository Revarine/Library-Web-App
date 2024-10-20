using AutoMapper;
using ErrorOr;
using Library.Application.Common.DTO;
using Library.Application.Common.Interfaces;
using Library.Domain.Entities;
using MediatR;

namespace Library.Application.Books.Commands.CreateBook;

public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, ErrorOr<BookDTO>>
{
    private readonly IBookRepository _bookRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateBookCommandHandler(IBookRepository bookRepository, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _bookRepository = bookRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    public async Task<ErrorOr<BookDTO>> Handle(CreateBookCommand request, CancellationToken cancellationToken)
    {
        var book = new Book(request.id, request.title, request.description, request.genreId, request.authorId, request.isbn, request.amount);

        await _bookRepository.CreateAsync(book);
        await _unitOfWork.CommitChangesAsync();

        return _mapper.Map<BookDTO>(book);
    }
}