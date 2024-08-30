using MediatR;
using WhereMyBooks.Application.Models.ViewModels;

namespace WhereMyBooks.Application.Queries.GetShelfById;

public class GetShelfByIdQuery : IRequest<ShelfViewModel>
{
    public int Id { get; private set; }

    public GetShelfByIdQuery(int id)
    {
        Id = id;
    }
}