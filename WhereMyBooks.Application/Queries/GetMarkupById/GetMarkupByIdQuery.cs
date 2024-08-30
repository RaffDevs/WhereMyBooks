using MediatR;
using WhereMyBooks.Application.Models.ViewModels;

namespace WhereMyBooks.Application.Queries.GetMarkupById;

public class GetMarkupByIdQuery : IRequest<MarkupViewModel>
{
    public int Id { get; private set; }

    public GetMarkupByIdQuery(int id)
    {
        Id = id;
    }
}