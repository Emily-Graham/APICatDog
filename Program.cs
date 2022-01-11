

bool restart = true;

while (restart == true)
{
    //get valid user input

    Console.WriteLine("What animal breeds would you like to read?");
    Console.WriteLine("Enter 0 for cats.");
    Console.WriteLine("Enter 1 for dogs.");

    int userInput = Convert.ToInt32(Console.ReadLine());

    //give user feedback if incorrect
    //if valid (0, 1) select relevant API code


    if (userInput == 0)
    {
        Console.WriteLine("Cat Breeds:");
        // if 0, call Cat API, display cat breeds
        // arrange these into alphabetical order
    }
    else if (userInput == 1)
    {
        Console.WriteLine("Dog Breeds:");
        // if 1, call Dog API, display dog breeds
        // arrange these into alphabetical order
    }
    else
    {
        Console.WriteLine("Please type either 0 (cats) or 1 (dogs) and press enter");
    }

    // Give user options to exit, or continue program (call more results)
    Console.WriteLine("would you like to continue? Type y to continue and hit enter. Hit enter to exit.");
    string userChoice = Console.ReadLine();
    if (userChoice == "y") { restart = true; }
    else if (userChoice != "y") { restart = false; }
};

//refactor sections into individual files? 
