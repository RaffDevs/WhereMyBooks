using MediatR;
using WhereMyBooks.Application.Exceptions;
using WhereMyBooks.Application.Models.Mappers;
using WhereMyBooks.Application.Models.ViewModels;
using WhereMyBooks.Core.Repositories;
using WhereMyBooks.Core.Services;

namespace WhereMyBooks.Application.Commands.LoginOwner;

public class LoginOwnerCommandHandler : IRequestHandler<LoginOwnerCommand, LoginViewModel>
{
    private readonly IAuthService _authService;
    private readonly IOwnerRepository _ownerRepository;

    public LoginOwnerCommandHandler(IAuthService authService, IOwnerRepository ownerRepository)
    {
        _authService = authService;
        _ownerRepository = ownerRepository;
    }

    public async Task<LoginViewModel> Handle(LoginOwnerCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var passwordHash = _authService.ComputeSha256Hash(request.Model.Password);
            var owner = await _ownerRepository
                .GetByEmailAndPasswordAsync(request.Model.Email, passwordHash);

            if (owner is null)
            {
                throw new NotFoundException("Nenhum usuario encontrado para este login!");
            }

            var token = _authService.GenerateJwtToken(request.Model.Email, passwordHash);
            return LoginMapper.MapToLoginViewModel(owner.Email, token);
        }
        catch (NotFoundException ex)
        {
            throw;
        }
        catch (Exception ex)
        {
            throw new InternalException(ex.Message);
        }
    }
}