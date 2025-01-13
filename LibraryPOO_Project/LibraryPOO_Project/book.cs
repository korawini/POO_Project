namespace LibraryPOO_Project;
//base for manual, book, ebook, magazine
//can be borrowed by anyone
public class book : resource
{
    private string id, title, author, type, genre;
    private DateTime publishingDate;
    private int availableStock;
    
    public string Id
    {
        get => id;
        set => id = value;
    }

    public string Title
    {
        get => title; 
        set => title = value;
    }

    public string Author
    {
        get => author; 
        set => author= value;
    }

    public string Type
    {
        get => type;
        set => type = value;
    }

    public string Genre
    {
        get => genre;
        set => genre = value;
    }

    public DateTime PublishingDate
    {
        get => publishingDate;
        set => publishingDate = value;
    }

    public int AvailableStock
    {
        get => availableStock;
        set => availableStock = value;
    }
    
    public book(int id, string title, string author, string type, string genre, DateTime publishingDate,
        int availableStock): base(id, title, author, type, genre, publishingDate, availableStock)
    {
        
    }
}