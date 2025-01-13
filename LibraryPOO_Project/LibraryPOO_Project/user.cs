namespace LibraryPOO_Project;

public class user
{
    private string  name, email;
    private int maxLoans, loanDuration,userId;
    private List <loan> loans = new List<loan>();

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
    
    public user(int userId, string name, string email, List<loan> loans, int maxLoans, int loanDuration)
    {
        this.userId = userId;
        this.name = name;
        this.email = email;
        this.maxLoans = maxLoans;
        this.loans = loans;
    }
}