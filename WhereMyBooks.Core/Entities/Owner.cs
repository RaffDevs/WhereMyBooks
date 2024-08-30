namespace WhereMyBooks.Core.Entities;

public class Owner : BaseEntity
{
    public string FullName { get; private set; }
    public string Email { get; private set; }
    
    public string Password { get; private set; }
    public BookShelf BookShelf { get; private set; }

    public Owner(string fullName, string email, string password)
    {
        FullName = fullName;
        Email = email;
        Password = password;
    }

    public void SetFullName(string fullName) => FullName = fullName;
    public void SetEmail(string email) => Email = email;
    public void SetPassword(string password) => Password = password;
}