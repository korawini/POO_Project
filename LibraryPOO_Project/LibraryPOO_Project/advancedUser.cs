namespace LibraryPOO_Project;

public class advancedUser : user
{
    private string userId, name, email;
    private List <loan> loans = new List<loan>();
    private List<string> courses = new List<string>();
    private int maxLoans;
    
    public List<string> Courses { get => courses; }
    public int MaxResources { get => maxLoans; }
    
    public advancedUser(string userId, string name, string email, List<loan> loans, List<string> courses, int maxResources) : base(userId, name, email, 5, loans)
    {
        this.courses = courses;
        
    }
}