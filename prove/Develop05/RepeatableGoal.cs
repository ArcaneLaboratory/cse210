public class RepeatableGoal : Goal
{
    protected int _timesCompleted;

    public RepeatableGoal(string name, string desc, int points, int timesCompleted = 0, bool complete = false) : base(name, desc, points, complete)
    {
        _timesCompleted = timesCompleted;
    }

    public override void Display()
    {
        Console.WriteLine($"{_name} ({_desc}): {Checkbox()} Completed {_timesCompleted} times");
    }
    public override string ToString()
    {
        return $"{GetType()}|{_name}|{_desc}|{_pointValue}|{_complete}|{_timesCompleted}";
    }
    public override int RecordCompletion()
    {
        _timesCompleted++;
        return _pointValue;
    }
}