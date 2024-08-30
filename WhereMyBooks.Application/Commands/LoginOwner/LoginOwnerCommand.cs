using MediatR;
using WhereMyBooks.Application.Models.InputModels;
using WhereMyBooks.Application.Models.ViewModels;

namespace WhereMyBooks.Application.Commands.LoginOwner;

public class LoginOwnerCommand : IRequest<LoginViewModel>
{
    public LoginInputModel Model { get; private set; }

    public LoginOwnerCommand(LoginInputModel model)
    {
        Model = model;
    }
}