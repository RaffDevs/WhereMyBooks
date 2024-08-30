using WhereMyBooks.Core.Entities;

namespace WhereMyBooks.Application.Models.ViewModels;

public record BookShelfDetailViewModel(
    int Id,
    int IdOwner,
    List<ShelfViewModel> Shelves
);