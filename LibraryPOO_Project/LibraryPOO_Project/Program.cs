using System.Net;
using LibraryPOO_Project;
using System.Text.Json;
wrapper wrapper = new wrapper();
library lb = new library();
wrapper.LoadData(lb);
wrapper.RunMenu(lb);

//var ad = new admin(1,"gica","giga@gmail.com",lb);
//Console.WriteLine(ad.UserId+";"+ad.Name+";"+ad.Email+";");
//wrapper.LoadData(lb);
/*foreach (var resource in lb.Resources)
{
    Console.WriteLine($"Title: {resource.Title}, Author: {resource.Author}, Year: {resource.PublishingDate}");
}

foreach (var student in lb.students)
{
    Console.WriteLine($"Student: {student.UserId}");
    Console.WriteLine($"Email: {student.Email}");
    Console.WriteLine($"Type: {student.Type}");
    Console.WriteLine($"Max Loans: {student.MaxLoans}");
    Console.WriteLine($"Loan Duration: {student.LoanDuration} days");
    Console.WriteLine($"Courses: {string.Join(", ", student.Courses)}");

    Console.WriteLine("Loans:");
    foreach (var loan in student.Loans)
    {
        string loanStatus = loan.IsActive ? "Active" : "Returned";
        Console.WriteLine($"  LoanId: {loan.LoanId}, ResourceId: {loan.ResourceId}, " +
                          $"LoanDate: {loan.LoanDate.ToShortDateString()}, " +
                          $"DueDate: {loan.DueDate.ToShortDateString()}, Status: {loanStatus}");
    }

    Console.WriteLine(); // Linie goală pentru separarea studenților
}
*/

    

// Funcția de încărcare a studenților din fișierul text
        


// Salvăm datele din librărie în fișier
wrapper.SaveData(lb);