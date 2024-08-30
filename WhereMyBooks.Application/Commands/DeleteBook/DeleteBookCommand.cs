using MediatR;

namespace WhereMyBooks.Application.Commands.DeleteBook;

public class DeleteBookCommand : IRequest
{
    public int Id { get; private set; }

    public DeleteBookCommand(int id)
    {
        Id = id;
    }
}