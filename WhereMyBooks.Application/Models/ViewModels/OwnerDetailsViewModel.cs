namespace WhereMyBooks.Application.Models.ViewModels;

public record OwnerDetailsViewModel(
    int Id,
    string FullName,
    string Email,
    int? IdBookShelf
);