namespace LibraryPOO_Project;
public class library
{
    public List<resource> resources;
    public List<student> students;
    public List<admin> admins;
    public List<loan> loans;


    public library()
    {
        resources = new List<resource>();
        students = new List<student>();
        loans = new List<loan>();
        admins = new List<admin>();
    }

    public List<resource> Resources  { get => resources; }

public void AddResource(resource resourcex)
    {
        if (!resources.Contains(resourcex))
            resources.Add(resourcex);
    }

    public void AddStudent(student student)
    {
        if (!students.Contains(student))
            students.Add(student);
    }

    public void AddLoan(loan loan)
    {
        if(!loans.Contains(loan))
            loans.Add(loan);
    }

    public void CheckAllPenalties()
    {
        foreach (var s in students)
        {
            s.CheckPenalties();
        }
    }

    public void BorrowResource(int studentId, int resourceId)
    {
        if (studentId != null && resourceId != null)
        {
            var user = students.FirstOrDefault(u => u.StudentId == studentId);
            resource resource = resources.FirstOrDefault(r => r.ResourceId == resourceId); 


            if (user == null)
                throw new ArgumentException("Student not found.");

            if (resource == null)
                throw new ArgumentException("Resource not found.");

            if (resource.AvailableStock <=
                0) 
            {
                Console.WriteLine(
                    $"Resource '{resource.Title}' is not available. Adding user {studentId} to the reservation list.");
                resource.AddReservation(studentId);
                return;
            }

            if (user.Loans.Count >= user.MaxLoans)
                throw new InvalidOperationException("User has reached the maximum number of loans.");

            DateTime loanDate = DateTime.Now;
            DateTime dueDate = loanDate.AddDays(user.LoanDuration);

            var loan = new loan(loans.Count + 1, loanDate, resource.ResourceId, studentId, dueDate);
            loans.Add(loan);

            resource.AvailableStock--;
            user.Loans.Add(loan);
            resource.ShowResourceDetails(resource);
        }
        else Console.WriteLine("User or resource doesnt exist.");
}
    public void ReturnResource(int loanId)
    {
        var loan = loans.FirstOrDefault(l => l.LoanId == loanId);

        if (loan == null || !loan.IsActive)
            throw new ArgumentException("Invalid loan ID or resource already returned.");

        var resource = resources.FirstOrDefault(r => r.ResourceId == loan.ResourceId);
        var user = students.FirstOrDefault(u => u.UserId == loan.UserId);

        if (resource == null || user == null)
            throw new InvalidOperationException("Invalid resource or user.");

        loan.IsActive = false;
        resource.AvailableStock++;

        if (DateTime.Now > loan.DueDate)
        {
            Console.WriteLine($"Resource returned late. User '{user.Name}' has been penalized.");
            user.Penalize();
        }
        else
            Console.WriteLine($"Resource '{resource.Title}' returned successfully by {user.Name}.");
        
        var nextUserId = resource.GetNextReservation();
        if (nextUserId.HasValue)
            Console.WriteLine($"Resource '{resource.Title}' is now reserved for user {nextUserId.Value}.");
    }
    public void SearchResources(library lb)
    {
        Console.WriteLine("Search Resources:");
        Console.WriteLine("1. Show Resources");
        Console.WriteLine("2. Filter Resources");
        Console.Write("Choose one of the following options(1 or 2): ");
        var choice = Console.ReadLine();

        List<resource> filteredResources = lb.Resources;
        if (choice == "2")
        {
            Console.Write("What type of resource do you want to search?(manual,carte): ");
            string resourceType = Console.ReadLine();
            filteredResources = lb.Resources.Where(r => r.Type.Equals(resourceType, StringComparison.OrdinalIgnoreCase)).ToList();
        }
        if (filteredResources.Any())
        {
            Console.WriteLine("\nResources found: ");
            foreach (var resource in filteredResources)
                Console.WriteLine($"ID: {resource.ResourceId}, Titlu: {resource.Title}, Tip: {resource.Type}, Stoc disponibil: {resource.AvailableStock}, Autor: {resource.Author}, An Publicare: {resource.PublishingDate}");
        }
        else
            Console.WriteLine("No resources found.");
    }
}