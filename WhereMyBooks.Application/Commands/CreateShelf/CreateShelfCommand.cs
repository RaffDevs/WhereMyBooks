using MediatR;
using WhereMyBooks.Application.Models.InputModels;

namespace WhereMyBooks.Application.Commands.CreateShelf;

public class CreateShelfCommand : IRequest<int>
{
   public CreateShelfInputModel Model { get; private set; }

   public CreateShelfCommand(CreateShelfInputModel model)
   {
      Model = model;
   }
}