namespace LibraryPOO_Project;

public class advancedUser : student
{
    private string  name, email;
    private List <loan> loans = new List<loan>();
    private List<string> courses = new List<string>();
    private int maxLoans=5, loanDuration=21,userId;
    
    public List<string> Courses { get => courses; }
    public int MaxResources { get => maxLoans; }
    
    public advancedUser(int userId, string name, string email, List<loan> loans, List<string> courses, int maxResources, int loanDuration) : base(userId, name, email, loans, 5, 21)
    {
        this.courses = courses;
        
    }
}