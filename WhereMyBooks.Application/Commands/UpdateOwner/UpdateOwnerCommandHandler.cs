using MediatR;
using WhereMyBooks.Core.Repositories;
using WhereMyBooks.Infrastructure.Persistence;

namespace WhereMyBooks.Application.Commands.UpdateOwner;

public class UpdateOwnerCommandHandler : IRequestHandler<UpdateOwnerCommand>
{
    private readonly IOwnerRepository _repository;

    public UpdateOwnerCommandHandler(IOwnerRepository repository)
    {
        _repository = repository;
    }

    public async Task Handle(UpdateOwnerCommand request, CancellationToken cancellationToken)
    {

        var owner = await _repository.GetByIdAsync(request.Id);
        if (owner is null)
        {
            throw new NotImplementedException();
        }
        
        owner.SetEmail(request.Model.Email);
        owner.SetFullName(request.Model.FullName);
        await _repository.UpdateAsync(owner);
    }
}
