namespace LibraryPOO_Project;

public class admin:user
{
    private string userId, name, email;
    private List <loan> loans = new List<loan>();

    public admin(string userId, string name, string email, List<loan> loans) : base(userId, name, email, loans)
    {
    }
}