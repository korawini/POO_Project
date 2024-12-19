namespace LibraryPOO_Project;

public class student: user
{
    private string userId, name, email;
    private List <loan> loans = new List<loan>();
    private List<string> courses = new List<string>();
    private int maxResources;
    
    public List<string> Courses { get => courses; }
    public int MaxResources { get => maxResources; }
    
    public student(string userId, string name, string email, List<loan> loans, List<string> courses, int maxResources) : base(userId, name, email, loans)
    {
        this.courses = courses;
        this.maxResources = maxResources;
    }
}