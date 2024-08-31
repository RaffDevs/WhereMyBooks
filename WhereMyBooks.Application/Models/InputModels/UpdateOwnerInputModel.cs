namespace WhereMyBooks.Application.Models.InputModels;

public record UpdateOwnerInputModel
{
    public string FirstName { get; init; }
    public string LastName { get; set; }
    public string FullName { get; init; }
    public string Email { get; init; }
    public string Password { get; init; }
};