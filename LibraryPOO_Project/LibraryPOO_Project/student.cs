namespace LibraryPOO_Project;

public class student:user
{   
    private string  name, email;
    private int maxLoans, loanDuration,userId;
    private List <loan> loans = new List<loan>();
    private List <string> courses = new List<string>();
    
    public List<string> Courses { get => courses; set => courses = value; }

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

    public List<loan> Loans
    {
        get => loans;
        set => loans = value;
    }

    public int MaxLoans
    {
        get => maxLoans;
        set => maxLoans = value;
    }

    public int LoanDuration
    {
        get => loanDuration;
        set => loanDuration = value;
    }
    
    public void Penalize()
    {
        MaxLoans = 1;
        Console.WriteLine("User has been penalized. Maximum loans reduced to 1.");
    }
    
    public void CheckPenalties()
    {
        foreach (var loan in Loans)
        {
            if (!loan.IsActive && DateTime.Now > loan.DueDate)
            {
                Penalize();
                break;
            }
        }
    }
    
    public void ViewLoanHistory()
    {
        if (Loans.Count == 0)
        {
            Console.WriteLine("No loan history available.");
            return;
        }

        Console.WriteLine($"Loan history for {Name}:");
        foreach (var loan in Loans)
        {
            var status = loan.IsActive ? "Active" : "Returned";
            Console.WriteLine($"Resource ID: {loan.ResourceId}, Loan Date: {loan.LoanDate.ToShortDateString()}, " +
                              $"Due Date: {loan.DueDate.ToShortDateString()}, Status: {status}");
        }
    }
    
    public student(int userId, string name, string email, List<loan> loans, List<string> courses,int maxLoans, int loanDuration):base(userId,name,email)
    {
        this.maxLoans = maxLoans;
        this.loans = loans;
        this.courses = courses;
        this.loanDuration = loanDuration;
    }
}