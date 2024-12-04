using Business.Factories;
using Business.Models;
using Business.Services;
using MainApp.Interfaces;

namespace MainApp.Services;
public class MenuService(ContactService contactService) : IMenuService
{
    private readonly ContactService _contactService = contactService;
    public void StartMenu()
    {

        while (true)
        {
            Console.Clear();
            Console.WriteLine("Welcome to the Silicon Contact App!");
            Console.WriteLine(
                "" + "\n" +
                "Press [1] to ADD a contact. \n" +
                "Press [2] to SHOW all contacts. \n" +
                "Press [3] to UPDATE a contact. \n" +
                "Press [4] to DELETE all contacts." + "\n" +
                "Press [5] to EXIT the application." + "\n" +
                "");

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
                        UpdateContact();
                        break;
                    case 4:
                        DeleteContacts();
                        break;
                    case 5:
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
            Console.WriteLine($"{"Firstname: ",-5}{contact.FirstName}");
            Console.WriteLine($"{"Lastname: ",-5}{contact.LastName}");
            Console.WriteLine($"{"Email: ",-5}{contact.Email}");
            Console.WriteLine("");
        }

        Console.ReadKey();
    }

    public void UpdateContact()
    {
        bool run = true;

        while (run)
        {
            Console.Clear();
            Console.Write("Write your firstname to be able to change your email: ");

            string input = Console.ReadLine()!.Trim().ToLower();
            string newEmail;

            if (!string.IsNullOrWhiteSpace(input))
            {

                if (_contactService.IfContactExists(input))
                {

                    Console.Write($"\n{input}, please enter your new email: ");
                    newEmail = Console.ReadLine()!;

                    if (!string.IsNullOrWhiteSpace(newEmail))
                    {
                        _contactService.Update(input, newEmail);
                        DisplayMessage("\nYour email has been updated!");

                        run = false;
                    }
                    else
                    {
                        DisplayMessage("\nInvalid input...");
                    }
                }
                else
                {
                    DisplayMessage("\nThe contact was not found, double-check your spelling..");
                }
            }
            else
            {
                DisplayMessage("Press any key to return to startmenu.");
                run= false;
            }
        }
    }
    public void DeleteContacts()
    {
        while (true)
        {
            Console.Clear();

            Console.WriteLine("Do you want to delete all the contacts? (y/n)");
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
