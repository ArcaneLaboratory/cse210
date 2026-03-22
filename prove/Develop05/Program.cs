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
                        $"You currently have {gm.GetPoints()} points.\n\nSelect a menu option:\n\t1. Create a new goal\n\t2. List goals\n\t3. Load goals from file\n\t4. Save goals to file\n\t5. Record goal completion\n\t6. Quit"
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
                        choice = int.Parse(
                            Utils.GenericPrompt(
                                "Select which goal would you like to create:\n\t1. Simple goal\n\t2. Eternal goal\n\t3. Checklist goal"
                            )
                        );
                    }
                    catch
                    {
                        choice = 0;
                    }
                    if (choice > 0)
                    {
                        Goal temp = gm.GoalBuilder(choice);
                        if (temp != null)
                            gm.AddGoal(temp);
                    }
                    else
                    {
                        Console.WriteLine("Please enter a valid response. Returning to main menu.");
                    }
                    break;
                case 2:
                    gm.DisplayGoals();
                    break;
                case 3:
                    gm.LoadGoals(Utils.GenericPrompt("Enter the filename to read from."));
                    break;
                case 4:
                    gm.SaveGoals(Utils.GenericPrompt("Enter the filename to save to."));
                    break;
                case 5:
                    gm.DisplayGoals();
                    try{
                        gm.CompleteGoal(int.Parse(Utils.GenericPrompt("Which goal did you complete?")));
                    }
                    catch
                    {
                        Console.WriteLine("Please enter a valid response. Returning to main menu.");
                    }
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
