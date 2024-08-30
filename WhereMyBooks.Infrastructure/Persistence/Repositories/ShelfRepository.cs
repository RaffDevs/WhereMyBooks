using Microsoft.EntityFrameworkCore;
using WhereMyBooks.Core.Entities;
using WhereMyBooks.Core.Repositories;

namespace WhereMyBooks.Infrastructure.Persistence.Repositories;

public class ShelfRepository : IShelfRepository
{
    private readonly WhereMyBookDbContext _dbContext;

    public ShelfRepository(WhereMyBookDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task<List<Shelf>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<Shelf?> GetByIdAsync(int id)
    {
        var shelf = await _dbContext.Shelves
            .Include(shelf => shelf.Books)
            .FirstOrDefaultAsync(shelf => shelf.Id == id);
        return shelf;
    }

    public async Task<Shelf> CreateAsync(Shelf shelf)
    {
        var result = _dbContext.Shelves.Add(shelf);
        await _dbContext.SaveChangesAsync();
        return result.Entity;
    }

    public async Task UpdateAsync(Shelf shelf)
    {
        _dbContext.Shelves.Update(shelf);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(Shelf shelf)
    {
        _dbContext.Shelves.Remove(shelf);
        await _dbContext.SaveChangesAsync();
    }
}