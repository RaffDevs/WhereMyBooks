using WhereMyBooks.Application.Models.InputModels;
using WhereMyBooks.Application.Models.ViewModels;
using WhereMyBooks.Core.Entities;
using WhereMyBooks.Core.Enums;

namespace WhereMyBooks.Application.Models.Mappers;

public static class BookMapper
{
    public static BookViewModel MapToBookViewModel(Book book)
    {
        return new BookViewModel(
            book.Id,
            book.Title,
            book.ThumbnailSmallLink,
            book.CreatedAt
        );
    }

    public static BookDetailViewModel MapToBookDetailViewModel(Book book)
    {
        return new BookDetailViewModel(
            book.Id,
            book.Title,
            book.Description,
            book.Authors,
            book.Publisher,
            book.PageCount,
            book.ThumbnailLink,
            book.Isbn,
            (int)book.BookType,
            book.IdShelf,
            book.Markups.Select(MarkupMapper.MapToMarkupViewModel).ToList()
        );
    }

    public static Book MapToBook(CreateBookInputModel model)
    {
        return new Book(
            model.Title,
            model.Description,
            model.Authors,
            model.Publisher,
            model.PageCount,
            model.SmallThumbnailLink,
            model.ThumbnailLink,
            null,
            model.Isbn,
            model.IdShelf
        );
    }
}