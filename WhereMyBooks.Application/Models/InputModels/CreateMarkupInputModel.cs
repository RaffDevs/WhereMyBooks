namespace WhereMyBooks.Application.Models.InputModels;

public record CreateMarkupInputModel
{
    public string Content { get; init; }
    public int Page { get; init; }
    public int Type { get; init; }
    public int IdBook { get; init; }
};