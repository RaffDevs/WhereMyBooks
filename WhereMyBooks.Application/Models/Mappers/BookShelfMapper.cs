using WhereMyBooks.Application.Models.ViewModels;
using WhereMyBooks.Core.Entities;

namespace WhereMyBooks.Application.Models.Mappers;

public static class BookShelfMapper
{
    public static BookShelfDetailViewModel MapToBookShelfDetailViewModel(BookShelf bookShelf)
    {
        return new BookShelfDetailViewModel(
            bookShelf.Id,
            bookShelf.IdOwner,
            bookShelf.Shelves.Select(ShelfMapper.MapToShelfViewModel).ToList()
        );
    }
}