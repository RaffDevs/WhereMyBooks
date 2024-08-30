using MediatR;
using WhereMyBooks.Application.Models.InputModels;

namespace WhereMyBooks.Application.Commands.UpdateShelf;

public class UpdateShelfCommand : IRequest
{
    public int Id { get; private set; }
    public UpdateShelfInputModel Model { get; private set;  }

    public UpdateShelfCommand(int id, UpdateShelfInputModel model)
    {
        Id = id;
        Model = model;
    }
}