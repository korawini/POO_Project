namespace LibraryPOO_Project;

public class resource
{
    private string  title, author, type, genre;
    private DateTime publishingDate;
    private int availableStock ,resourceId;
    public Queue<int> reservations { get; set; } = new Queue<int>();
    
    public int ResourceId 
    { 
        get => resourceId;
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
    
    public void AddReservation(int userId)
    {
        if (!reservations.Contains(userId))
        {
            reservations.Enqueue(userId);
            Console.WriteLine($"User {userId} has been added to the reservation list for '{Title}'.");
        }
        else
        {
            Console.WriteLine($"User {userId} is already on the reservation list for '{Title}'.");
        }
    }
    
    public int? GetNextReservation()
    {
        if (reservations.Count > 0)
            return reservations.Dequeue();
        return null;
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