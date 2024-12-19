namespace LibraryPOO_Project;

public class user
{
    private string userId, name, email;
    private List <loan> loans = new List<loan>();
    
    public string UserId { get => userId; }
    public string Name { get => name; }
    public string Email { get => email; }
    public List <loan> Loans { get => loans; }
    
    public user(string userId, string name, string email, List<loan> loans)
    {
        this.userId = userId;
        this.name = name;
        this.email = email;
        this.loans = loans;
    }
}