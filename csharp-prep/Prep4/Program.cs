using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");
        List<float> numberList = [];
        bool flag = true;
        float number = 0;
        float maxNum = 0;
        while (flag)
        {
            Console.Write("Enter number: ");
            number = float.Parse(Console.ReadLine());
            if(number == 0){flag = false;}
            else
            {
                numberList.Add(number);
            }
        }
        float sum = 0;
        foreach(float num in numberList)
        {
            if(sum == 0 || maxNum < num){maxNum = num;}
            sum += num;
        }
        float avg = sum/numberList.Count;
        Console.WriteLine($"The sum is: {sum}");
        Console.WriteLine($"The average is {avg}");
        Console.WriteLine($"The largest number is {maxNum}");
    }
}