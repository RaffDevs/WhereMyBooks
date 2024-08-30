namespace WhereMyBooks.Application.Models.ViewModels;

public record LoginViewModel
{
    public string Email { get; init; }
    public string AccessToken { get; init; }
};