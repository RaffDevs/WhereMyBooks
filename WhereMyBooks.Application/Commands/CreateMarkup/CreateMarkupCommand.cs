using MediatR;
using WhereMyBooks.Application.Models.InputModels;

namespace WhereMyBooks.Application.Commands.CreateMarkup;

public class CreateMarkupCommand : IRequest<int>
{
    public CreateMarkupInputModel Model { get; private set; }

    public CreateMarkupCommand(CreateMarkupInputModel model)
    {
        Model = model;
    }
}