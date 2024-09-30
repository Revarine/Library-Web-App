using Library.Application.Books.Commands.CreateBook;
using Library.Contracts.Books;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Library.API.Controllers;

[ApiController]
[Route("[controller]")]
public class BooksController : ControllerBase
{
    private readonly ISender _mediator;

    public BooksController(ISender mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> CreateBook(CreateBookRequest request)
    {
        var command = new CreateBookCommand(request.title, request.description, request.genreId, request.authorId, request.isbn, request.amount);

        var createBookResult = await _mediator.Send(command);

        return createBookResult.MatchFirst(book => Ok(new BookResponse(book.Id, book.Title, book.Description, book.GenreId, book.AuthorId, book.ISBN, book.Amount)), error => Problem());
    }
}