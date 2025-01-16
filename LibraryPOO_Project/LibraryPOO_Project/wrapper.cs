using System.Runtime.InteropServices.JavaScript;

namespace LibraryPOO_Project;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

public class wrapper
{
    public library Library { get; private set; } = new library(); // Bibliotecă
    public List<student> Students { get; private set; } = new List<student>(); // Listă studenți
    public List<admin> Admins { get; private set; } = new List<admin>(); // Listă administratori

    // Fișierele pentru salvarea și citirea datelor
    private readonly string resourcesFile = "resources.json";
    private readonly string usersFile = "students.json"; // Fișier pentru studenți
    private readonly string adminsFile = "admins.json"; // Fișier pentru admini

    public void LoadData()
    {
        if (File.Exists(resourcesFile))
        {
            var resourcesJson = File.ReadAllText(resourcesFile);
            Library.resources = JsonSerializer.Deserialize<List<resource>>(resourcesJson, new JsonSerializerOptions
            {
                Converters = { new resourceConverter() },
                PropertyNameCaseInsensitive = true
            }) ?? new List<resource>(); // Asigură că este o listă goală dacă nu există date
        }

        if (File.Exists(usersFile))
        {
            var usersJson = File.ReadAllText(usersFile);
            Students = JsonSerializer.Deserialize<List<student>>(usersJson, new JsonSerializerOptions
            {
                Converters = { new userConverter() },
                PropertyNameCaseInsensitive = true
            }) ?? new List<student>();
        }

        if (File.Exists(adminsFile))
        {
            var adminsJson = File.ReadAllText(adminsFile);
            Admins = JsonSerializer.Deserialize<List<admin>>(adminsJson, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            }) ?? new List<admin>();
        }

        Console.WriteLine("Data loaded successfully.");
    }

    // Salvează datele în fișierele corespunzătoare
    public void SaveData()
    {
        // Salvăm resursele
        var resourcesJson = JsonSerializer.Serialize(Library.resources, new JsonSerializerOptions
        {
            Converters = { new resourceConverter() },
            WriteIndented = true
        });
        File.WriteAllText(resourcesFile, resourcesJson);

        // Salvăm studenții în students.json
        var usersJson = JsonSerializer.Serialize(Students, new JsonSerializerOptions
        {
            Converters = { new userConverter() },
            WriteIndented = true
        });
        File.WriteAllText(usersFile, usersJson);

        // Salvăm administratorii în admins.json
        var adminsJson = JsonSerializer.Serialize(Admins, new JsonSerializerOptions
        {
            WriteIndented = true
        });
        File.WriteAllText(adminsFile, adminsJson);

        Console.WriteLine("Data saved successfully.");
    }
    
    public void RunMenu()
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
                        var user = Students.FirstOrDefault(u => u.UserId == userId);
                        if (user != null)
                            RunStudentMenu(user);
                        else
                        {
                            var adminUser = Admins.FirstOrDefault(a => a.UserId == userId);
                            if (adminUser != null)
                                RunAdminMenu(adminUser);
                            else
                                Console.WriteLine("User not found!");
                        }
                    }
                    else
                        Console.WriteLine("Invalid ID format!");
                    break;

                case "2":
                    SaveData();
                    Console.WriteLine("Goodbye!");
                    return;

                default:
                    Console.WriteLine("Invalid option! Please try again.");
                    break;
            }
        }
    }
    
    private void RunAdminMenu(admin adminUser)
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
                    bool resourceCreated = false;  // Flag to check if a resource has been created

                    while (true)
                    {
                        if (resourceCreated) // If a resource has already been created, exit the loop
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
                                book r = new book(id, title, author, "book", genre, new DateTime(y, m, dd),
                                    availableStock);
                                adminUser.AddResources(r);
                                resourceCreated = true;
                                break;
                            case "2":
                                Console.Write("Enter Download Link: ");
                                string link = Console.ReadLine();
                                ebook r2 = new ebook(id, title, author, "ebook", genre, new DateTime(y, m, dd),
                                    availableStock, link);
                                adminUser.AddResources(r2);
                                resourceCreated = true;
                                break;
                            case "3":
                                Console.Write("Enter Edition: ");
                                string edition = Console.ReadLine();
                                Console.Write("Enter Number: ");
                                int nb = int.Parse(Console.ReadLine());
                                magazine r3 = new magazine(id, title, author, "book", genre, new DateTime(y, m, dd),
                                    availableStock, edition, nb);
                                adminUser.AddResources(r3);
                                resourceCreated = true;
                                break;
                            case "4":
                                Console.Write("Enter Course Name: ");
                                string course = Console.ReadLine();
                                manual r4 = new manual(id, title, author, "book", genre, new DateTime(y, m, dd),
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
                    adminUser.UpdateResourceStock(idr2,ns);
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
                    adminUser.UpdateResource(idr3,title2,author2,genre2,availableStock2);
                    break;
                
                case "5":
                    adminUser.CheckResourceStock();
                    break;
                
                case "6":
                    Console.WriteLine("Enter resource id: ");
                    int idr4 = int.Parse(Console.ReadLine());
                    Console.Write("Enter Name: ");  
                    string name = Console.ReadLine();
                    Console.Write("Enter Emal: ");
                    string email = Console.ReadLine();
                    var s = new standardUser(idr4, name, email, new List<loan>(), new List<string>());
                    adminUser.RegisterStudent(s);
                    break;
                
                case "7":
                    //adminUser.DeleteInactiveAccounts();
                    break;

                case "8":
                    Console.WriteLine("Enter resource id: ");
                    int idr5 = int.Parse(Console.ReadLine());
                    Console.Write("Enter Course Name: ");  
                    string cname = Console.ReadLine();
                    adminUser.AddCourseToStudent(idr5,cname,Students);
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
    
    private void RunStudentMenu(student studentUser)
    {
        while (true)
        {
            Console.WriteLine($"\nWelcome Student {studentUser.Name}!");
            Console.WriteLine("1. Search resources");
            Console.WriteLine("2. Borrow resource");
            Console.WriteLine("3. Reserve resource");
            Console.WriteLine("4. Return resource");
            Console.WriteLine("5. View loan history");
            Console.WriteLine("6. Log out");
            Console.Write("Select an option: ");
            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                   // Library.SearchResources();
                    break;

                case "2":
                    Console.WriteLine("Enter resource id: ");
                    int resourceid = (int)(Console.ReadLine());
                    Library.BorrowResource(studentUser.UserId,resourceid);
                    break;

                case "4":
                    Library.ReturnResource();
                    break;

                case "5":
                    studentUser.ViewLoanHistory();
                    break;

                case "6":
                    Console.WriteLine("Logging out");
                    return;

                default:
                    Console.WriteLine("Invalid option! Option: ");
                    break;
            }
        }
    }
}