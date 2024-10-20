using ErrorOr;
using Library.Application.Authors.Commands.CreateAuthor;
using Library.Application.Authors.Commands.DeleteAuthor;
using Library.Application.Authors.Commands.UpdateAuthor;
using Library.Application.Authors.Queries;
using Library.Contracts.Authors;
using MediatR;
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
    public async Task<IActionResult> CreateAuthor(CreateAuthorRequest request)
    {
        var command = new CreateAuthorCommand(request.name, request.surname);

        var createAuthorResult = await _mediator.Send(command);

        return createAuthorResult.MatchFirst(author => Ok(new AuthorResponse(author.Id, author.Name, author.Surname)), error => Problem());
    }

    [HttpGet("{authorId:guid}")]
    public async Task<IActionResult> GetAuthor(Guid authorId)
    {
        var query = new GetAuthorQuery(authorId);

        var getAuthorResult = await _mediator.Send(query);

        return getAuthorResult.MatchFirst(author => Ok(new AuthorResponse(author.Id, author.Name, author.Surname)), error => Problem());
    }

    [HttpDelete("{authorId:guid}")]
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
    public async Task<IActionResult> UpdateAuthor(UpdateAuthorRequest request)
    {
        var command = new UpdateAuthorCommand(request.id, request.name, request.surname);

        var updateAuthorResult = await _mediator.Send(command);

        return updateAuthorResult.MatchFirst<IActionResult>(
            _ => NoContent(),
            _ => Problem(_.ToString())
        );
    }

}