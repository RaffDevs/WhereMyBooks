using MediatR;
using WhereMyBooks.Application.Commands.CreateOwner;
using WhereMyBooks.Application.Exceptions;
using WhereMyBooks.Application.Models.Mappers;
using WhereMyBooks.Infrastructure.Persistence;
using WhereMyBooks.Core.Entities;
using WhereMyBooks.Core.Repositories;
using WhereMyBooks.Core.Services;

namespace WhereMyBooks.Application.Commands.CreateOwner;

public class CreateOwnerCommandHandler : IRequestHandler<CreateOwnerCommand, int>
{
    private readonly IOwnerRepository _repository;
    private readonly IAuthService _authService;
    public CreateOwnerCommandHandler(IOwnerRepository repository, IAuthService authService)
    {
        _repository = repository;
        _authService = authService;
    }

    public async Task<int> Handle(CreateOwnerCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var owner = OwnerMapper.MapToOwner(request.Model);
            var hashPassword = _authService.ComputeSha256Hash(owner.Password);
            owner.SetPassword(hashPassword);
            var result = await _repository.CreateAsync(owner);

            return result.Id;
        }
        catch (Exception ex)
        {
            throw new InternalException(ex.Message);
        }
    }
}