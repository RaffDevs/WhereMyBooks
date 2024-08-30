using MediatR;
using WhereMyBooks.Application.Models.ViewModels;

namespace WhereMyBooks.Application.Queries.GetAllBooks;

public class GetAllBooksQuery : IRequest<List<BookViewModel>>
{
    public int IdShelf { get; private set; }

    public GetAllBooksQuery(int idShelf)
    {
        IdShelf = idShelf;
    }
}