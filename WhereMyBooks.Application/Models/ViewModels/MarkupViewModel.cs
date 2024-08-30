namespace WhereMyBooks.Application.Models.ViewModels;

public record MarkupViewModel(
    int Id,
    string Content,
    int Page,
    int MarkupType,
    int IdBook
);