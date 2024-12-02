using Business.Factories;
using Business.Models;
using Business.Services;

namespace MainApp.Services;
public class MenuService
{
    private readonly ContactService _contactService = new();


    public void StartMenu()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Welcome to the Silicon Contact App!");
            Console.WriteLine(
                "<<<<<<<<<<<<<<<<<<<<>>>>>>>>>>>>>>>>>>>"+"\n" +
                "Press [1] to ADD a contact. \n" +
                "Press [2] to SHOW all contacts. \n" +
                "Press [3] to DELETE all contacts." +"\n" +
                "Press [4] to EXIT the application." + "\n" +
                "<<<<<<<<<<<<<<<<<<<<>>>>>>>>>>>>>>>>>>>");

            string input = Console.ReadLine()!.Trim();

            if (int.TryParse(input, out int menuChoice))
            {
                switch (menuChoice)
                {
                    case 1:
                    AddContact();
                break;
                    case 2:
                    DisplayContacts();
                break;
                    case 3:
                    DeleteContacts();
                break;
                    case 4:
                    ExitApplication();
                break;
                    default:
                    DisplayMessage("Wrong choice! Enter a number between 1 and 3.");
                break;
                }
            }
            else
            {
                DisplayMessage("You have to enter a number!");
            }
        }
    }

    public void AddContact()
    {
        Console.Clear();

        ContactRegistrationForm contactForm = ContactFactory.Create();

        Console.Write("Enter your firstname: ");
        contactForm.FirstName = Console.ReadLine()!;

        Console.Write("Enter your lastname: ");
        contactForm.LastName = Console.ReadLine()!;

        Console.Write("Enter your email: ");
        contactForm.Email = Console.ReadLine()!;

        Console.Write("Enter your phone-number: ");
        contactForm.PhoneNumber = Console.ReadLine()!;

        Console.Write("Enter your Address: ");
        contactForm.Address = Console.ReadLine()!;

        Console.Write("Enter your postal-code: ");
        contactForm.PostalCode = Console.ReadLine()!;

        Console.Write("Enter your city: ");
        contactForm.City = Console.ReadLine()!;

        bool exists = _contactService.Add(contactForm);

        if (exists)
        {
            DisplayMessage("Contact was created!");
        }
        else
        {
            DisplayMessage("Could NOT add the contact!");
        }

    }
    public void DisplayContacts()
    {
        Console.Clear();

        var contactList = _contactService.Display();

        foreach (Contact contact in contactList)
        {
            Console.WriteLine($"{"Id: ",-5}{contact.Id}");
            Console.WriteLine($"{"Firstname: ", -5}{contact.FirstName}");
            Console.WriteLine($"{"Lastname: ",-5}{contact.LastName}");
            Console.WriteLine($"{"Email: ",-5}{contact.Email}");
        }

        Console.ReadKey();
    }
    public void DeleteContacts()
    {
        while (true)
        {
            Console.Clear();

            Console.WriteLine("Do you want to delete all the contacts?");
            string answer = Console.ReadLine()!.ToLower().Trim();

            if (string.IsNullOrWhiteSpace(answer))
            {

                DisplayMessage("You have to enter [y] or [n]");
            }
            else if (answer == "y")
            {
                _contactService.Remove();
                DisplayMessage("\nThe contacts has been removed!");
                return;
            }
            else if (answer == "n") 
            {
                return;
            }
            else
            {
                DisplayMessage($"{answer} is not a valid input");
            }
        }       
    }
    public void ExitApplication()
    {
       
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Are you sure you want to exit? (y/n)");

            string input = Console.ReadLine()!.Trim().ToLower();


            if (string.IsNullOrWhiteSpace(input))
            {
                DisplayMessage("Enter [y] for yes or [n] for no.");

            }
            else if (input == "y")
            {
                Environment.Exit(0);
            }
            else if (input == "n")
            {
                return;
            }
            else
            {
                DisplayMessage($"{input} is not a valid option, Choose [n] or [y]");
            }
        }
    }
    public void DisplayMessage(string message)
    {
        Console.WriteLine(message);
        Console.ReadKey();
    }
}
