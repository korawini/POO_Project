namespace LibraryPOO_Project;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Globalization;

public class library
{
    public List<resource> resources { get; set; }
    public List<student> students { get; set; }
    public List<loan> loans { get; set; }

    public library()
    {
        resources = new List<resource>();
        students = new List<student>();
    }

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
        //foreach (var s in student)
        {
        //    s.CheckPenalties();
        }
    }
    
    public void BorrowResource(int userId, int resourceId)
    {
        var user = students.FirstOrDefault(u => u.UserId == userId);
        resource resource = resources.FirstOrDefault(r => r.ResourceId == resourceId); //resource

        if (user == null)
            throw new ArgumentException("User not found.");

        if (resource == null)
            throw new ArgumentException("Resource not found.");

        if (resource.AvailableStock <= 0)
        {
            Console.WriteLine($"Resource '{resource.Title}' is not available. Adding user {userId} to the reservation list.");
            resource.AddReservation(userId);
            return;
        }

        if (user.Loans.Count >= user.MaxLoans)
            throw new InvalidOperationException("User has reached the maximum number of loans.");

        DateTime loanDate = DateTime.Now;
        DateTime dueDate = loanDate.AddDays(user.LoanDuration);

        var loan = new loan (loans.Count + 1, loanDate, resource.ResourceId, userId, dueDate);
        loans.Add(loan);

        resource.AvailableStock--;
        user.Loans.Add(loan);
    }
    public void ReturnResource(int loanId)
    {
        var loan = loans.FirstOrDefault(l => l.LoanId == loanId);

        if (loan == null || loan.IsAvailable)
            throw new ArgumentException("Invalid loan ID or resource already returned.");

        var resource = resources.FirstOrDefault(r => r.ResourceId == loan.ResourceId);
        var user = students.FirstOrDefault(u => u.UserId == loan.UserId);

        if (resource == null || user == null)
            throw new InvalidOperationException("Invalid resource or user.");

        loan.IsAvailable = true;
        resource.AvailableStock++;
        user.Loans.Remove(loan);

        if (DateTime.Now > loan.DueDate)
        {
            Console.WriteLine($"Resource returned late. User '{user.Name}' has been penalized.");
            user.Penalize();
        }
        else
        {
            Console.WriteLine($"Resource '{resource.Title}' returned successfully by {user.Name}.");
        }
        var nextUserId = resource.GetNextReservation();
        if (nextUserId.HasValue)
        {
            Console.WriteLine($"Resource '{resource.Title}' is now reserved for user {nextUserId.Value}.");
        }
    }
    /*
    public void SaveData(string resourcesFile, string usersFile)
    {
        try
        {
            var resourcesJson = JsonSerializer.Serialize(resources, new JsonSerializerOptions { WriteIndented = true });
            var usersJson = JsonSerializer.Serialize(users, new JsonSerializerOptions { WriteIndented = true });

            File.WriteAllText(resourcesFile, resourcesJson);
            File.WriteAllText(usersFile, usersJson);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving data: {ex.Message}");
        }
    }

    public void LoadData(string resourcesFile, string usersFile)
    {
        try
        {
            if (File.Exists(resourcesFile))
            {
                var resourcesJson = File.ReadAllText(resourcesFile);
                resources = JsonSerializer.Deserialize<List<book>>(resourcesJson) ?? new List<book>();
            }

            if (File.Exists(usersFile))
            {
                var usersJson = File.ReadAllText(usersFile);
                users = JsonSerializer.Deserialize<List<user>>(usersJson) ?? new List<user>();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading data: {ex.Message}");
        }
    }*/
}