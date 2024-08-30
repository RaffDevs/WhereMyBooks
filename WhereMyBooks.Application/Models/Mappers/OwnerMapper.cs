using WhereMyBooks.Application.Models.InputModels;
using WhereMyBooks.Application.Models.ViewModels;
using WhereMyBooks.Core.Entities;

namespace WhereMyBooks.Application.Models.Mappers;

public static class OwnerMapper
{
    public static OwnerDetailsViewModel MapToOwnerDetailsViewModel(Owner owner)
    {
        return new OwnerDetailsViewModel(
            owner.Id,
            owner.FullName,
            owner.Email,
            owner.BookShelf.IdOwner
        );
    }

    public static Owner MapToOwner(CreateOwnerInputModel model)
    {
        var fullName = string.Concat(model.FirstName, " ", model.LastName);
        return new Owner(fullName, model.Email, model.Password);
    }
}