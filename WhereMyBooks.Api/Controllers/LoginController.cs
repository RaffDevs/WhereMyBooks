using MediatR;
using Microsoft.AspNetCore.Mvc;
using WhereMyBooks.Application.Commands.LoginOwner;
using WhereMyBooks.Application.Models.InputModels;

namespace WhereMyBooks.Api.Controllers;

[Route("api/login")]
public class LoginController : ControllerBase
{
    private readonly IMediator _mediator;

    public LoginController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPut]
    public async Task<IActionResult> Login([FromBody] LoginInputModel model)
    {
        var command = new LoginOwnerCommand(model);
        var owner = await _mediator.Send(command);
        return Ok(owner);
    }
}