using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WhereMyBooks.Application.Commands.CreateShelf;
using WhereMyBooks.Application.Commands.DeleteShelf;
using WhereMyBooks.Application.Commands.UpdateShelf;
using WhereMyBooks.Application.Models.InputModels;
using WhereMyBooks.Application.Queries.GetAllShelves;
using WhereMyBooks.Application.Queries.GetShelfById;

namespace WhereMyBooks.Api.Controllers;

[Route("api/shelfs")]
[Authorize]
public class ShelfsController : ControllerBase
{
    private readonly IMediator _mediator;

    public ShelfsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var query = new GetAllShelvesQuery();
        var shelves = await _mediator.Send(query);
        return Ok(shelves);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var query = new GetShelfByIdQuery(id);
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreateShelfInputModel model)
    {
        var command = new CreateShelfCommand(model);
        var shelfId = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetById), new { id = shelfId }, command);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] UpdateShelfInputModel model)
    {
        var command = new UpdateShelfCommand(id, model);
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var query = new DeleteShelfCommand(id);
        await _mediator.Send(query);
        return NoContent();
    }
}