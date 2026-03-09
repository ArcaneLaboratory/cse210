public class ListingActivity : Activity
{
    private Random r = new();
    private List<string> _prompts = [];
    private List<string> _responses = [];

    public ListingActivity(string promptFile = "prompts.txt")
        : base(
            "Listing",
            "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area."
        )
    {
        string[] lines = [];
        try
        {
            lines = File.ReadAllLines(promptFile);
        }
        catch
        {
            Console.WriteLine("File not found or malformed. Creating default prompts file \"prompts.txt\".");
            using StreamWriter file = new("prompts.txt");
            file.WriteLine("Who are people that you appreciate?");
            file.WriteLine("What are personal strengths of yours?");
            file.WriteLine("Who are people that you have helped this week?");
            file.WriteLine("When have you felt the Holy Ghost this month?");
            file.WriteLine("Who are some of your personal heroes?");
            file.Close();
            lines = File.ReadAllLines("prompts.txt");
        }
        finally
        {
            foreach (string line in lines)
            {
                _prompts.Add(line);
            }
        }
    }

    public override void DisplayActivity()
    {
        Console.WriteLine("\n List as many responses as you can to the following prompt: ");
        Console.WriteLine($"--- {_prompts[r.Next(_prompts.Count)]} ---\n");
        Console.Write("You may begin in ");
        for(int i = 5; i >= 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
        DateTime future = DateTime.Now.AddSeconds(_duration);
        while(DateTime.Now < future)
        {
            string r = Utils.GenericPrompt("");
            _responses.Add(r);
        }
        Console.WriteLine($"\n You listed {_responses.Count} items.");
        if(Utils.GetYNResponse("Save your responses to file?"))
        {
            using StreamWriter file = new(Utils.GenericPrompt("Enter file name to save to. "));
            foreach(string s in _responses)
            {
                file.WriteLine(s);
            }
        }
    }
}
