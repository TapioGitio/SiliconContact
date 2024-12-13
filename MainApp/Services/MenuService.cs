using Business.Factories;
using Business.Interfaces;
using Business.Models;
using MainApp.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace MainApp.Services;
public class MenuService(IContactService contactService) : IMenuService
{
    private readonly IContactService _contactService = contactService;
    public void StartMenu()
    {

        while (true)
        {
            Console.Clear();
            Console.WriteLine("-- Welcome to the Silicon Contact App! --");
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
                    DisplayMessage("Wrong choice! Enter a number between 1 and 5.");
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
        Console.WriteLine("-- Contact Creation --");

        ContactRegistrationForm contactForm = ContactFactory.Create();

        contactForm.FirstName = ValidationProcess("Enter first name: ", nameof(ContactRegistrationForm.FirstName));
        contactForm.LastName = ValidationProcess("Enter last name: ", nameof(ContactRegistrationForm.LastName));
        contactForm.Email = ValidationProcess("Enter your email-address: ", nameof(ContactRegistrationForm.Email));
        contactForm.PhoneNumber = ValidationProcess("Enter your phone number (optional): ", nameof(ContactRegistrationForm.PhoneNumber));
        contactForm.Address = ValidationProcess("Enter your Address (optional): ", nameof(ContactRegistrationForm.Address));
        contactForm.PostalCode = ValidationProcess("Enter your postal code (optional): ", nameof(ContactRegistrationForm.PostalCode));
        contactForm.City = ValidationProcess("Enter your city (optional): ", nameof(ContactRegistrationForm.City));

        _contactService.AddContact(contactForm);
        Console.WriteLine();
        DisplayMessage("The creation of the contact was successful!");
    }

    public string ValidationProcess(string prompt, string propertyName)
    {
        while (true)
        {
            Console.WriteLine();
            Console.Write(prompt);
            var input = Console.ReadLine()!.Trim();

            var results = new List<ValidationResult>();
            var context = new ValidationContext(new ContactRegistrationForm()) { MemberName = propertyName };

            if (Validator.TryValidateProperty(input, context, results))
                return input;

            Console.WriteLine($"{results[0].ErrorMessage}, try again...");
        } 
    }
    public void DisplayContacts()
    {
        Console.Clear();
        Console.WriteLine("-- Contact Storage --");
        Console.WriteLine();


        var contactList = _contactService.Display();

        if (!contactList.Any())
        {
            DisplayMessage("No contacts was found!");
            return;
        }

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
            Console.WriteLine("-- Contact Update --");
            Console.WriteLine();

            Console.Write("Write your firstname to be able to change your email: ");

            string input = Console.ReadLine()!.Trim().ToLower();
            string newEmail;

            if (!string.IsNullOrWhiteSpace(input))
            {

                if (_contactService.ContactExists(input))
                {
                    
                    newEmail = ValidationProcess($"{input} enter your new email: ", nameof(ContactRegistrationForm.Email));

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
                    DisplayMessage($"\nCould not find {input} in the storage.");
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
            Console.WriteLine("-- Contact Deletion --");
            Console.WriteLine();

            Console.WriteLine("Do you want to delete all the contacts? (y/n)");
            string answer = Console.ReadLine()!.ToLower().Trim();

            if (string.IsNullOrWhiteSpace(answer))
            {
                DisplayMessage("You have to enter [y] or [n]");
            }
            else if (answer == "y")
            {
                if(_contactService.Remove())
                {
                    DisplayMessage("\nThe contacts has been removed!");
                    return;
                }
                else
                {
                    DisplayMessage("\nThe storage is empty!");
                }
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
            Console.WriteLine("-- Exit --");
            Console.WriteLine();

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
