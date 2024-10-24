using Library.Application.TakenBooks.Commands.CreateTakenBook;
using Library.Application.TakenBooks.Commands.DeleteTakenBook;
using Library.Application.TakenBooks.Queries.GetTakenBooks;
using Library.Contracts.TakenBooks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Library.API.Controllers;

[ApiController]
[Route("[controller]")]
public class TakenBooksController : ControllerBase
{
    private readonly ISender _mediator;

    public TakenBooksController(ISender mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> TakeBook(Guid bookId, Guid userId, DateTime returnTime)
    {
        var command = new CreateTakenBookCommand(bookId, userId, returnTime);

        var takeBookResult = await _mediator.Send(command);

        return takeBookResult.MatchFirst(takenBook => Ok(new TakenBookResponse(takenBook.BookId, takenBook.UserId, takenBook.TakeDate, takenBook.ReturnDate)), error => Problem(error.ToString()));
    }

    [HttpDelete]
    [Authorize(Policy = "AdminPolicy")]
    public async Task<IActionResult> ReturnBook(Guid bookId, Guid userId)
    {
        var command = new DeleteTakenBookCommand(bookId, userId);

        var returnBookResult = await _mediator.Send(command);

        return returnBookResult.MatchFirst<IActionResult>
        (
            _ => NoContent(),
            _ => Problem(_.Description.ToString())
        );
    }

    [HttpGet]
    [Authorize(Policy = "AdminPolicy")]
    public async Task<IActionResult> GetTakenBooks()
    {
        var query = new GetTakenBooksQuery();

        var getTakenBooksResult = await _mediator.Send(query);

        return getTakenBooksResult.MatchFirst(books => Ok(books.ToList()), error => Problem(error.Description.ToString()));
    }
}