using FluentValidation;
using WhereMyBooks.Application.Models.InputModels;

namespace WhereMyBooks.Application.Validations;

public class CreateMarkupValidation : AbstractValidator<CreateMarkupInputModel>
{
    public CreateMarkupValidation()
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

        RuleFor(p => p.IdBook)
            .NotNull()
            .WithMessage("Book must be provided!")
            .NotEmpty()
            .WithMessage("A valid book must be provided!");
    }
}