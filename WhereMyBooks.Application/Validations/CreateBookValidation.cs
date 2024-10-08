using FluentValidation;
using WhereMyBooks.Application.Models.InputModels;

namespace WhereMyBooks.Application.Validations;

public class CreateBookValidation : AbstractValidator<CreateBookInputModel>
{
    public CreateBookValidation()
    {
        RuleFor(p => p.Title)
            .NotNull()
            .NotEmpty()
            .MaximumLength(150);

        RuleFor(p => p.Authors)
            .NotNull()
            .NotEmpty();

        RuleFor(p => p.Description)
            .NotNull()
            .NotEmpty()
            .MaximumLength(500);

        RuleFor(p => p.BookType)
            .NotNull()
            .NotEmpty();

        RuleFor(p => p.Isbn)
            .NotNull()
            .NotEmpty();
        
        RuleFor(p => p.Publisher)
            .NotNull()
            .NotEmpty();
        
        RuleFor(p => p.PageCount)
            .NotNull()
            .NotEmpty();

        RuleFor(p => p.IdOwner)
            .NotNull()
            .WithMessage("Owner must be provided!")
            .NotEmpty()
            .WithMessage("Valid owner must be provided!");

        RuleFor(p => p.IdShelf)
            .NotEmpty()
            .WithMessage("Shelf must be provided")
            .NotNull()
            .WithMessage("Valid shelf must be provided");
    }
}