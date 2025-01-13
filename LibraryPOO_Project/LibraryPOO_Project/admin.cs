namespace LibraryPOO_Project;

public class admin:user
{
    private string name, email;
    private List <loan> loans = new List<loan>();
    private int userId;

    public admin(int userId, string name, string email, List<loan> loans) : base(userId, name, email,  loans)
    {
    }
}