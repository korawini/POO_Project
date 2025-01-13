namespace LibraryPOO_Project;

public class admin:user
{
    private string name, email;
    private List <loan> loans = new List<loan>();
    private int userId;
    private library lb;

    public admin(int userId, string name, string email, library lb) : base(userId, name, email,loans, 9999, 99999)
    {
    }
    public void AddResources(resource resourcex)
    {
        lb.AddResource(resourcex);
        Console.WriteLine($"Resource '{resource.Title}' has been added by admin {Name}.");
    }

    public void AddCourseToStudent(int studentId, string courseName, List<user> users)
    {
        var student = users.OfType<student>().FirstOrDefault(u => u.UserId == studentId);
        if (student != null)
        {
            student.Courses.Add(courseName);
            Console.WriteLine($"Course '{courseName}' has been added to student {student.Name}.");
        }
        else
        {
            Console.WriteLine($"Student with ID {studentId} not found.");
        }
    }
}