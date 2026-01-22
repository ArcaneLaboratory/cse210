using System;
using System.Globalization;

class Program
{
    static String[][] board = [
        [" ", " ", " "],
        [" ", "X", " "],
        [" ", " ", "O"]
        ];
    static void Main(string[] args)
    {
        //showBoard();
        Console.WriteLine(convertTemp(212.0, "F", "C"));
        Console.WriteLine(convertTemp(212.0, "F", "K"));
        Console.WriteLine(convertTemp(100.0, "C", "F"));
        Console.WriteLine(convertTemp(100.0, "C", "K"));
        Console.WriteLine(convertTemp(100.0, "F", "K"));
        Console.WriteLine(convertTemp(70.0, "F", "F"));
        Console.WriteLine(convertTemp(70.0, "F", "C"));
        Console.WriteLine(convertTemp(-40.0, "F", "C"));
    }

    static void showBoard()
    {
        String line = "";
        Console.WriteLine("-------");
        for (int i = 0; i < board.Length; i++)
        {
            line = "|";
            for(int j = 0; j < board[i].Length; j++)
            {
                line += board[i][j];
                line += "|";
            }
            Console.WriteLine(line);
            line = "-------";
            Console.WriteLine(line);
        }
    }

    static double convertTemp(double input, String inputUnit, String outputUnit)
    {
        Console.Write($"Converting {input}°{inputUnit} to °{outputUnit}: ");
        if (inputUnit == outputUnit){return input;}
        switch (inputUnit)
        {
            case "F": //Farenheit
                input -= 32;
                input /= 1.8;
                break;
            case "K": //Kelvin
                input -= 273.15;
                break;
            default:
                break;
        }
        switch (outputUnit){
            case "K":
                input += 273.15;
                break;
            case "F":
                input *= 1.8;
                input += 32;
                break;
            default:
                break;
        }
        return Math.Round(input, 2);
    }
}