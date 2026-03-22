public class GoalManager
{
    private List<Goal> _goals;
    private int _points;

    public GoalManager()
    {
        _goals = [];
        _points = 0;
    }

    public List<Goal> GetGoals()
    {
        return _goals;
    }

    public void DisplayGoals()
    {
        foreach(Goal goal in _goals)
        {
            goal.Display();
        }
    }

    public int GetPoints()
    {
        return _points;
    }

    public void SaveGoals(string fileName)
    {
        using StreamWriter file = new(fileName, false);
        foreach(Goal goal in _goals)
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
                return new RepeatableGoal(goal[1], goal[2], int.Parse(goal[3]), int.Parse(goal[5]), bool.Parse(goal[4]));
            case "ChecklistGoal":
                return new ChecklistGoal(goal[1], goal[2], int.Parse(goal[3]), int.Parse(goal[6]), int.Parse(goal[7]), int.Parse(goal[5]), bool.Parse(goal[4]));
            default:
                return new Goal(goal[1], goal[2], int.Parse(goal[3]));
        }
    }
    
    public void LoadGoals(string fileName)
    {
        try
        {
            string[] lines = File.ReadAllLines(fileName);
            foreach(string line in lines)
            {
                string[] l = line.Split("|");
                if (l.Contains(">Points:"))
                {
                    l.Split(":");
                    _points = int.Parse(l[1]);
                }
                else
                {
                    _goals.Add(Load(l));
                }
            }
        }
        catch(FileNotFoundException)
        {
            Console.Write("File Not Found.");
        }
    }
}