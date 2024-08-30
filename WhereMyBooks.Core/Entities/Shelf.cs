namespace WhereMyBooks.Core.Entities;

public class Shelf : BaseEntity
{
    public string Label { get; private set; }
    public int IdBookShelf { get; private set; }
    public BookShelf BookShelf { get; private set; }
    public List<Book> Books { get; private set; }

    public Shelf(string label, int idBookShelf)
    {
        Label = label;
        IdBookShelf = idBookShelf;
        Books = new List<Book>();
    }

    public void SetLabel(string label) => Label = label;
}