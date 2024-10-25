using AutoMapper;
using ErrorOr;
using Library.Application.Common.Interfaces;
using MediatR;

namespace Library.Application.TakenBooks.Commands.DeleteTakenBook;

public class DeleteTakenBookCommandHandler : IRequestHandler<DeleteTakenBookCommand, ErrorOr<Deleted>>
{
    private readonly ITakenBooksRepository _takenBooksRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public DeleteTakenBookCommandHandler(ITakenBooksRepository takenBooksRepository, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _takenBooksRepository = takenBooksRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    public async Task<ErrorOr<Deleted>> Handle(DeleteTakenBookCommand request, CancellationToken cancellationToken)
    {
        var takenbook = await _takenBooksRepository.GetElementByIdAsync(request.bookId, request.userId, cancellationToken);

        if (takenbook == null) Error.NotFound("No such book for this user");

        await _takenBooksRepository.DeleteAsync(request.bookId, request.userId, cancellationToken);
        await _unitOfWork.CommitChangesAsync();

        return Result.Deleted;
    }
}