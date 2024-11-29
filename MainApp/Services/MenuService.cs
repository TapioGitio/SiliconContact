using Business.Factories;
using Business.Models;

namespace MainApp.Services;
public class MenuService
{
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
                "Press [3] to EXIT the application." +"\n" + 
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
        contactForm.FirstName = Console.ReadLine();

        Console.Write("Enter your lastname: ");
        contactForm.LastName = Console.ReadLine();

        Console.Write("Enter your email: ");
        contactForm.Email = Console.ReadLine();

        Console.Write("Enter your phone-number: ");
        contactForm.PhoneNumber = Console.ReadLine();

        Console.Write("Enter your Address: ");
        contactForm.Address = Console.ReadLine();

        Console.Write("Enter your postal-code: ");
        contactForm.PostalCode = Console.ReadLine();

        Console.Write("Enter your city: ");
        contactForm.City = Console.ReadLine();

        ContactEntity contactEntity = ContactFactory.Create(contactForm);
    }

    public void DisplayContacts()
    {
        Console.Clear();
    }
    public void ExitApplication()
    {
       
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Are you sure you want to exit? (y/n)");

            string input = Console.ReadLine().Trim().ToLower();


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
