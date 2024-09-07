using WhereMyBooks.Core.Entities;
using WhereMyBooks.Infrastructure.Models.DTOs;

namespace WhereMyBooks.Infrastructure.Models.Mappers;

public static class GoogleBookMapper
{
    public static Book MapGoogleBookToBook(BookItemDTO bookItem, int idShelf)
    {
        return new Book(
            title: bookItem.BookInfo.Title,
            description: bookItem.BookInfo.Description,
            authors: string.Join(',', bookItem.BookInfo.Authors),
            publisher: bookItem.BookInfo.Publisher,
            pageCount: bookItem.BookInfo.PageCount,
            thumbnailLink: bookItem.BookInfo.ImageLinks?.Thumbnail ?? string.Empty,
            thumbnailSmallLink: bookItem.BookInfo.ImageLinks?.SmallThumbnail,
            code: bookItem.Id,
            isbn: bookItem.BookInfo.IndustryIdentifiersDto
                .FirstOrDefault(i => i.Type == "ISBN_13")?.Identifier ?? string.Empty,
            idShelf: idShelf
        );
    }
}