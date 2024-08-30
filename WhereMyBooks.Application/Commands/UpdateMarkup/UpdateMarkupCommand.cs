using MediatR;
using WhereMyBooks.Application.Models.InputModels;

namespace WhereMyBooks.Application.Commands.UpdateMarkup;

public class UpdateMarkupCommand : IRequest
{
    public int Id { get; private set; }
    public UpdateMarkupInputModel Model { get; private set; }

    public UpdateMarkupCommand(int id, UpdateMarkupInputModel model)
    {
        Id = id;
        Model = model;
    }
}