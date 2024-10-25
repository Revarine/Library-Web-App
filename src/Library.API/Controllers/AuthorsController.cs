using ErrorOr;
using Library.Application.Authors.Commands.CreateAuthor;
using Library.Application.Authors.Commands.DeleteAuthor;
using Library.Application.Authors.Commands.UpdateAuthor;
using Library.Application.Authors.Queries;
using Library.Contracts.Authors;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Library.API.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthorsController : ControllerBase
{
    private readonly ISender _mediator;

    public AuthorsController(ISender mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    [Authorize(Policy = "AdminPolicy")]
    public async Task<IActionResult> CreateAuthor(CreateAuthorRequest request)
    {
        var command = new CreateAuthorCommand(request.dateOfBirth, request.country, request.name, request.surname);

        var createAuthorResult = await _mediator.Send(command);

        return createAuthorResult.MatchFirst(author => Ok(new AuthorResponse(author.Id, author.DateOfBirth, author.Country, author.Name, author.Surname)), error => Problem());
    }

    [HttpGet("{authorId:guid}")]
    public async Task<IActionResult> GetAuthor(Guid authorId)
    {
        var query = new GetAuthorQuery(authorId);

        var getAuthorResult = await _mediator.Send(query);

        return getAuthorResult.MatchFirst(author => Ok(new AuthorResponse(author.Id, author.DateOfBirth, author.Country, author.Name, author.Surname)), error => Problem());
    }

    [HttpDelete("{authorId:guid}")]
    [Authorize(Policy = "AdminPolicy")]
    public async Task<IActionResult> DeleteAuthor(Guid authorId)
    {
        var command = new DeleteAuthorCommand(authorId);

        var deleteAuthorResult = await _mediator.Send(command);

        return deleteAuthorResult.MatchFirst<IActionResult>(
            _ => NoContent(),
            _ => Problem(_.ToString())
        );
    }

    [HttpPut]
    [Authorize(Policy = "AdminPolicy")]
    public async Task<IActionResult> UpdateAuthor(UpdateAuthorRequest request)
    {
        var command = new UpdateAuthorCommand(request.id, request.dateOfBirth, request.country, request.name, request.surname);

        var updateAuthorResult = await _mediator.Send(command);

        return updateAuthorResult.MatchFirst<IActionResult>(
            _ => NoContent(),
            _ => Problem(_.ToString())
        );
    }

    [HttpGet("{authorId:Guid}/Books")]
    public async Task<IActionResult> GetBooksByAuthorId(Guid authorId)
    {
        var query = new GetBookByAuthorIdQuery(authorId);

        var getBookByAuthorIdResult = await _mediator.Send(query);

        return getBookByAuthorIdResult.MatchFirst(books => Ok(books.ToList()), error => Problem());
    }
}