using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your magic number? ");
        int magicNumber = int.Parse(Console.ReadLine());
        bool gameRunning = true;
        int guess;
        while (gameRunning)
        {
            Console.Write("What is your guess? ");
            guess = int.Parse(Console.ReadLine());
            if(magicNumber < guess)
            {
                Console.WriteLine("Lower");
            }
            else if(magicNumber > guess)
            {
                Console.WriteLine("Higher");
            }
            else
            {
                Console.WriteLine("You guessed it!");
                gameRunning = false;
            }
        }
    }
}