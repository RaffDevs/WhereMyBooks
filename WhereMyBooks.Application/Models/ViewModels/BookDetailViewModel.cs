namespace WhereMyBooks.Application.Models.ViewModels;

public record BookDetailViewModel(
    int Id,
    string Title,
    string Description,
    string Authors,
    string Publisher,
    int PageCount,
    string ThumbnailLink,
    string Isbn,
    int BookType,
    int IdShelf,
    List<MarkupViewModel> Markups
);