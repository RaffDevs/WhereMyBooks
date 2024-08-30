using MediatR;

namespace WhereMyBooks.Application.Commands.DeleteOwner;

public class DeleteOwnerCommand : IRequest
{
    public int Id { get; private set; }

    public DeleteOwnerCommand(int id)
    {
        Id = id;
    }
}