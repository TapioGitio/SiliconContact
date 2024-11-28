using System.ComponentModel.Design;

namespace MainApp.Services;

public class MenuService
{
    public void Start()
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
            string input = Console.ReadLine();

            if (int.TryParse(input, out int menuChoice))
            {
                switch (menuChoice)
                {
                    case 1:
                        {
                            AddContact();
                        }
                        break;
                    case 2:
                        {
                            DisplayAllContacts();
                        }
                        break;;
                    case 3:
                        {
                            ExitApplication();
                        }
                        break;
                    default:
                        {
                            DisplayMessage("Wrong choice! Enter a number between 1 and 3.");
                        }
                        break;
                }
                DisplayMessage("Press any key to continue");
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
    }

    public void DisplayAllContacts()
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
        Console.Clear();
        Console.WriteLine(message);
        Console.ReadKey();
    }
}
