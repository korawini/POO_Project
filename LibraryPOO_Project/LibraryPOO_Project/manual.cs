namespace LibraryPOO_Project;

public class manual:resource
{
    private string id, title, author, type, genre, course;
    private DateTime publishingDate;
    private int availableStock;

    public string Course
    {
        get => course; 
        set => course= value;
    }
    
    public manual(int id, string title, string author, string genre, DateTime publishingDate,
        int availableStock, string course) : base("manual", id, title, author, genre, publishingDate, availableStock)
    {
        this.course = course;
    }
}