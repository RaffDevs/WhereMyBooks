using WhereMyBooks.Application.Models.ViewModels;

namespace WhereMyBooks.Application.Models.Mappers;

public static class LoginMapper
{
    public static LoginViewModel MapToLoginViewModel(string email, string token)
    {
        return new LoginViewModel
        {
            Email = email,
            AccessToken = token
        };
    }
}