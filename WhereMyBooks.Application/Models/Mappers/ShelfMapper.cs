using WhereMyBooks.Application.Models.InputModels;
using WhereMyBooks.Application.Models.ViewModels;
using WhereMyBooks.Core.Entities;

namespace WhereMyBooks.Application.Models.Mappers;

public static class ShelfMapper
{
    public static ShelfViewModel MapToShelfViewModel(Shelf shelf)
    {
        return new ShelfViewModel(
            shelf.Id,
            shelf.Label,
            shelf.IdBookShelf,
            shelf.Books.Select(BookMapper.MapToBookViewModel).ToList()
        );
    }

    public static Shelf MapToShelf(CreateShelfInputModel model)
    {
        return new Shelf(
            model.Label,
            model.IdBookShelf
        );
    }
}