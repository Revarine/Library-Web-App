using AutoMapper;
using ErrorOr;
using FluentValidation;
using Library.Application.Common.DTO;
using Library.Application.Common.Interfaces;
using Library.Domain.Entities;
using MediatR;

namespace Library.Application.TakenBooks.Commands.CreateTakenBook;

public class CreateTakenBookCommandHandler : IRequestHandler<CreateTakenBookCommand, ErrorOr<TakenBookDTO>>
{
    private readonly ITakenBooksRepository _takenBooksRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateTakenBookCommandHandler(ITakenBooksRepository takenBooksRepository, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _takenBooksRepository = takenBooksRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    public async Task<ErrorOr<TakenBookDTO>> Handle(CreateTakenBookCommand request, CancellationToken cancellationToken)
    {
        var takenbook = new TakenBook(request.bookId, request.userId, DateTime.Now, request.returnTime);

        await _takenBooksRepository.CreateAsync(takenbook, cancellationToken);

        await _unitOfWork.CommitChangesAsync();

        return _mapper.Map<TakenBookDTO>(takenbook);
    }
}
