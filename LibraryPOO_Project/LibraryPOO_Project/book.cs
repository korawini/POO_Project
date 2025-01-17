namespace LibraryPOO_Project;
//base for manual, book, ebook, magazine
//can be borrowed by anyone
public class book : resource
{
    private string title, author, genre;
    private int id;
    private DateTime publishingDate;
    private int availableStock;
    
    public int Id
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
    
    public book(int id, string title, string author, string genre, DateTime publishingDate,
        int availableStock): base("book", id, title, author,  genre, publishingDate, availableStock)
    {
        
    }
}