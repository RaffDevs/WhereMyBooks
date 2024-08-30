namespace WhereMyBooks.Application.Models.InputModels;

public record LoginInputModel
{
    public string Email { get; init; }
    public string Password { get; init; }
}