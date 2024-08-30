namespace WhereMyBooks.Application.Models.InputModels;

public record UpdateMarkupInputModel
{
    public string Content { get; init; }
    public int Page { get; init; }
    public int Type { get; init; }
};