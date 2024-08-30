using Microsoft.EntityFrameworkCore;
using WhereMyBooks.Core.Entities;
using WhereMyBooks.Core.Repositories;

namespace WhereMyBooks.Infrastructure.Persistence.Repositories;

public class BookShelfRepository : IBookShelfRepository
{
    private readonly WhereMyBookDbContext _dbContext;

    public BookShelfRepository(WhereMyBookDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<BookShelf?> GetByIdAsync(int id)
    {
        var bookShelf = await _dbContext.BookShelves
            .Include(bf => bf.Shelves)
            .ThenInclude(shelf => shelf.Books)
            .Take(3)
            .FirstOrDefaultAsync( bf => 
                    bf.Id == id
            );

        return bookShelf;
    }

    public async Task<BookShelf> CreateAsync(BookShelf bookShelf)
    {
        var result = _dbContext.BookShelves.Add(bookShelf);
        await _dbContext.SaveChangesAsync();

        return result.Entity;
    }

    public async Task DeleteAsync(BookShelf bookShelf)
    {
        _dbContext.BookShelves.Remove(bookShelf);
        await _dbContext.SaveChangesAsync();
    }
}