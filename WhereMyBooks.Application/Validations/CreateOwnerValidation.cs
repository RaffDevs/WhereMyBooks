using FluentValidation;
using WhereMyBooks.Application.Models.InputModels;

namespace WhereMyBooks.Application.Validations;

public class CreateOwnerValidation : AbstractValidator<CreateOwnerInputModel>
{
    public CreateOwnerValidation()
    {
        RuleFor(p => p.FirstName)
            .NotNull()
            .WithMessage("O primeiro nome deve ser fornecido!")
            .NotEmpty()
            .WithMessage("O primeiro nome deve ser fornecido!");
    }
}