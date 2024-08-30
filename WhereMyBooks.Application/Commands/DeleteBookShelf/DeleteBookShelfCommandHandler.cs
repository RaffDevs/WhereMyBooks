using MediatR;
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
        var bookShelf = await _repository.GetByIdAsync(request.Id);
        if (bookShelf is null)
        {
            throw new NotImplementedException();
        }

        await _repository.DeleteAsync(bookShelf);
    }
}