using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WhereMyBooks.Application.Commands.CreateMarkup;
using WhereMyBooks.Application.Commands.DeleteMarkup;
using WhereMyBooks.Application.Commands.UpdateMarkup;
using WhereMyBooks.Application.Models.InputModels;
using WhereMyBooks.Application.Queries.GetAllMarkups;
using WhereMyBooks.Application.Queries.GetMarkupById;

namespace WhereMyBooks.Api.Controllers;

[Route("api/markups")]
[Authorize]
public class MarkupsController : ControllerBase
{
    private readonly IMediator _mediator;

    public MarkupsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("book/{idBook}")]
    public async Task<IActionResult> Get(int idBook)
    {
        var query = new GetAllMarkupsQuery(idBook);
        var markups = await _mediator.Send(query);
        return Ok(markups);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var query = new GetMarkupByIdQuery(id);
        var markup = await _mediator.Send(query);
        return Ok(markup);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreateMarkupInputModel model)
    {
        var command = new CreateMarkupCommand(model);
        var markupId = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetById), new { id = markupId }, command);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] UpdateMarkupInputModel model)
    {
        var command = new UpdateMarkupCommand(id, model);
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var query = new DeleteMarkupCommand(id);
        await _mediator.Send(query);
        return NoContent();
    }

}