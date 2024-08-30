using MediatR;

namespace WhereMyBooks.Application.Commands.DeleteMarkup;

public class DeleteMarkupCommand : IRequest
{
    public int Id { get; private set; }

    public DeleteMarkupCommand(int id)
    {
        Id = id;
    }
}