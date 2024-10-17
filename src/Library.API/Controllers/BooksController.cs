using ErrorOr;
using Library.Application.Books.Commands.CreateBook;
using Library.Application.Books.Commands.DeleteBook;
using Library.Application.Books.Queries.GetBook;
using Library.Application.Books.Queries.GetBooks;
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

    [HttpGet("{bookId:guid}")]
    public async Task<IActionResult> GetBook(Guid bookId)
    {
        var query = new GetBookQuery(bookId);

        var getBookResult = await _mediator.Send(query);

        return getBookResult.MatchFirst(book => Ok(new BookResponse(book.Id, book.Title, book.Description, book.GenreId, book.AuthorId, book.ISBN, book.Amount)), Error => Problem());
    }

    [HttpGet]
    public async Task<IActionResult> GetBooks()
    {
        var query = new GetBooksQuery();

        var getBooksResult = await _mediator.Send(query);

        return getBooksResult.MatchFirst(books => Ok(books.ToList()), Error => Problem());
    }

    [HttpDelete("{bookId:guid}")]
    public async Task<IActionResult> DeleteBook(Guid bookId)
    {
        var query = new DeleteBookCommand(bookId);

        var deleteBookResult = await _mediator.Send(query);

        return deleteBookResult.MatchFirst<IActionResult>(
            _ => NoContent(),
            _ => Problem()
        );
    }


    [HttpGet("BookImage")]
    public async Task<IActionResult> GetBookImage(Guid bookId)
    {
        var fileName = bookId.ToString();
        var filePath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\images", fileName + ".jpg");
        Console.WriteLine($"Path: {filePath}");
        if (!System.IO.File.Exists(filePath))
        {
            Console.WriteLine("File not found!!");
            return NotFound();
        }
        return new FileStreamResult(new FileStream(filePath, FileMode.Open), "image/jpeg");
    }

    [HttpPost("AddBookImage")]
    public async Task<IActionResult> AddBookImage(Guid bookId, IFormFile image)
    {
        if (image != null && image.Length > 0)
        {
            var fileName = bookId.ToString();
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\images", fileName + ".jpg");

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await image.CopyToAsync(fileStream);
            }
            return Ok();
        }
        return Problem();
    }
}