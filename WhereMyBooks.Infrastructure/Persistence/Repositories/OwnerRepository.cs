using Microsoft.EntityFrameworkCore;
using WhereMyBooks.Core.Entities;
using WhereMyBooks.Core.Repositories;

namespace WhereMyBooks.Infrastructure.Persistence.Repositories;

public class OwnerRepository : IOwnerRepository
{
    private readonly WhereMyBookDbContext _dbContext;

    public OwnerRepository(WhereMyBookDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Owner?> GetByIdAsync(int id)
    {
        var owner = await _dbContext.Owners
            .Include(o => o.BookShelf)
            .FirstOrDefaultAsync(o => o.Id == id);

        return owner;
    }

    public async Task<Owner?> GetByEmailAndPasswordAsync(string email, string hashPassword)
    {
        var owner = await _dbContext.Owners.SingleOrDefaultAsync(owner =>
            owner.Email == email && owner.Password == hashPassword);

        return owner;
    }

    public async Task<Owner> CreateAsync(Owner owner)
    {
        var result = _dbContext.Owners.Add(owner);
        await _dbContext.SaveChangesAsync();
        return result.Entity;
    }

    public async Task UpdateAsync(Owner owner)
    {
        _dbContext.Owners.Update(owner);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(Owner owner)
    {
        _dbContext.Owners.Remove(owner);
        await _dbContext.SaveChangesAsync();
    }
}