using MediatR;
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
        var shelf = await _repository.GetByIdAsync(request.Id);

        if (shelf is null)
        {
            throw new NotImplementedException();
        }

        await _repository.DeleteAsync(shelf);
    }
}