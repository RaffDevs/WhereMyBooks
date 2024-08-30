namespace WhereMyBooks.Application.Models.ViewModels;

public record BookViewModel(
    int Id,
    string Title,
    string SmallThumbnailLink,
    DateTime CreatedAt
);