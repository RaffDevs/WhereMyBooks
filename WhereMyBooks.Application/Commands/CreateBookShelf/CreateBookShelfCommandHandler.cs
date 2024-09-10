using MediatR;
using WhereMyBooks.Application.Exceptions;
using WhereMyBooks.Core.Entities;
using WhereMyBooks.Core.Repositories;
using WhereMyBooks.Infrastructure.Persistence;

namespace WhereMyBooks.Application.Commands.CreateBookShelf;

public class CreateBookShelfCommandHandler : IRequestHandler<CreateBookShelfCommand, int>
{
    private readonly IBookShelfRepository _bookShelfrepository;
    private readonly IOwnerRepository _ownerRepository;

    public CreateBookShelfCommandHandler(IBookShelfRepository bookShelfrepository, IOwnerRepository ownerRepository)
    {
        _bookShelfrepository = bookShelfrepository;
        _ownerRepository = ownerRepository;
    }

    public async Task<int> Handle(CreateBookShelfCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var owner = await _ownerRepository.GetByIdAsync(request.IdOwner);
            if (owner is null)
            {
                throw new NotFoundException();
            }

            var bookShelf = new BookShelf(owner.Id);
            var result = await _bookShelfrepository.CreateAsync(bookShelf);

            return result.Id;
        }
        catch (NotFoundException exception)
        {
            throw;
        }
        catch (Exception ex)
        {
            throw new InternalException(ex.Message);
        }
        
    }
}
