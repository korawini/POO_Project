namespace LibraryPOO_Project;
//can only be borrowed if the student is assigned to the course
public class manual:book 
{
    private string id, title, author, type, genre, course;
    private DateTime publishingDate;
    private int availableStock;
    
    public string Course { get => course; }
    
    public manual(string id, string title, string author, string type, string genre, DateTime publishingDate,
        int availableStock, string course) : base(id, title, author, type, genre, publishingDate, availableStock)
    {
        this.course = course;
    }
}