namespace LibraryPOO_Project;

public class user
{
    private string  name, email;
    private int userId;

    public int UserId
    {
        get => userId;
        set => userId = value;
    }

    public string Name
    {
        get => name;
        set => name = value;
    }

    public string Email
    {
        get => email;
        set => email = value;
    }
    
    public user(int userId, string name, string email)
    {
        this.userId = userId;
        this.name = name;
        this.email = email;
    }
}