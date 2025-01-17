namespace LibraryPOO_Project;

public class standardUser: student
{
    private string  name, email;
    private List <loan> loans = new List<loan>();
    private List<string> courses = new List<string>();
    private int maxLoans=3, loanDuration=14,userId;

    public List<string> Courses
    {
        get => courses;
        set => courses = value;
    }

    public int MaxResources
    {
        get => maxLoans;
        set => maxLoans = value;
    }
    
    public standardUser(int userId, string name, string email, List<loan> loans, List<string> courses) : base("StandardUser",userId, name, email, loans,courses,3,14)
    {
        this.courses = courses;
        this.courses = courses;
    }
}