using MediatR;
using WhereMyBooks.Application.Models.ViewModels;

namespace WhereMyBooks.Application.Queries.GetOwnerById;

public class GetOwnerByIdQuery : IRequest<OwnerDetailsViewModel>
{
    public int Id { get; private set; }

    public GetOwnerByIdQuery(int id)
    {
        Id = id;
    }
}