using MediatR;
using WhereMyBooks.Application.Models.InputModels;

namespace WhereMyBooks.Application.Commands.UpdateBook;

public class UpdateBookCommand : IRequest
{
    public int Id { get; private set; }
    public UpdateBookInputModel Model { get; private set; }

    public UpdateBookCommand(int id, UpdateBookInputModel model)
    {
        Id = id;
        Model = model;
    }
}