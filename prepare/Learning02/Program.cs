using System;

class Program
{
    static Job job1 = new("Microsoft", "Software Engineer", 2019, 2022);
    static Job job2 = new("Apple", "Manager", 2022, 2023);
    static Resume resume = new("Allison Rose", [job1, job2]);
    static void Main(string[] args)
    {
        resume.Display();
    }
}