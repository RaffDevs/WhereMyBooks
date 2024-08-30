using WhereMyBooks.Core.Entities;

namespace WhereMyBooks.Core.Repositories;

public interface IShelfRepository
{
    Task<List<Shelf>> GetAllAsync();
    Task<Shelf?> GetByIdAsync(int id);
    Task<Shelf> CreateAsync(Shelf shelf);
    Task UpdateAsync(Shelf shelf);
    Task DeleteAsync(Shelf shelf);
}