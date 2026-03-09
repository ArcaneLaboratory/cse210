public class ReflectionActivity : Activity
{
    private Random r = new();
    private List<string> _prompts = [];
    private List<string> _questions = [];

    public ReflectionActivity(
        string promptFile = "reflection_prompts.txt",
        string questionFile = "reflection_questions.txt"
    )
        : base(
            "Reflection",
            "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life."
        )
    {
        string[] lines = [];
        try
        {
            lines = File.ReadAllLines(promptFile);
        }
        catch
        {
            Console.WriteLine(
                "Files not found or malformed. Creating default prompts file \"reflection_prompts.txt\"."
            );
            using StreamWriter file = new("reflection_prompts.txt");
            file.WriteLine("Think of a time when you stood up for someone else.");
            file.WriteLine("Think of a time when you did something really difficult.");
            file.WriteLine("Think of a time when you helped someone in need.");
            file.WriteLine("Think of a time when you did something truly selfless.");
            file.Close();
            lines = File.ReadAllLines("reflection_prompts.txt");
        }
        finally
        {
            foreach (string line in lines)
            {
                _prompts.Add(line);
            }
        }
        try
        {
            lines = File.ReadAllLines(questionFile);
        }
        catch
        {
            Console.WriteLine(
                "Files not found or malformed. Creating default prompts file \"reflection_prompts.txt\"."
            );
            using StreamWriter file = new("reflection_questions.txt");
            file.WriteLine("Why was this experience meaningful to you?");
            file.WriteLine("Have you ever done anything like this before?");
            file.WriteLine("How did you get started?");
            file.WriteLine("How did you feel when it was complete?");
            file.WriteLine(
                "What made this time different than other times when you were not as successful?"
            );
            file.WriteLine("What is your favorite thing about this experience?");
            file.WriteLine(
                "What could you learn from this experience that applies to other situations?"
            );
            file.WriteLine("What did you learn about yourself through this experience?");
            file.WriteLine("How can you keep this experience in mind in the future?");
            file.Close();
            lines = File.ReadAllLines("reflection_questions.txt");
        }
        finally
        {
            foreach (string line in lines)
            {
                _questions.Add(line);
            }
        }
    }

    public override void DisplayActivity()
    {
        Console.WriteLine("Consider the following prompt: ");
        Console.WriteLine($"{_prompts[r.Next(_prompts.Count)]}\n");
        _ = Utils.GenericPrompt("When you have something in mind, press enter to continue.");
        Console.WriteLine(
            "\nPonder on each of the following questions as they relate to your experience."
        );
        _ = Utils.GenericPrompt("Press enter when you are ready to begin pondering.");
        Console.Clear();
        DateTime now = DateTime.Now;
        DateTime future = now.AddSeconds(_duration);
        while (now < future)
        {
            now = DateTime.Now;
            Console.Write($"\n{_questions[r.Next(_prompts.Count)]} ");
            Utils.Spinner(8);
        }
    }
}
