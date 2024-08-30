using Microsoft.EntityFrameworkCore;
using WhereMyBooks.Core.Entities;
using WhereMyBooks.Core.Repositories;

namespace WhereMyBooks.Infrastructure.Persistence.Repositories;

public class MarkupRepository : IMarkupRepository
{
    private readonly WhereMyBookDbContext _dbContext;

    public MarkupRepository(WhereMyBookDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<Markup>> GetAllAsync(int idBook)
    {
        var markups = await _dbContext.Markups
                .Where(markup => markup.IdBook == idBook)
                .ToListAsync();
        return markups;
    }

    public async Task<Markup?> GetByIdAsync(int id)
    {
        var markup = await _dbContext.Markups.FindAsync(id);
        return markup;
    }

    public async Task<Markup> CreateAsync(Markup markup)
    {
        var result = _dbContext.Markups.Add(markup);
        await _dbContext.SaveChangesAsync();
        return result.Entity;
    }

    public async Task UpdateAsync(Markup markup)
    {
        _dbContext.Markups.Update(markup);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(Markup markup)
    {
        _dbContext.Markups.Remove(markup);
        await _dbContext.SaveChangesAsync();
    }
}