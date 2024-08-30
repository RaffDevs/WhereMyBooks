using WhereMyBooks.Core.Entities;

namespace WhereMyBooks.Core.Repositories;

public interface IBookShelfRepository
{
    Task<BookShelf?> GetByIdAsync(int id);
    Task<BookShelf> CreateAsync(BookShelf bookShelf);
    Task DeleteAsync(BookShelf bookShelf);
}