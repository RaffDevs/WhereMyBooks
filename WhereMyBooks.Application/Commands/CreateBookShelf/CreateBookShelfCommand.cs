using MediatR;

namespace WhereMyBooks.Application.Commands.CreateBookShelf;

public class CreateBookShelfCommand : IRequest<int>
{
    public int IdOwner { get; private set; }

    public CreateBookShelfCommand(int idOwner)
    {
        IdOwner = idOwner;
    }
}