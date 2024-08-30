using WhereMyBooks.Core.Entities;

namespace WhereMyBooks.Core.Repositories;

public interface IMarkupRepository
{
    Task<List<Markup>> GetAllAsync(int idBook);
    Task<Markup?> GetByIdAsync(int id);
    Task<Markup> CreateAsync(Markup markup);
    Task UpdateAsync(Markup markup);
    Task DeleteAsync(Markup markup);
}