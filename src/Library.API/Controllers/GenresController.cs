using Library.Application.Genres.Commands.CreateGenre;
using Library.Application.Genres.Commands.DeleteGenre;
using Library.Application.Genres.Queries.GetGenre;
using Library.Contracts.Genres;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Library.API.Controllers;

[ApiController]
[Route("[controller]")]
public class GenresController : ControllerBase
{
    private readonly ISender _mediator;

    public GenresController(ISender mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> CreateGenre(CreateGenreRequest genreRequest)
    {
        var command = new CreateGenreCommand(genreRequest.name);

        var createGenreResult = await _mediator.Send(command);

        return createGenreResult.MatchFirst(genre => Ok(new GenreResponse(genre.Id, genre.Name)), error => Problem());
    }

    [HttpGet("{genreId:int}")]
    public async Task<IActionResult> GetGenre(short genreId)
    {
        var query = new GetGenreQuery(genreId);

        var getGenreResult = await _mediator.Send(query);

        return getGenreResult.MatchFirst(genre => Ok(new GenreResponse(genre.Id, genre.Name)), error => Problem());
    }

    [HttpDelete("{genreId:int}")]
    public async Task<IActionResult> DeleteGenre(short genreId)
    {
        var command = new DeleteGenreCommand(genreId);

        var deleteGenreResult = await _mediator.Send(command);

        return deleteGenreResult.MatchFirst<IActionResult>(
            _ => NoContent(),
            _ => Problem()
        );
    }
}