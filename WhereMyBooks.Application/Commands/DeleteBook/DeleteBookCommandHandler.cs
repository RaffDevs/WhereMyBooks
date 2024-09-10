using MediatR;
using WhereMyBooks.Application.Commands.UpdateBook;
using WhereMyBooks.Application.Exceptions;
using WhereMyBooks.Core.Enums;
using WhereMyBooks.Core.Repositories;
using WhereMyBooks.Infrastructure.Persistence;

namespace WhereMyBooks.Application.Commands.DeleteBook;

public class DeleteBookCommandHandler : IRequestHandler<DeleteBookCommand>
{
    private readonly IBookRepository _repository;

    public DeleteBookCommandHandler(IBookRepository repository)
    {
        _repository = repository;
    }

    public async Task Handle(DeleteBookCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var book = await _repository.GetByIdAsync(request.Id);
            if (book is null)
            {
                throw new NotFoundException();
            }

            await _repository.DeleteAsync(book);
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