using MediatR;
using Microsoft.EntityFrameworkCore;
using WhereMyBooks.Application.Models.ViewModels;
using WhereMyBooks.Infrastructure.Persistence;

namespace WhereMyBooks.Application.Queries.GetAllShelves;

public class GetAllShelvesQueryHandler : IRequestHandler<GetAllShelvesQuery, List<ShelfViewModel>>
{
    private readonly WhereMyBookDbContext _dbContext;

    public GetAllShelvesQueryHandler(WhereMyBookDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<ShelfViewModel>> Handle(GetAllShelvesQuery request, CancellationToken cancellationToken)
    {
        var shelves = _dbContext.Shelves;
        var shelvesViewModel = await shelves
            .Select(s => new ShelfViewModel(s.Id, s.Label, s.IdBookShelf, new List<BookViewModel>()))
            .ToListAsync(cancellationToken);

        return shelvesViewModel;
    }
}