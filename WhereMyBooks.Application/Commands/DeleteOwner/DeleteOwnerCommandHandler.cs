using MediatR;
using WhereMyBooks.Application.Exceptions;
using WhereMyBooks.Core.Repositories;
using WhereMyBooks.Infrastructure.Persistence;

namespace WhereMyBooks.Application.Commands.DeleteOwner;

public class DeleteOwnerCommandHandler : IRequestHandler<DeleteOwnerCommand>
{
    private readonly IOwnerRepository _repository;

    public DeleteOwnerCommandHandler(IOwnerRepository repository)
    {
        _repository = repository;
    }

    public async Task Handle(DeleteOwnerCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var owner = await _repository.GetByIdAsync(request.Id);
            if (owner is null)
            {
                throw new NotFoundException();
            }

            await _repository.DeleteAsync(owner);
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