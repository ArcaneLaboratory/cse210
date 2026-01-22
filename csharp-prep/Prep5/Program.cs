using System;

class Program
{
    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the program!");
    }
    static String PromptUserName()
    {
        Console.Write("Please enter your name: ");
        return Console.ReadLine();
    }
    static int PromptUserNumber()
    {
        Console.Write("Please enter your favorite number: ");
        return int.Parse(Console.ReadLine());
    }
    static void PromptUserBirthYear(out int year)
    {
        Console.Write("Please enter the year you were born: ");
        year = int.Parse(Console.ReadLine());
    } // garbage implementation for something like this
    static int SquareNumber(int input)
    {
        return input*input;
    }
    static void DisplayResult(String name, int sNum, int year)
    {
        Console.WriteLine($"{name}, the square of your number is {sNum}.");
        Console.WriteLine($"{name}, you will turn {2026-year} this year."); //I only need this to work this year don't @ me
    }
    static void Main(string[] args)
    {
        DisplayWelcome();
        
        string uName = PromptUserName();
        int sNumber = SquareNumber(PromptUserNumber());
        int bYear;
        PromptUserBirthYear(out bYear);
        DisplayResult(uName, sNumber, bYear);
    }
}