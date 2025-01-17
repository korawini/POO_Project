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
    
    public void ShowResourceDetails(resource resource)
    {
        Console.WriteLine("\nDetails of the borrowed resource:");
        Console.WriteLine($"Resource ID: {resource.ResourceId}");
        Console.WriteLine($"Title: {resource.Title}");
        Console.WriteLine($"Author: {resource.Author}");
        Console.WriteLine($"Genre: {resource.Genre}");
        Console.WriteLine($"Publishing Date: {resource.PublishingDate:yyyy-MM-dd}");
        Console.WriteLine($"Available Stock: {resource.AvailableStock}");

        switch (resource)
        {
            case book:
                Console.WriteLine($"Book Type: Book");
                break;
            case ebook ebook:
                Console.WriteLine($"Ebook Download Link: {ebook.Link}");
                break;
            case magazine magazine:
                Console.WriteLine($"Edition: {magazine.Edition}, Number: {magazine.Number}");
                break;
            case manual manual:
                Console.WriteLine($"Course: {manual.Course}");
                break;
            default:
                Console.WriteLine("Unknown resource type.");
                break;
        }
    }

    
    public resource(string type, int id, string title, string author, string genre, DateTime publishingDate,
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