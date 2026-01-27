using System;
using System.Globalization;

class Program
{

    static string TitleCase(string input)
    {
        input = input.ToLower();
        List<int> spaces = [-1];
        List<string> chars = new();
        foreach (char item in input)
        {
            chars.Add(item.ToString());
        }
        for (int i = 0; i < input.Length - 1; i++)
        {
            if(input[i] == ' ')
            {
                spaces.Add(i);
            }
        }
        foreach(int item in spaces)
        {
            chars[item+1] = chars[item+1].ToUpper();
        }
        string output = "";
        foreach (string item in chars)
        {
            output += item;
        }
        return output;
    }

    static void Main(String[] args)
    {
       Console.WriteLine($"{TitleCase("hello world")}");
    }


}