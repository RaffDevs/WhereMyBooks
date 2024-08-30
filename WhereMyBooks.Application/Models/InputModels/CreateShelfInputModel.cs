namespace WhereMyBooks.Application.Models.InputModels;

public record CreateShelfInputModel
{
    public string Label { get; init; }
    public int IdBookShelf { get; init; }
};