using MediatR;
using Microsoft.EntityFrameworkCore;
using WhereMyBooks.Application.Exceptions;
using WhereMyBooks.Application.Models.Mappers;
using WhereMyBooks.Application.Models.ViewModels;
using WhereMyBooks.Core.Repositories;
using WhereMyBooks.Infrastructure.Persistence;

namespace WhereMyBooks.Application.Queries.GetShelfById;

public class GetShelfByIdQueryHandler : IRequestHandler<GetShelfByIdQuery, ShelfViewModel>
{
    private readonly IShelfRepository _repository;

    public GetShelfByIdQueryHandler(IShelfRepository repository)
    {
        _repository = repository;
    }

    public async Task<ShelfViewModel> Handle(GetShelfByIdQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var shelf = await _repository.GetByIdAsync(request.Id);

            if (shelf is null)
            {
                throw new NotFoundException();
            }

            var shelfViewModel = ShelfMapper.MapToShelfViewModel(shelf);
            return shelfViewModel;
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