using MediatR;
using WhereMyBooks.Application.Models.ViewModels;

namespace WhereMyBooks.Application.Queries.GetBookById;

public class GetBookByIdQuery : IRequest<BookDetailViewModel>
{
    public int Id { get; private set; }

    public GetBookByIdQuery(int id)
    {
        Id = id;
    }
}