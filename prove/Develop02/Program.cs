using System;
using System.IO.Enumeration;
using Microsoft.VisualBasic;

public class Entry
{
    public DateTime _date;
    public string _prompt;
    public string _body;
    public string getPrompt(List<string> _promptList)
    {
        Random rndChoice = new();
        int choice = rndChoice.Next(_promptList.Count);
        return _promptList[choice];
    }
}

class Program
{
    static void Main(string[] args)
    {
        List<string> promptList = new List<string>
        {
        "What out-of-the-ordinary thing happened today (big or small)?",
        "What food did you eat for lunch?",
        "What small act of kindness did you do for someone, or did someone did one for you?"
        };
        int userOption = 1;
        
        Console.WriteLine("Welcome to your jornal");
        while (userOption !=0)
        {
            Console.WriteLine("Enter the number of your choice: ");
            Console.WriteLine("     1. Write a new entry");
            Console.WriteLine("     2. Read journal");
            Console.WriteLine("     3. Save your journal");
            Console.WriteLine("     4. Load your journal");
            Console.WriteLine("     0. Exit");
            userOption = int.Parse(Console.ReadLine());
            if (userOption == 1)
            {
                Entry newEntry = new Entry
                {
                    _date = DateTime.Now,
                };
                newEntry._prompt = newEntry.getPrompt(promptList);
                Console.WriteLine(newEntry._prompt);
                newEntry._body = Console.ReadLine();
            } 
            else if (userOption == 2){}
            else if (userOption == 3)
            {
                Console.WriteLine("Enter the name of your journal: ");
                string journalFile = Console.ReadLine();
                journalFile = journalFile + ".txt";
                using (StreamWriter outputFile = new StreamWriter(journalFile)){}
            }
            else if (userOption == 4){}
            else if (userOption != 0)
            {
                Console.WriteLine("Invalid option, Please try again. ");
                userOption = 1;
            }
        }
    }
}