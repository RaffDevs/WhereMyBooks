using Microsoft.EntityFrameworkCore;
using WhereMyBooks.Core.Entities;
using WhereMyBooks.Core.Repositories;

namespace WhereMyBooks.Infrastructure.Persistence.Repositories;

public class BookRepository : IBookRepository
{
    private readonly WhereMyBookDbContext _dbContext;

    public BookRepository(WhereMyBookDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<Book>> GetAllAsync(int idShelf)
    {
        var books = await _dbContext.Books
            .Where(book => book.IdShelf == idShelf)
            .ToListAsync();
        return books;
    }

    public async Task<Book?> GetByIdAsync(int id)
    {
        var book = await _dbContext.Books.Include(book => book.Markups)
            .FirstOrDefaultAsync(book => book.Id == id);
        return book;
    }

    public async Task<Book> CreateAsync(Book book)
    {
        var result = _dbContext.Books.Add(book);
        await _dbContext.SaveChangesAsync();

        return result.Entity;
    }

    public async Task UpdateAsync(Book book)
    {
        _dbContext.Books.Update(book);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(Book book)
    {
        _dbContext.Books.Remove(book);
        await _dbContext.SaveChangesAsync();
    }
}