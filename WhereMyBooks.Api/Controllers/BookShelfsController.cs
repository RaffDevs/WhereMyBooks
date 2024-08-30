using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WhereMyBooks.Application.Commands.DeleteBookShelf;
using WhereMyBooks.Application.Queries.GetBookShelfById;

namespace WhereMyBooks.Api.Controllers;

[Route("api/bookshelfs")]
[Authorize]
public class BookShelfsController : ControllerBase
{
    private readonly IMediator _mediator;

    public BookShelfsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{id}")]

    public async Task<IActionResult> GetById(int id, int ownerId)
    {
        var query = new GetBookShelfByIdQuery(id, ownerId);
        var bookShelf = await _mediator.Send(query);
        return Ok(bookShelf);
    }
    

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var query = new DeleteBookShelfCommand(id);
        await _mediator.Send(query);
        return NoContent();
    }
}