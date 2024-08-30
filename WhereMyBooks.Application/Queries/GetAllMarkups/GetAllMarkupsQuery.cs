using MediatR;
using WhereMyBooks.Application.Models.ViewModels;

namespace WhereMyBooks.Application.Queries.GetAllMarkups;

public class GetAllMarkupsQuery : IRequest<List<MarkupViewModel>>
{
    public int IdBook { get; private set; }

    public GetAllMarkupsQuery(int idBook)
    {
        IdBook = idBook;
    }
}