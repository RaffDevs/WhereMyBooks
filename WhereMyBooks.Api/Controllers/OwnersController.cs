using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WhereMyBooks.Application.Commands.CreateBookShelf;
using WhereMyBooks.Application.Commands.CreateOwner;
using WhereMyBooks.Application.Commands.DeleteOwner;
using WhereMyBooks.Application.Commands.LoginOwner;
using WhereMyBooks.Application.Commands.UpdateOwner;
using WhereMyBooks.Application.Models.InputModels;
using WhereMyBooks.Application.Queries.GetOwnerById;

namespace WhereMyBooks.Api.Controllers;

[Route("api/owners")]
public class OwnersController : ControllerBase
{
    private readonly IMediator _mediator;

    public OwnersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var query = new GetOwnerByIdQuery(id);
        var owner = await _mediator.Send(query);
        
        return Ok(owner);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateOwnerInputModel model)
    {
        var command = new CreateOwnerCommand(model);
        var ownerId = await _mediator.Send(command);
        var createBookShelfCommand = new CreateBookShelfCommand(ownerId);
        await _mediator.Send(createBookShelfCommand);
        return CreatedAtAction(nameof(GetById), new { id = ownerId }, model);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateOwnerInputModel model)
    {
        var command = new UpdateOwnerCommand(id, model);
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var query = new DeleteOwnerCommand(id);
        await _mediator.Send(query);
        return NoContent();
    }
    
}