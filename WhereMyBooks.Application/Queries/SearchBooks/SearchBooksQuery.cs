using MediatR;
using WhereMyBooks.Application.Models.ViewModels;

namespace WhereMyBooks.Application.Queries.SearchBooks;

public class SearchBooksQuery : IRequest<List<BookDetailViewModel>>
{
    public string Title { get; private set; }
    public int IdShelf { get; private set; }

    public SearchBooksQuery(string title, int idShelf)
    {
        Title = title;
        IdShelf = idShelf;
    }
}