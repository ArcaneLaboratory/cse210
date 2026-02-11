using System;

class Program
{
    static void Main(string[] args)
    {
        Random r = new();
        int numFractions = 500;

        Fraction f1 = new();
        Console.WriteLine(f1.GetFractionString());
        Console.WriteLine(f1.GetDecimalValue());

        Fraction f2 = new(5);
        Console.WriteLine(f2.GetFractionString());
        Console.WriteLine(f2.GetDecimalValue());

        Fraction f3 = new(2, 5);
        Console.WriteLine(f3.GetFractionString());
        Console.WriteLine(f3.GetDecimalValue());

        Fraction f4 = new(1, 7);
        Console.WriteLine(f4.GetFractionString());
        Console.WriteLine(f4.GetDecimalValue());

        Fraction fPrime = new();

        for (int i = 0; i < numFractions; i++)
        {
            fPrime.SetNumerator(r.Next(1, 100));
            fPrime.SetDenominator(r.Next(1, 100));
            Console.WriteLine($"Fraction {i}: {fPrime}");
        }
        {
            //     Nothing to see here....
            //
            //     numFractions = 100000000;
            //     List<Fraction> BigQ = [new(1, 1)];
            //     int n = 1;
            //     int d = 1;
            //     for (int i = 0; i < numFractions; i++)
            //     {
            //         if (n == 1)
            //         {
            //             n = d + 1;
            //             d = 1;
            //         }
            //         else
            //         {
            //             d++;
            //             n--;
            //         }
            //         BigQ.Add(new(n, d));
            //     }
            //     using StreamWriter file = new("BigQ.txt", false);
            //     foreach (Fraction f in BigQ)
            //     {
            //         file.WriteLine(f);
            //         Console.WriteLine(f);
            //     }
            //
        }
    }
}
