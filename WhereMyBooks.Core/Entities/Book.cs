using WhereMyBooks.Core.Enums;

namespace WhereMyBooks.Core.Entities;

public class Book : BaseEntity
{
    public string Title { get; private set; }
    public string Description { get; private set; }
    public string Authors { get; private set; }
    public string Publisher { get; private set; }
    public int PageCount { get; private set; }
    public string ThumbnailSmallLink { get; private set; }
    public string ThumbnailLink { get; private set; }
    public string? Code { get; private set; }
    public string Isbn { get; private set; }
    public BookType BookType { get; private set; }
    public int IdShelf { get; private set; }
    public Shelf Shelf { get; private set; }
    public List<Markup> Markups { get; private set; }

    public Book(string title, string description, string authors, string publisher, int pageCount,
        string thumbnailSmallLink,
        string thumbnailLink, string? code, string isbn, int idShelf)
    {
        Title = title;
        Description = description;
        Authors = authors;
        Publisher = publisher;
        PageCount = pageCount;
        ThumbnailSmallLink = thumbnailSmallLink;
        ThumbnailLink = thumbnailLink;
        Isbn = isbn;
        BookType = BookType.Physical;
        IdShelf = idShelf;
        Markups = new List<Markup>();
    }
    
    public void SetTitle(string title) => Title = title;
    public void SetDescription(string description) => Description = description;
    public void SetAuthors(string authors) => Authors = authors;
    public void SetPublisher(string publisher) => Publisher = publisher;
    public void SetPageCount(int pageCount) => PageCount = pageCount;
    public void SetThumbnailSmallLink(string link) => ThumbnailSmallLink = link;
    public void SetThumbnailLink(string link) => ThumbnailLink = link;
    public void SetIsnb(string isbn) => Isbn = isbn;
    public void SetBookType(BookType type) => BookType = type;
    public void SetIdShelf(int shelfId) => IdShelf = shelfId;

    //TODO - Adding updating shelf book
}