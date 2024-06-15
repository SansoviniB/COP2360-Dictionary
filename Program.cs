using System; // Importing the System namespace for basic functionality
using System.Collections.Generic; // Importing the namespace for using collections like Dictionary and List

class Program
{
    // Dictionary to store MLB teams and their details
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
        // Iterate through each team in the dictionary
        foreach (var team in mlbTeams)
        {
            // Print the team name
            Console.WriteLine($"Team: {team.Key}");
            Console.WriteLine("Details:");
            // Iterate through each detail of the team and print it
            foreach (var detail in team.Value)
            {
                Console.WriteLine($"- {detail}");
            }
            Console.WriteLine(); // Print a blank line for better readability
        }
    }

    // Method to remove a key
    static void RemoveTeam(string teamName)
    {
        if (mlbTeams.ContainsKey(teamName))
        {
            mlbTeams.Remove(teamName);
            Console.WriteLine($"The team '{teamName}' has been removed.");
        }
        else
        {
            Console.WriteLine($"The team '{teamName}' was not found in the dictionary.");
            Console.WriteLine($"Please enter the correct team name you wish to remove.");
            teamName = Console.ReadLine();
            RemoveTeam(teamName);
        }
    }

    // The start of the program
    static void Main(string[] args)
    {
        PopulateDictionary(); // Call the method to populate the dictionary with MLB teams and their details
        DisplayDictionaryContents(); // Call the method to display the contents of the dictionary

        // Call the method to remove the team name and display the dictionary again
        Console.WriteLine("Please enter the team name that you wish to remove: ");
        string teamName = Console.ReadLine();
        RemoveTeam(teamName);
        DisplayDictionaryContents();
    }
}

