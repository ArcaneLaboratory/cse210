using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Enter your numeric grade. ");
        float grade = float.Parse(Console.ReadLine());
        char letterGrade = ' ';
        char gradeSign = ' ';
        if(grade < 80){
            if(grade < 60) letterGrade = 'F';
            else if(grade < 70) letterGrade = 'D';
            else letterGrade = 'C';
        }else{
            if(grade < 90) letterGrade = 'B';
            else letterGrade = 'A';
        }
        if(letterGrade != 'F'){
            if(grade % 10 >= 7 && letterGrade != 'A') gradeSign = '+';
            else if (grade % 10 < 3) gradeSign = '-';
        }
        Console.Write($"Your grade is {letterGrade}{gradeSign}");
    }
}