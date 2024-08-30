using WhereMyBooks.Core.Entities;

namespace WhereMyBooks.Core.Repositories;

public interface IOwnerRepository
{
    Task<Owner?> GetByIdAsync(int id);
    Task<Owner?> GetByEmailAndPasswordAsync(string email, string hashPassword);
    Task<Owner> CreateAsync(Owner owner);
    Task UpdateAsync(Owner owner);
    Task DeleteAsync(Owner owner);
}