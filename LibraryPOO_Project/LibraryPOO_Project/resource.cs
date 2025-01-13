namespace LibraryPOO_Project;

public class resource
{
    private string  title, author, type, genre;
    private DateTime publishingDate;
    private int availableStock ,resourceId;
    
    public int ResourceId { get => resourceId;
        set => resourceId = value;
    }

    public string Title
    {
        get => title;
        set => title = value;
    }

    public string Author
    {
        get => author;
        set => author = value;
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
        set => publishingDate= value;
    }

    public int AvailableStock
    {
        get => availableStock;
        set =>availableStock= value;
    }
    
    public resource(int id, string title, string author, string type, string genre, DateTime publishingDate,
        int availableStock)
    {
        this.resourceId = id;
        this.title = title;
        this.author = author;
        this.type = type;
        this.genre = genre;
        this.publishingDate = publishingDate;
        this.availableStock = availableStock;
    }
}