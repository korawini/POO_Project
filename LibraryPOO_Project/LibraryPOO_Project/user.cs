namespace LibraryPOO_Project;

public class user
{
    private string userId, name, email;
    private int maxLoans;
    private List <loan> loans = new List<loan>();
    
    public string UserId { get => userId; }
    public string Name { get => name; }
    public string Email { get => email; }
    public List <loan> Loans { get => loans; }
    public int MaxLoans { get => maxLoans; }
    
    public user(string userId, string name, string email, int maxLoans, List<loan> loans)
    {
        this.userId = userId;
        this.name = name;
        this.email = email;
        this.maxLoans = maxLoans;
        this.loans = loans;
    }
}