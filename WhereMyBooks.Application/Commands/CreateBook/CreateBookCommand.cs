using MediatR;
using WhereMyBooks.Application.Models.InputModels;

namespace WhereMyBooks.Application.Commands.CreateBook;

public class CreateBookCommand : IRequest<int>
{
    public CreateBookInputModel Model { get; private set; }

    public CreateBookCommand(CreateBookInputModel model)
    {
        Model = model;
    }
}