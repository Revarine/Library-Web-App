using AutoMapper;
using ErrorOr;
using Library.Application.Common.DTO;
using Library.Application.Common.Interfaces;
using MediatR;

namespace Library.Application.TakenBooks.Queries.GetTakenBooks;

public class GetTakenBooksQueryHandler : IRequestHandler<GetTakenBooksQuery, ErrorOr<List<TakenBookDTO>>>
{
    private readonly ITakenBooksRepository _takenBooksRepository;
    private readonly IMapper _mapper;

    public GetTakenBooksQueryHandler(ITakenBooksRepository takenBooksRepository, IMapper mapper)
    {
        _takenBooksRepository = takenBooksRepository;
        _mapper = mapper;
    }

    public async Task<ErrorOr<List<TakenBookDTO>>> Handle(GetTakenBooksQuery request, CancellationToken cancellationToken)
    {
        var books = await _takenBooksRepository.GetElementsAsync(cancellationToken);

        return books is null
        ? Error.NotFound(description: "There is no books")
        : _mapper.Map<List<TakenBookDTO>>(books);
    }
}
