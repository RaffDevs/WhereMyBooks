using MediatR;
using WhereMyBooks.Application.Exceptions;
using WhereMyBooks.Core.Repositories;
using WhereMyBooks.Infrastructure.Persistence;

namespace WhereMyBooks.Application.Commands.DeleteBookShelf;

public class DeleteBookShelfCommandHandler : IRequestHandler<DeleteBookShelfCommand>
{
    private readonly IBookShelfRepository _repository;

    public DeleteBookShelfCommandHandler(IBookShelfRepository repository)
    {
        _repository = repository;
    }

    public async Task Handle(DeleteBookShelfCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var bookShelf = await _repository.GetByIdAsync(request.Id);
            if (bookShelf is null)
            {
                throw new NotFoundException();
            }

            await _repository.DeleteAsync(bookShelf);
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