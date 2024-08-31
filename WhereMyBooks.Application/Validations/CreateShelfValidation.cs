using FluentValidation;
using WhereMyBooks.Application.Models.InputModels;

namespace WhereMyBooks.Application.Validations;

public class CreateShelfValidation : AbstractValidator<CreateShelfInputModel>
{
    public CreateShelfValidation()
    {
        RuleFor(p => p.Label)
            .NotNull()
            .NotEmpty();

        RuleFor(p => p.IdBookShelf)
            .NotNull()
            .WithMessage("BookShelf must be provided")
            .NotEmpty()
            .WithMessage("Valid bookshelf must be provided");
    }
}