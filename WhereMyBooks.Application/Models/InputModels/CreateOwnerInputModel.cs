namespace WhereMyBooks.Application.Models.InputModels;

public record CreateOwnerInputModel
{
    public string FirstName { get; init; }
    public string LastName { get; init; }
    public string Email { get; init; }
    public string Password { get; init;}
};