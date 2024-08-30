namespace WhereMyBooks.Core.Entities;

public class BookShelf : BaseEntity
{
    public int IdOwner { get; private set; }
    public Owner Owner { get; private set; }
    public List<Shelf> Shelves { get; private set; }
    
    public BookShelf(int idOwner)
    {
        IdOwner = idOwner;
        Shelves = new List<Shelf>();
    }

    public void AddShelf(Shelf shelf)
    {
        Shelves.Add(shelf);
    }

    public void RemoveShelf(Shelf shelf)
    {
        Shelves.Remove(shelf);
    }
}