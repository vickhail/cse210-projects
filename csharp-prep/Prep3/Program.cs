using System;

class Program
{
    static void Main(string[] args)
    {    
        string response = "yes";

        while (response == "yes")
        {
            Random randomGenerator = new Random();
            int magicNumber = randomGenerator.Next(1, 101);

            int guess = -1;
            int guessCount = 0;

            while (guess != magicNumber)
            {
                guessCount++;

                Console.Write("What is your guess? ");
                guess = int.Parse(Console.ReadLine());

                if (magicNumber > guess)
                {
                    Console.WriteLine("Higher");
                }
                else if (magicNumber < guess)
                {
                    Console.WriteLine("Lower");
                }
                else
                {
                    Console.WriteLine("You guessed it!");
                    Console.WriteLine($"Number of guesses: {guessCount}");

                    Console.Write("Do you want to play again? (yes/no): ");
                    response = Console.ReadLine().ToLower();
                }
            }
        }
    }
}