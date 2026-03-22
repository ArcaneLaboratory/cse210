class Program
{
    static void Main(string[] args)
    {
        GoalManager gm = new();
        bool running = true;
        int choice;
        while (running)
        {
            try
            {
                choice = int.Parse(
                    Utils.GenericPrompt(
                        $"You currently have {gm.GetPoints()} points.\n\nSelect a menu option:\n\t1. Create a new goal\n\t2.List goals\n\t3.Load goals from file\n\t4.Save goals to file\n\t5.Record goal completion\n\t6. Quit"
                    )
                );
            }
            catch
            {
                choice = 0;
            }

            switch (choice)
            {
                case 1:
                    try
                    {
                        choice = int.Parse(Utils.GenericPrompt("What goal would you like to create?\n\t1. Simple goal\n\t2. Eternal goal\n\t3. Checklist goal"));
                    }
                    catch
                    {
                        choice = 0;
                    }
                    switch (choice)
                    {
                        case 1:
                        break;
                        case 2:
                        break;
                        case 3:
                        break;
                        default:
                        Console.WriteLine("Invalid goal type. Returning to main menu.");
                        break;
                    }
                    break;
                case 2:
                    break;
                case 3:
                    break;
                case 4:
                    break;
                case 5:
                    break;
                case 6:
                    running = false;
                    Console.WriteLine("Goodbye!");
                    break;
                default:
                    Console.WriteLine("Please enter a valid choice.");
                    break;
            }
        }
    }
}
