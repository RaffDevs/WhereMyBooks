using MediatR;

namespace WhereMyBooks.Application.Commands.DeleteBookShelf;

public class DeleteBookShelfCommand : IRequest
{
    public int Id { get; private set; }

    public DeleteBookShelfCommand(int id)
    {
        Id = id;
    }
}