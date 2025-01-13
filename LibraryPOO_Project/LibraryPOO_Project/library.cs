namespace LibraryPOO_Project;

public class library
{
    public List<book> resources { get; }
    public List<user> users { get; }

    public library()
    {
        resources = new List<book>();
        users = new List<user>();
    }

    public void AddResource(book resource)
    {
        resources.Add(resource);
    }

    public void AddUser(user user)
    {
        users.Add(user);
    }
}