using MediatR;

namespace WhereMyBooks.Application.Commands.DeleteShelf;

public class DeleteShelfCommand : IRequest
{
    public int Id { get; private set; }

    public DeleteShelfCommand(int id)
    {
        Id = id;
    }
}