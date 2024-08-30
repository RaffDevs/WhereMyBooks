using WhereMyBooks.Application.Models.InputModels;
using WhereMyBooks.Application.Models.ViewModels;
using WhereMyBooks.Core.Entities;
using WhereMyBooks.Core.Enums;

namespace WhereMyBooks.Application.Models.Mappers;

public static class MarkupMapper
{
    public static MarkupViewModel MapToMarkupViewModel(Markup markup)
    {
        return new MarkupViewModel(
            markup.Id,
            markup.Content,
            markup.Page,
            (int)markup.MarkupType,
            markup.IdBook
        );
    }

    public static Markup MapToMarkup(CreateMarkupInputModel model)
    {
        return new Markup(
            model.Content,
            model.Page,
            model.IdBook,
            (MarkupType)model.Type
        );
    }
}