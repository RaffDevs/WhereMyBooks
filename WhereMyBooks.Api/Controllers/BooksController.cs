using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WhereMyBooks.Application.Commands.CreateBook;
using WhereMyBooks.Application.Commands.CreateBookShelf;
using WhereMyBooks.Application.Commands.DeleteBook;
using WhereMyBooks.Application.Commands.UpdateBook;
using WhereMyBooks.Application.Models.InputModels;
using WhereMyBooks.Application.Queries.GetAllBooks;
using WhereMyBooks.Application.Queries.GetBookById;

namespace WhereMyBooks.Api.Controllers;

[Route("api/books")]
[Authorize]
public class BooksController : ControllerBase
{
    private readonly IMediator _mediator;

    public BooksController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("book/shelf/{idShelf}")]
    public async Task<IActionResult> Get(int idShelf)
    {
        var query = new GetAllBooksQuery(idShelf);
        var books = await _mediator.Send(query);
        return Ok(books);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var query = new GetBookByIdQuery(id);
        var book = await _mediator.Send(query);
        return Ok(book);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateBookInputModel model)
    {
        var command = new CreateBookCommand(model);
        var bookId = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetById), new { id = bookId }, command);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] UpdateBookInputModel model)
    {
        var command = new UpdateBookCommand(id, model);
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var query = new DeleteBookCommand(id);
        await _mediator.Send(query);
        return NoContent();
    }
}