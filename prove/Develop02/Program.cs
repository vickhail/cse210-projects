using System;
using System.Collections.Generic;
using System.IO;

public class Entry
{
    public DateTime Date { get; set; }
    public string Prompt { get; set; }
    public string Body { get; set; }

    public override string ToString()
    {
        return $"Date: {Date.ToShortDateString()}\nPrompt: {Prompt}\nEntry: {Body}\n";
    }
}

class Program
{
    static List<Entry> journalEntries = new List<Entry>();

    static void Main(string[] args)
    {
        List<string> promptList = new List<string>
        {
            "What out-of-the-ordinary thing happened today (big or small)?",
            "What food did you eat for lunch?",
            "What small act of kindness did you do for someone, or did someone do one for you?"
        };

        Console.WriteLine("Welcome to your journal");
        int userOption;
        do
        {
            Console.WriteLine("\nEnter the number of your choice: ");
            Console.WriteLine("     1. Write a new entry");
            Console.WriteLine("     2. Read journal");
            Console.WriteLine("     3. Save your journal");
            Console.WriteLine("     4. Load your journal");
            Console.WriteLine("     0. Exit");
            
            if (!int.TryParse(Console.ReadLine(), out userOption))
            {
                Console.WriteLine("Invalid input, please enter a number.");
                continue;
            }

            switch (userOption)
            {
                case 1:
                    WriteNewEntry(promptList);
                    break;
                case 2:
                    ReadJournal();
                    break;
                case 3:
                    SaveJournal();
                    break;
                case 4:
                    LoadJournal();
                    break;
                case 0:
                    break;
                default:
                    Console.WriteLine("Invalid option, please try again.");
                    break;
            }
        } while (userOption != 0);
    }

    static void WriteNewEntry(List<string> prompts)
    {
        var prompt = GetRandomPrompt(prompts);
        Console.WriteLine($"Today's Prompt: {prompt}");
        Console.Write("Your Entry: ");
        string body = Console.ReadLine();
        Entry newEntry = new Entry
        {
            Date = DateTime.Now,
            Prompt = GetRandomPrompt(prompts),
            Body = Console.ReadLine()
        };
        journalEntries.Add(newEntry);
    }

    static string GetRandomPrompt(List<string> prompts)
    {
        Random rnd = new Random();
        return prompts[rnd.Next(prompts.Count)];
    }

    static void ReadJournal()
    {
        foreach (var entry in journalEntries)
        {
            Console.WriteLine(entry);
        }
    }

    static void SaveJournal()
    {
        Console.Write("Enter the name of your journal file: ");
        string filename = Console.ReadLine() + ".txt";
        using (StreamWriter file = new StreamWriter(filename))
        {
            foreach (var entry in journalEntries)
            {
                file.WriteLine($"{entry.Date}|{entry.Prompt}|{entry.Body}");
            }
        }
        Console.WriteLine("Journal saved successfully.");
    }

    static void LoadJournal()
    {
        Console.Write("Enter the name of the journal file to load: ");
        string filename = Console.ReadLine() + ".txt";
        if (File.Exists(filename))
        {
            journalEntries.Clear();
            string[] lines = File.ReadAllLines(filename);
            foreach (string line in lines)
            {
                string[] parts = line.Split('|');
                if (parts.Length == 3)
                {
                    journalEntries.Add(new Entry
                    {
                        Date = DateTime.Parse(parts[0]),
                        Prompt = parts[1],
                        Body = parts[2]
                    });
                }
            }
            Console.WriteLine("Journal loaded successfully.");
        }
        else
        {
            Console.WriteLine("File does not exist.");
        }
    }
}
