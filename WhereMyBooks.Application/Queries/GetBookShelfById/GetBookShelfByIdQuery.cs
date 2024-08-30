using MediatR;
using WhereMyBooks.Application.Models.ViewModels;

namespace WhereMyBooks.Application.Queries.GetBookShelfById;

public class GetBookShelfByIdQuery : IRequest<BookShelfDetailViewModel>
{
    public int Id { get; private set; }
    public int IdOwner { get; private set; }

    public GetBookShelfByIdQuery(int id, int idOwner)
    {
        Id = id;
        IdOwner = idOwner;
    }
}