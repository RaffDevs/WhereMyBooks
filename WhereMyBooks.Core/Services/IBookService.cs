using WhereMyBooks.Core.Entities;

namespace WhereMyBooks.Core.Services;

public interface IBookService
{
    Task<List<Book>> SearchBooks(string title, int idShelf);
}