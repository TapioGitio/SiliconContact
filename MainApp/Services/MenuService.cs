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
            Console.WriteLine("<<<<<<<<<<<<<<<<<<<<>>>>>>>>>>>>>>>>>>>");
            Console.WriteLine("");
            Console.WriteLine("Press [1] to ADD a contact.");
            Console.WriteLine("");
            Console.WriteLine("Press [2] to SHOW all contacts.");
            Console.WriteLine("");
            Console.WriteLine("Press [3] to DELETE all contacts.");
            Console.WriteLine("");
            Console.WriteLine("Press [4] to EXIT the application.");
            Console.WriteLine("");
            Console.WriteLine("<<<<<<<<<<<<<<<<<<<<>>>>>>>>>>>>>>>>>>>");

            string input = Console.ReadLine();

            if (int.TryParse(input, out int menuChoice))
            {
                switch (menuChoice)
                {
                    case 1:
                        {
                            Console.Clear ();
                        }
                        break;

                    case 2:
                        {
                            Console.Clear ();
                        }
                        break;

                    case 3:
                        {
                            Console.Clear ();
                        }
                        break;

                    case 4:
                        {
                            ExitApplication();
                        }
                        break;

                    default:
                        {
                            DisplayMessage("Wrong choice! Enter a number between 1 and 4.");
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
