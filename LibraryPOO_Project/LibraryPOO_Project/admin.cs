namespace LibraryPOO_Project;

public class admin:user
{
    private string name, email;
    private int userId;
    private library lb;
    
    public string Name {get => name;}
    public string Email {get => email;}
    public int UserId {get => userId;}
    
    public admin(int userId, string name, string email, library lb) : base(userId, name, email)
    {
        this.lb = lb;
        this.name = name;
        this.email = email;
        this.userId = userId;
    }
    public void AddResources(resource resourcex)
    {
        if (lb != null)
        {
            lb.AddResource(resourcex);
            Console.WriteLine($"Resource '{resourcex.Title}' has been added by admin {name}.");
        }
        else
        {
            Console.WriteLine("Library instance is null. Cannot add resource.");
        }
    }
    
    public void UpdateResource(int resourceId, string newTitle, string newAuthor, string newGenre, int newStock)
    {
        var resource = lb.resources.FirstOrDefault(r => r.ResourceId == resourceId);
        if (resource != null)
        {
            resource.Title = newTitle;
            resource.Author = newAuthor;
            resource.Genre = newGenre;
            resource.AvailableStock = newStock;
            Console.WriteLine($"Resource '{resourceId}' has been updated by admin {Name}.");
        }
        else
            Console.WriteLine($"Resource with ID {resourceId} not found.");
    }
    
    public void DeleteResource(int resourceId)
    {
        var resource = lb.resources.FirstOrDefault(r => r.ResourceId == resourceId);
        if (resource != null)
        {
            lb.resources.Remove(resource);
            Console.WriteLine($"Resource '{resourceId}' has been deleted by admin {Name}.");
        }
        else
            Console.WriteLine($"Resource with ID {resourceId} not found.");
    }
    
    public void CheckResourceStock()
    {
        foreach (var resource in lb.resources)
            Console.WriteLine($"Resource '{resource.Title}' has {resource.AvailableStock} available in stock.");
    }
    
    public void UpdateResourceStock(int resourceId, int newStock)
    {
        var resource = lb.resources.FirstOrDefault(r => r.ResourceId == resourceId);
        if (resource != null)
        {
            resource.AvailableStock = newStock;
            Console.WriteLine($"Stock for resource '{resource.Title}' has been updated to {newStock} by admin {Name}.");
        }
        else
            Console.WriteLine($"Resource with ID {resourceId} not found.");
    }
    
    public void RegisterStudent(student newStudent)
    {
        if (!lb.students.Contains(newStudent))
        {
            lb.AddStudent(newStudent);
            Console.WriteLine($"User '{newStudent.Name}' has been registered by admin {Name}.");
        }
        else
            Console.WriteLine($"User '{newStudent.Name}' is already registered.");
    }
    
    public void DeleteInactiveAccounts(int studentId)
    {
        var student = lb.students.FirstOrDefault(r => r.StudentId == studentId);
        if (student != null)
        {
            lb.students.Remove(student);
            Console.WriteLine($"Student '{studentId}' has been deleted by admin {Name}.");
        }
        else
            Console.WriteLine($"Student with ID {studentId} not found.");
    }
    
    public void AddCourseToStudent(int studentId, string courseName, List<student> students)
    {
        var student = students.FirstOrDefault(u => u.UserId == studentId);
        if (student != null)
        {
            student.Courses.Add(courseName);
            Console.WriteLine($"Course '{courseName}' has been added to student {student.Name}.");
        }
        else
            Console.WriteLine($"Student with ID {studentId} not found.");
    }
    
    public void ProcessReservations()
    {
        foreach (var resource in lb.resources)
        {
            if (resource.reservations.Count > 0 && resource.AvailableStock > 0)
            {
                var nextStudentId = resource.GetNextReservation();
                if (nextStudentId.HasValue)
                {
                    var student = lb.students.FirstOrDefault(u => u.UserId == nextStudentId.Value);
                    if (student != null)
                    {
                        lb.BorrowResource(nextStudentId.Value, resource.ResourceId);
                        Console.WriteLine($"Resource '{resource.Title}' has been lent to user '{student.Name}' from the reservation list.");
                    }
                }
            }
        }
    }
}