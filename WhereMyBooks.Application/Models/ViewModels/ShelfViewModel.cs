namespace WhereMyBooks.Application.Models.ViewModels;

public record ShelfViewModel(
    int Id,
    string Label,
    int IdBookShel,
    List<BookViewModel> Books
);