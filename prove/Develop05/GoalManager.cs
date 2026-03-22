public class GoalManager
{
    private List<Goal> _goals;
    private int _points;

    public GoalManager()
    {
        _goals = [];
        _points = 0;
    }

    public void AddGoal(Goal g)
    {
        _goals.Add(g);
    }

    public void DisplayGoals()
    {
        int i = 0;
        foreach (Goal goal in _goals)
        {
            Console.Write(i + ".");
            goal.Display();
            i++;
        }
    }

    public void CompleteGoal(int choice)
    {
        AwardPoints(_goals[choice].RecordCompletion());
    }

    public int GetPoints()
    {
        return _points;
    }

    public void AwardPoints(int points)
    {
        Console.WriteLine($"You earned {points} points!");
        _points += points;
    }

    public void SaveGoals(string fileName)
    {
        using StreamWriter file = new(fileName, false);
        foreach (Goal goal in _goals)
        {
            file.WriteLine(goal.ToString());
        }
        file.WriteLine($">Points:{_points}");
    }

    public Goal Load(string[] goal)
    {
        switch (goal[0])
        {
            case "RepeatableGoal":
                return new RepeatableGoal(
                    goal[1],
                    goal[2],
                    int.Parse(goal[3]),
                    int.Parse(goal[5]),
                    bool.Parse(goal[4])
                );
            case "ChecklistGoal":
                return new ChecklistGoal(
                    goal[1],
                    goal[2],
                    int.Parse(goal[3]),
                    int.Parse(goal[6]),
                    int.Parse(goal[7]),
                    int.Parse(goal[5]),
                    bool.Parse(goal[4])
                );
            default:
            Console.WriteLine("1" + goal[0]);
            Console.WriteLine("2" + goal[1]);
            Console.WriteLine("3" + goal[2]);
            Console.WriteLine("4" + goal[3]);
                return new Goal(goal[1], goal[2], int.Parse(goal[3]));
        }
    }

    public Goal GoalBuilder(int type)
    {
        if (type == 1)
        {
            try
            {
                return new Goal(
                    Utils.GenericPrompt("Enter name for your goal."),
                    Utils.GenericPrompt("Enter a short description for your goal."),
                    int.Parse(
                        Utils.GenericPrompt("Enter the number of points for completing this goal.")
                    )
                );
            }
            catch
            {
                return null;
            }
        }
        if (type == 2)
        {
            try
            {
                return new RepeatableGoal(
                    Utils.GenericPrompt("Enter name for your goal."),
                    Utils.GenericPrompt("Enter a short description for your goal."),
                    int.Parse(
                        Utils.GenericPrompt(
                            "Enter the number of points for each time completing this goal."
                        )
                    )
                );
            }
            catch
            {
                return null;
            }
        }
        if (type == 3)
        {
            try
            {
                return new ChecklistGoal(
                    Utils.GenericPrompt("Enter name for your goal."),
                    Utils.GenericPrompt("Enter a short description for your goal."),
                    int.Parse(
                        Utils.GenericPrompt(
                            "Enter the number of points for each time completing this goal."
                        )
                    ),
                    int.Parse(Utils.GenericPrompt("Enter the maximum number of times this goal may be completed.")),
                    int.Parse(Utils.GenericPrompt("Enter the bonus points given on completing the goal the maximum number of times."))
                );
            }
            catch
            {
                return null;
            }
        }
        return null;
    }

    public void LoadGoals(string fileName)
    {
        try
        {
            string[] lines = File.ReadAllLines(fileName);
            foreach (string line in lines)
            {
                string[] l = line.Split("|");
                if (line.Contains(">"))
                {
                    l = line.Split(":");
                    _points = int.Parse(l[1]);
                }
                else
                {
                    AddGoal(Load(l));
                }
            }
        }
        catch (FileNotFoundException)
        {
            Console.Write("File Not Found.");
        }
    }
}
