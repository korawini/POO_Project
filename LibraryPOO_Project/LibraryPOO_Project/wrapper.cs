namespace LibraryPOO_Project;

public class wrapper
{
    private readonly string resourcesFile =
        "C:\\Users\\alexa\\RiderProjects\\POO_Project\\LibraryPOO_Project\\LibraryPOO_Project\\resources.txt";

    private readonly string studentsFile =
        "C:\\Users\\alexa\\RiderProjects\\POO_Project\\LibraryPOO_Project\\LibraryPOO_Project\\StudentsFile.txt";

    private readonly string adminsFile =
        "C:\\Users\\alexa\\RiderProjects\\POO_Project\\LibraryPOO_Project\\LibraryPOO_Project\\admins.txt";

    public void LoadData(library lb)
    {
        
        if (File.Exists(resourcesFile))
        {
            var lines = File.ReadAllLines(resourcesFile); 
            foreach (var line in lines)
            {
                var x = line.Split(';');
                resource resource = null;

                
                switch (x[0])
                {
                    case "book":
                        resource = new book(int.Parse(x[1]), x[2], x[3], x[4], DateTime.Parse(x[5]), int.Parse(x[6]));
                        break;
                    case "magazine":
                        resource = new magazine(int.Parse(x[1]), x[2], x[3], x[4], DateTime.Parse(x[5]),
                            int.Parse(x[6]), x[7], int.Parse(x[8]));
                        break;
                    case "manual":
                        resource = new manual(int.Parse(x[1]), x[2], x[3], x[4], DateTime.Parse(x[5]), int.Parse(x[6]),
                            x[7]);
                        break;
                    case "ebook":
                        resource = new ebook(int.Parse(x[1]), x[2], x[3], x[4], DateTime.Parse(x[5]), int.Parse(x[6]),
                            x[7]);
                        break;
                    default:
                        Console.WriteLine("Invalid resource type");
                        break;
                }

                if (resource != null)
                    lb.AddResource(resource);
            }
        }
        else
        {
            Console.WriteLine("Error loading resources");
        }

        
        if (File.Exists(studentsFile))
    {
        foreach (var line in File.ReadAllLines(studentsFile))
        {
            var lines = line.Split(';');
            var type = lines[0];
            var userId = int.Parse(lines[1]);
            var name = lines[2];
            var email = lines[3];

            
            Console.WriteLine($"Loaded Student: {userId}, {name}, {email}");

           
            var loansList = new List<loan>();
            string loansString = lines[4].Trim('[', ']');
            if (!string.IsNullOrWhiteSpace(loansString))
            {
                var loanEntries = loansString.Split(new[] { "],[" }, StringSplitOptions.RemoveEmptyEntries);
                foreach (var loanStr in loanEntries)
                {
                    var loanParts = loanStr.Split(',');
                    if (loanParts.Length >= 5)
                    {
                        loansList.Add(new loan(
                            int.Parse(loanParts[0].Trim()), 
                            DateTime.Parse(loanParts[1].Trim()), 
                            int.Parse(loanParts[2].Trim()), 
                            int.Parse(loanParts[3].Trim()),
                            DateTime.Parse(loanParts[4].Trim()) 
                        ));
                    }
                }
            }

            
            var courses = lines[5].Trim('[', ']').Split(',').Select(c => c.Trim()).ToList();
            var maxLoans = int.Parse(lines[6]);
            var loanDuration = int.Parse(lines[7]);

            
            var studentObj = new student(type, userId, name, email, loansList, courses, maxLoans, loanDuration);
            lb.AddStudent(studentObj);
        }
    }
    else
    {
        Console.WriteLine("Error loading students");
    }

   
    if (File.Exists(adminsFile))
    {
        foreach (var line in File.ReadAllLines(adminsFile))
        {
            var lines = line.Split(';');
            var userId = int.Parse(lines[0]);
            var name = lines[1];
            var email = lines[2];
            admin admin = new admin(userId, name, email, lb);
            if (admin != null)
                lb.admins.Add(admin);
            else
                Console.WriteLine("Error loading admin");
        }
    }
    else
    {
        Console.WriteLine("Error loading admins");
    }
    }


    public void SaveData(library lb)
    {
        using (StreamWriter writer = new StreamWriter(resourcesFile))
        {
            foreach (var resource in lb.Resources)
            {
                var resourceData =
                    $"{resource.Type};{resource.ResourceId};{resource.Title};{resource.Author};{resource.Genre};{resource.PublishingDate:yyyy-MM-dd};{resource.AvailableStock}";
                switch (resource)
                {
                    case ebook ebook:
                        resourceData += $";{ebook.Link}";
                        break;

                    case magazine magazine:
                        resourceData += $";{magazine.Edition};{magazine.Number}";
                        break;

                    case manual manual:
                        resourceData += $";{manual.Course}";
                        break;
                    default:
                        break;
                }
                writer.WriteLine(resourceData);
            }
        }

        using (StreamWriter writer = new StreamWriter(studentsFile))
        {
            foreach (var student in lb.students)
            {
                var loanString = string.Join("],[",
                    student.Loans.Select(l => $"{l.LoanId},{l.LoanDate:yyyy-MM-dd},{l.ResourceId},{l.UserId},{l.DueDate:yyyy-MM-dd}"));
                loanString = $"[{loanString}]"; 
                var coursesString = $"[{string.Join(",", student.Courses)}]"; 
                var studentData = $"student;{student.UserId};{student.Name};{student.Email};{loanString};{coursesString};{student.MaxLoans};{student.LoanDuration}";
                writer.WriteLine(studentData);
            }
        }
        using (StreamWriter writer = new StreamWriter(adminsFile))
        {
            foreach (var admin in lb.admins)
            {
                var adminData = $"{admin.UserId};{admin.Name};{admin.Email}";
                writer.WriteLine(adminData);
            }
        }
        Console.WriteLine("Data has been successfully saved!");
    }


public void RunMenu(library lb)
    {
        while (true)
        {
            Console.WriteLine("\nWelcome to the Library Management System!");
            Console.WriteLine("1. Log in");
            Console.WriteLine("2. Exit");
            Console.Write("Select an option: ");
            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Enter your ID: ");
                    if (int.TryParse(Console.ReadLine(), out int userId))
                    {
                        var student = lb.students.FirstOrDefault(u => u.UserId == userId);
                        if (student != null)
                            RunStudentMenu(student,lb);
                        else
                        {
                            var adminUser = lb.admins.FirstOrDefault(a => a.UserId == userId);
                            if (adminUser != null)
                                RunAdminMenu(adminUser,lb);
                            else
                                Console.WriteLine("User not found!");
                        }
                    }
                    else
                        Console.WriteLine("Invalid ID format!");

                    break;

                case "2":
                    SaveData(lb);
                    Console.WriteLine("Goodbye!");
                    return;

                default:
                    Console.WriteLine("Invalid option! Please try again.");
                    break;
            }
        }
    }

    private void RunAdminMenu(admin adminUser, library lb)
    {
        while (true)
        {
            Console.WriteLine($"\nWelcome Admin {adminUser.Name}!");
            Console.WriteLine("1. Add resource");
            Console.WriteLine("2. Delete resource");
            Console.WriteLine("3. Update resource stock");
            Console.WriteLine("4. Update resource");
            Console.WriteLine("5. Check resource stock");
            Console.WriteLine("6. Register student");
            Console.WriteLine("7. Delete student");
            Console.WriteLine("8. Add course to student");
            Console.WriteLine("9. Process Reservations");
            Console.WriteLine("10. Log out");
            Console.Write("Select an option: ");
            var choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    bool resourceCreated = false;

                    while (true)
                    {
                        if (resourceCreated)
                        {
                            Console.WriteLine("You have already created a resource. Exiting the program...");
                            break;
                        }

                        Console.WriteLine("Please select the type of resource you want to create:");
                        Console.WriteLine("1. Book");
                        Console.WriteLine("2. Ebook");
                        Console.WriteLine("3. Magazine");
                        Console.WriteLine("4. Manual");
                        Console.WriteLine("5. Exit");
                        Console.Write("Choose an option: ");
                        string choice2 = Console.ReadLine();
                        Console.Write("Enter ID: ");
                        int id = int.Parse(Console.ReadLine());
                        Console.Write("Enter Title: ");
                        string title = Console.ReadLine();
                        Console.Write("Enter Author: ");
                        string author = Console.ReadLine();
                        Console.Write("Enter Genre: ");
                        string genre = Console.ReadLine();
                        Console.Write("Enter Publishing day: ");
                        int dd = int.Parse(Console.ReadLine());
                        Console.Write("Enter Publishing month: ");
                        int m = int.Parse(Console.ReadLine());
                        Console.Write("Enter Publishing year: ");
                        int y = int.Parse(Console.ReadLine());
                        Console.Write("Enter Available Stock: ");
                        int availableStock = int.Parse(Console.ReadLine());
                        switch (choice2)
                        {
                            case "1":
                                book r = new book(id, title, author, genre, new DateTime(y, m, dd),
                                    availableStock);
                                adminUser.AddResources(r);
                                resourceCreated = true;
                                break;
                            case "2":
                                Console.Write("Enter Download Link: ");
                                string link = Console.ReadLine();
                                ebook r2 = new ebook(id, title, author, genre, new DateTime(y, m, dd),
                                    availableStock, link);
                                adminUser.AddResources(r2);
                                resourceCreated = true;
                                break;
                            case "3":
                                Console.Write("Enter Edition: ");
                                string edition = Console.ReadLine();
                                Console.Write("Enter Number: ");
                                int nb = int.Parse(Console.ReadLine());
                                magazine r3 = new magazine(id, title, author, genre, new DateTime(y, m, dd),
                                    availableStock, edition, nb);
                                adminUser.AddResources(r3);
                                resourceCreated = true;
                                break;
                            case "4":
                                Console.Write("Enter Course Name: ");
                                string course = Console.ReadLine();
                                manual r4 = new manual(id, title, author, genre, new DateTime(y, m, dd),
                                    availableStock, course);
                                adminUser.AddResources(r4);
                                resourceCreated = true;
                                break;
                            case "5":
                                Console.WriteLine("Exiting...");
                                return;
                            default:
                                Console.WriteLine("Invalid option, try again.");
                                break;
                        }
                    }
                    break;

                case "2":
                    Console.WriteLine("Enter resource id: ");
                    int idr = int.Parse(Console.ReadLine());
                    adminUser.DeleteResource(idr);
                    break;

                case "3":
                    Console.WriteLine("Enter resource id: ");
                    int idr2 = int.Parse(Console.ReadLine());
                    Console.WriteLine("Enter new stock: ");
                    int ns = int.Parse(Console.ReadLine());
                    adminUser.UpdateResourceStock(idr2, ns);
                    break;

                case "4":
                    Console.WriteLine("Enter resource id: ");
                    int idr3 = int.Parse(Console.ReadLine());
                    Console.Write("Enter Title: ");
                    string title2 = Console.ReadLine();
                    Console.Write("Enter Author: ");
                    string author2 = Console.ReadLine();
                    Console.Write("Enter Genre: ");
                    string genre2 = Console.ReadLine();
                    Console.Write("Enter Available Stock: ");
                    int availableStock2 = int.Parse(Console.ReadLine());
                    adminUser.UpdateResource(idr3, title2, author2, genre2, availableStock2);
                    break;

                case "5":
                    adminUser.CheckResourceStock();
                    break;

                case "6":
                    Console.WriteLine("Enter resource id: ");
                    int idr4 = int.Parse(Console.ReadLine());
                    Console.Write("Enter Name: ");
                    string name = Console.ReadLine();
                    Console.Write("Enter Email: ");
                    string email = Console.ReadLine();
                    var s = new standardUser(idr4, name, email, new List<loan>(), new List<string>());
                    adminUser.RegisterStudent(s);
                    break;

                case "7":
                    Console.WriteLine("Enter student id: ");
                    int idr9 = int.Parse(Console.ReadLine());
                    adminUser.DeleteInactiveAccounts(idr9);
                    break;

                case "8":
                    Console.WriteLine("Enter resource id: ");
                    int idr5 = int.Parse(Console.ReadLine());
                    Console.Write("Enter Course Name: ");
                    string cname = Console.ReadLine();
                    adminUser.AddCourseToStudent(idr5, cname, lb.students);
                    break;

                case "9":
                    adminUser.ProcessReservations();
                    break;
                case "10":
                    Console.WriteLine("Logging out...");
                    return;

                default:
                    Console.WriteLine("Invalid option! Please try again.");
                    break;
            }
        }
    }

    private void RunStudentMenu(student studentUser, library lb)
    {
        while (true)
        {
            Console.WriteLine($"\nWelcome Student {studentUser.Name}!");
            Console.WriteLine("1. Search resources");
            Console.WriteLine("2. Borrow resource");
            Console.WriteLine("3. Return resource");
            Console.WriteLine("4. View loan history");
            Console.WriteLine("5. Log out");
            Console.Write("Select an option: ");
            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    lb.SearchResources(lb);
                    break;

                case "2":
                    Console.WriteLine("Enter resource id: ");
                    int idr6 = int.Parse(Console.ReadLine());
                    lb.BorrowResource(studentUser.UserId, idr6);
                    break;
                

                case "3":
                    Console.WriteLine("Enter loan id: ");
                    int idr7 = int.Parse(Console.ReadLine());
                    lb.ReturnResource(idr7);
                    break;

                case "4":
                    studentUser.ViewLoanHistory();
                    break;

                case "5":
                    Console.WriteLine("Logging out");
                    return;

                default:
                    Console.WriteLine("Invalid option! Option: ");
                    break;
            }
        }
    }
}