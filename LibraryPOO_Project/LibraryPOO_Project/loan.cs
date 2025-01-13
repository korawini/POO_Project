namespace LibraryPOO_Project;

public class loan
{
    private int loanId, userId, resourceId;
    bool isAvailable;
    private DateTime loanDate, dueDate;
    public int LoanId { get => loanId; set => loanId = value; }
    public int UserId { get => userId; set => userId = value; }
    public int ResourceId { get => resourceId; set => resourceId = value; }
    public DateTime DueDate { get => dueDate; set => dueDate = value; }
    public bool IsAvailable { get => isAvailable; set => isAvailable = value; }
    public DateTime LoanDate { get => loanDate; set => loanDate = value; }
    public loan(int loanId, DateTime loanDate, int resourceId, int userId, DateTime dueDate)
    {
        this.loanId = loanId;
        this.loanDate = loanDate;
        this.resourceId = resourceId;
        this.userId = userId;
        this.dueDate = dueDate;
        this.isAvailable = true;
    }
}