class Program
{
    static void Main(string[] args)
    {
        Assignment a = new("Jacob Smith", "Chemistry");
        WritingAssignment wa = new("Eleanor Jones", "American Heritage", "The Revolutionary War");
        MathAssignment ma = new("Parker Johnson", "Integration By Parts", "9.1", "1-4");

        Console.WriteLine(a.GetSummary());
        Console.WriteLine(wa.GetSummary());
        Console.WriteLine(wa.GetWritingInformation());
        Console.WriteLine(ma.GetSummary());
        Console.WriteLine(ma.GetHomeworkList());
    }
}