using MediatR;
using WhereMyBooks.Application.Models.Mappers;
using WhereMyBooks.Core.Entities;
using WhereMyBooks.Core.Repositories;
using WhereMyBooks.Infrastructure.Persistence;

namespace WhereMyBooks.Application.Commands.CreateShelf;

public class CreateShelfCommandHandler : IRequestHandler<CreateShelfCommand, int>
{
    private readonly IShelfRepository _repository;

    public CreateShelfCommandHandler(IShelfRepository repository)
    {
        _repository = repository;
    }

    public async Task<int> Handle(CreateShelfCommand request, CancellationToken cancellationToken)
    {
        var shelf = ShelfMapper.MapToShelf(request.Model);
        var result = await _repository.CreateAsync(shelf);

        return result.Id;
    }
}