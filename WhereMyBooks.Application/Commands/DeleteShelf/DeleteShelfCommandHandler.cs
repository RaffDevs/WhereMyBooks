using MediatR;
using WhereMyBooks.Application.Exceptions;
using WhereMyBooks.Core.Repositories;
using WhereMyBooks.Infrastructure.Persistence;

namespace WhereMyBooks.Application.Commands.DeleteShelf;

public class DeleteShelfCommandHandler : IRequestHandler<DeleteShelfCommand>
{
    private readonly IShelfRepository _repository;

    public DeleteShelfCommandHandler(IShelfRepository repository)
    {
        _repository = repository;
    }

    public async Task Handle(DeleteShelfCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var shelf = await _repository.GetByIdAsync(request.Id);

            if (shelf is null)
            {
                throw new NotFoundException();
            }

            await _repository.DeleteAsync(shelf);
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