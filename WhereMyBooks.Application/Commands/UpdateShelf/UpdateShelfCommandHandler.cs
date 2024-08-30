using MediatR;
using WhereMyBooks.Core.Repositories;

namespace WhereMyBooks.Application.Commands.UpdateShelf;

public class UpdateShelfCommandHandler : IRequestHandler<UpdateShelfCommand>
{
    private readonly IShelfRepository _repository;

    public UpdateShelfCommandHandler(IShelfRepository repository)
    {
        _repository = repository;
    }

    public async Task Handle(UpdateShelfCommand request, CancellationToken cancellationToken)
    {
        var shelf = await _repository.GetByIdAsync(request.Id);

        if (shelf is null)
        {
            throw new NotImplementedException();
        }
        shelf.SetLabel(request.Model.Label);
        await _repository.UpdateAsync(shelf);
    }
}