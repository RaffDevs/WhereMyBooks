using MediatR;
using WhereMyBooks.Application.Models.InputModels;

namespace WhereMyBooks.Application.Commands.UpdateOwner;

public class UpdateOwnerCommand : IRequest
{
    public int Id { get; private set; }
    public UpdateOwnerInputModel Model { get; private set; }

    public UpdateOwnerCommand(int id, UpdateOwnerInputModel model)
    {
        Id = id;
        Model = model;
    }
}