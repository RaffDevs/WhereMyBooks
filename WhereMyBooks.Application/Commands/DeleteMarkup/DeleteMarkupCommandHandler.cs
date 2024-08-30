using MediatR;
using WhereMyBooks.Core.Repositories;
using WhereMyBooks.Infrastructure.Persistence;

namespace WhereMyBooks.Application.Commands.DeleteMarkup;

public class DeleteMarkupCommandHandler : IRequestHandler<DeleteMarkupCommand>
{
    private readonly IMarkupRepository _repository;

    public DeleteMarkupCommandHandler(IMarkupRepository repository)
    {
        _repository = repository;
    }

    public async Task Handle(DeleteMarkupCommand request, CancellationToken cancellationToken)
    {
        var markup = await _repository.GetByIdAsync(request.Id);
            
        if (markup is null)
        {
            throw new NotImplementedException();
        }

        await _repository.DeleteAsync(markup);
    }
}