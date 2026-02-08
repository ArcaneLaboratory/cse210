class Program
{
    static bool running = true;
    static readonly PromptGen p = new("prompts.txt");
    static Journal j = new();

    static void ShowMenu()
    {
        try
        {
            int choice = int.Parse(
                Utils.GenericPrompt(
                    "--------------------------------\nMenu Options:\n\t1. Write a new journal entry\n\t2. Display current journal entires\n\t3. Save current journal to a file\n\t4. Load journal entires from a file\n\t5. Load prompt generator from a file\n\t6. Exit program"
                )
            );
            switch (choice)
            {
                case 1:
                    string prompt;
                    if (Utils.GetYNResponse("Would you like a prompt?"))
                    {
                        prompt = p.GeneratePrompt();
                        //Console.WriteLine($"Prompt: {prompt}");
                    }
                    else
                    {
                        prompt = "Journal Entry: ";
                    }
                    string response = Utils.GenericPrompt(prompt);
                    j.AddEntry(new Entry(prompt+response));
                    Console.WriteLine("Entry added to journal.");
                    break;
                case 2:
                    j.Display();
                    break;
                case 3:
                    j.WriteToFile(
                        Utils.GenericPrompt("Enter the filename you would like to save to."),
                        Utils.GetYNResponse("Append to existing file? (Responding \"n\" will overwrite existing file)")
                    );
                    Console.WriteLine("Journal entries saved. Entry queue emptied.");
                    j = new();
                    break;
                case 4:
                    if (
                        j.GetEntries().Count > 0
                        && Utils.GetYNResponse(
                            "Do you want to overwrite your currently stored journal entires?"
                        )
                    )
                    {
                        j.ReadFromFile(
                            Utils.GenericPrompt("Enter the filename you would like to read from.")
                        );
                    }
                    else
                    {
                        j.ReadFromFile(
                            Utils.GenericPrompt("Enter the filename you would like to read from."),
                            j
                        );
                    }
                    
                    break;
                case 5:
                    p.ClearPrompts();
                    p.ReadPrompts(Utils.GenericPrompt("Enter the filename you would like to read from."));
                    break;
                case 6:
                    if (j.GetEntries().Count > 0)
                    {
                        if (
                            Utils.GetYNResponse(
                                "You have unsaved journal entries! Are you sure you want to quit?"
                            )
                        )
                        {
                            running = false;
                            Console.WriteLine("Exiting Program.");
                        }
                        else
                        {
                            Console.WriteLine("Returning to menu.");
                        }
                    }
                    else
                    {
                        running = false;
                        Console.WriteLine("Exiting Program;");
                    }
                    break;
                default:
                    Console.WriteLine("Please enter a valid menu option.");
                    break;
            }
        }
        catch (FormatException)
        {
            Console.WriteLine("Please enter a valid menu option.");
        }
    }

    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to your Journal!");
        do
        {
            ShowMenu();
        } while (running);
    }
}
