namespace WhereMyBooks.Application.Models.InputModels;

public record UpdateOwnerInputModel
{
    public string FullName { get; init; }
    public string Email { get; init; }
};