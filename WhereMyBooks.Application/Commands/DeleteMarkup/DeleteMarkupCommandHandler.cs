using MediatR;
using WhereMyBooks.Application.Exceptions;
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
        try
        {
            var markup = await _repository.GetByIdAsync(request.Id);

            if (markup is null)
            {
                throw new NotFoundException();
            }

            await _repository.DeleteAsync(markup);
        }
        catch (NotFoundException ex)
        {
            throw;
        }
        catch (Exception exception)
        {
            throw new InternalException(exception.Message);
        }
    }
}