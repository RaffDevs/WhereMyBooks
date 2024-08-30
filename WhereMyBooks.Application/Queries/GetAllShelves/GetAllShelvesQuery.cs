using MediatR;
using WhereMyBooks.Application.Models.ViewModels;

namespace WhereMyBooks.Application.Queries.GetAllShelves;

public class GetAllShelvesQuery : IRequest<List<ShelfViewModel>>
{
    
}