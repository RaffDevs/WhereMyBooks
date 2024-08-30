using WhereMyBooks.Core.Entities;

namespace WhereMyBooks.Core.Repositories;

public interface IBookRepository
{
    Task<List<Book>> GetAllAsync(int idShelf);
    Task<Book?> GetByIdAsync(int id);
    Task<Book> CreateAsync(Book book);
    Task UpdateAsync(Book book);
    Task DeleteAsync(Book book);
}