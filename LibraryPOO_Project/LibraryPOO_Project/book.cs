namespace LibraryPOO_Project;
//base for manual, book, ebook, magazine
//can be borrowed by anyone
public class book
{
    private string id, title, author, type, genre;
    private DateTime publishingDate;
    private int availableStock;
    
    public string Id { get => id; }
    public string Title { get => title; }
    public string Author { get => author; }
    public string Type { get => type; }
    public string Genre { get => genre; }
    public DateTime PublishingDate { get => publishingDate; }
    public int AvailableStock { get => availableStock; }
    
    public book(string id, string title, string author, string type, string genre, DateTime publishingDate,
        int availableStock)
    {
        this.id = id;
        this.title = title;
        this.author = author;
        this.type = type;
        this.genre = genre;
        this.publishingDate = publishingDate;
        this.availableStock = availableStock;
    }
}