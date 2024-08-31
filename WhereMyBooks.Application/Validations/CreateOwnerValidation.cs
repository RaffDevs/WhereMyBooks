using FluentValidation;
using WhereMyBooks.Application.Models.InputModels;

namespace WhereMyBooks.Application.Validations;

public class CreateOwnerValidation : AbstractValidator<CreateOwnerInputModel>
{
    public CreateOwnerValidation()
    {
        RuleFor(p => p.FirstName)
            .NotNull()
            .NotEmpty();

        RuleFor(p => p.LastName)
            .NotNull()
            .NotEmpty();

        RuleFor(p => p.Email)
            .NotNull()
            .NotEmpty()
            .EmailAddress();

        RuleFor(p => p.Password)
            .NotNull()
            .NotEmpty()
            .MinimumLength(6)
            .MaximumLength(30);
    }
}