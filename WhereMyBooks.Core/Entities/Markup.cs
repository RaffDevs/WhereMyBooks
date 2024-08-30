using WhereMyBooks.Core.Enums;

namespace WhereMyBooks.Core.Entities;

public class Markup : BaseEntity
{
    public string Content { get; private set; }
    public int Page { get; private set; }
    public MarkupType MarkupType { get; private set; }
    public int IdBook { get; private set; }
    public Book Book { get; private set; }

    public Markup(string content, int page, int idBook, MarkupType markupType = MarkupType.Highlight)
    {
        Content = content;
        Page = page;
        MarkupType = markupType;
        IdBook = idBook;
    }

    public void SetContent(string content) => Content = content;
    public void SetPage(int page) => Page = page;
    public void SetMarkupType(int type) => MarkupType = (MarkupType)type;
    
}