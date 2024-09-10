using MediatR;
using WhereMyBooks.Application.Exceptions;
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

        try
        {
            var owner = await _repository.GetByIdAsync(request.Id);
            if (owner is null)
            {
                throw new NotFoundException();
            }

            owner.SetEmail(request.Model.Email);
            owner.SetFullName(request.Model.FullName);
            await _repository.UpdateAsync(owner);
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
