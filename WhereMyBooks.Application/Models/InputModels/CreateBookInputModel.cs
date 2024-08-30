namespace WhereMyBooks.Application.Models.InputModels;

public record CreateBookInputModel
{
    public string Title { get; init; }
    public string Description { get; init; }
    public string Authors { get; init; }
    public string Publisher { get; init; }
    public int PageCount { get; init; }
    public string ThumbnailLink { get; init; }
    public string SmallThumbnailLink { get; init; }
    public string Isbn { get; init; }
    public int BookType { get; init; }
    public int IdShelf { get; init; }
    public int IdOwner { get; init; }
};