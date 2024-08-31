using FluentValidation;
using WhereMyBooks.Application.Models.InputModels;

namespace WhereMyBooks.Application.Validations;

public class UpdateMarkupValidation : AbstractValidator<UpdateMarkupInputModel>
{
    public UpdateMarkupValidation()
    {
        RuleFor(p => p.Content)
            .NotNull()
            .NotEmpty()
            .MaximumLength(500)
            .MinimumLength(1);

        RuleFor(p => p.Page)
            .NotNull()
            .NotEmpty();

        RuleFor(p => p.Type)
            .NotNull()
            .NotEmpty();
    }
}