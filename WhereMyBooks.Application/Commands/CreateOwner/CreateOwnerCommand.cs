using MediatR;
using WhereMyBooks.Application.Models.InputModels;

namespace WhereMyBooks.Application.Commands.CreateOwner;

public class CreateOwnerCommand : IRequest<int>
{
    public CreateOwnerInputModel Model { get; private set; }

    public CreateOwnerCommand(CreateOwnerInputModel model)
    {
        Model = model;
    }
}