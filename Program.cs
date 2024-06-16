using System; // Importing the System namespace
using System.Collections.Generic; // Importing the Collections namespace for using collections like Dictionary and List

class Program
{
    // Created a dictionary to store MLB teams and their details
    static Dictionary<string, List<string>> mlbTeams = new Dictionary<string, List<string>>();

    // Method to populate the dictionary with MLB teams and their details
    static void PopulateDictionary()
    {
        mlbTeams["Boston Red Sox"] = new List<string> { "Fenway Park", "David Ortiz", "Mookie Betts" };
        mlbTeams["New York Yankees"] = new List<string> { "Yankee Stadium", "Derek Jeter", "Aaron Judge" };
        mlbTeams["Houston Astros"] = new List<string> { "Minute Maid Park", "Jose Altuve", "George Springer" };
    }

    // Method to display the contents of the dictionary
    static void DisplayDictionaryContents()
    {
        ICollection<string> teamKeys = mlbTeams.Keys;

        foreach (var k in teamKeys)
        {
            Console.WriteLine($"Team: {k}"); // Prints the team name (key)
            Console.WriteLine("Details:"); // Prints the string 'Details:'
            
            foreach (var d in mlbTeams[k])
            {
                Console.WriteLine($"- {d}"); // Prints the team details (values)
            }
            Console.WriteLine(); // Prints a blank line for better readability
        }
    }

    // Method to insert a new MLB team and its details
   static void AddNewTeam()
    {
        Console.WriteLine("What is the name of the team?");
        String teamName = Console.ReadLine();

        // Checks to see if the team name is already in the dictionary
        if (mlbTeams.ContainsKey(teamName))
        {
            Console.WriteLine($"{teamName} already exists in the dictionary.");
            return;
        }
        Console.WriteLine("What is the stadium of the team?");
        String teamStadium = Console.ReadLine();
        Console.WriteLine("What are two players on the team?");
        String player1 = Console.ReadLine();
        String player2 = Console.ReadLine();
        mlbTeams[teamName] = new List<string> {teamStadium, player1, player2};
    }

    // Method to remove a key from the dictionary
    static void RemoveTeam()
    {
        Console.WriteLine("Enter the name of the team to remove:");
        string teamName = Console.ReadLine().ToLower();
        string keyToRemove = null;

        // Checks case sensitivity
        foreach (var key in mlbTeams.Keys)
        {
            if (key.ToLower() == teamName)
            {
                keyToRemove = key;
                break;
            }
        }

        if (keyToRemove != null)
        {
            mlbTeams.Remove(keyToRemove);
            Console.WriteLine($"{keyToRemove} removed from the dictionary.");
        }
        else
        {
            Console.WriteLine($"{teamName} not found in the dictionary.");
        }
    }

    // Method to add a value to an existing key
    static void AddValueToExistingTeam()
    {
        Console.WriteLine("Enter the name of the team to add a value to:");
        string teamName = Console.ReadLine();
        string keyToUpdate = null;

        // Checks case sensitivity
        foreach (var key in mlbTeams.Keys)
        {
            if (key.ToLower() == teamName.ToLower())
            {
                keyToUpdate = key;
                break;
            }
        }

        if (keyToUpdate != null)
        {
            Console.WriteLine("Enter the value to add:");
            string value = Console.ReadLine();
            mlbTeams[keyToUpdate].Add(value);
            Console.WriteLine($"{value} added to {keyToUpdate}.");
        }
        else
        {
            Console.WriteLine($"{teamName} not found in the dictionary.");
        }
    }

    // Method to sort and display the keys of the dictionary
    static void SortKeys()
    {
        var sortedKeys = new List<string>(mlbTeams.Keys);
        sortedKeys.Sort();
        Console.WriteLine("Sorted Teams:");
        foreach (var key in sortedKeys)
        {
            Console.WriteLine($"{key}: {string.Join(", ", mlbTeams[key])}");
        }
    }

    // Main method to control the program
    static void Main(string[] args)
    {
        PopulateDictionary();
        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("\nChoose an option:");
            Console.WriteLine("1. Display Dictionary Contents");
            Console.WriteLine("2. Remove a Key");
            Console.WriteLine("3. Add a New Key and Value");
            Console.WriteLine("4. Add a Value to an Existing Key");
            Console.WriteLine("5. Sort the Keys");
            Console.WriteLine("6. Exit");

            switch (Console.ReadLine())
            {
                case "1":
                    DisplayDictionaryContents();
                    break;
                case "2":
                    RemoveTeam();
                    break;
                case "3":
                    AddNewTeam();
                    break;
                case "4":
                    AddValueToExistingTeam();
                    break;
                case "5":
                    SortKeys();
                    break;
                case "6":
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }
}

