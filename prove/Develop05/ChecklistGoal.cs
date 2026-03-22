public class ChecklistGoal : RepeatableGoal
{
    private int _maxCompletions;
    private int _finalBonus;
    public ChecklistGoal(string name, string desc, int points, int maxCompletions, int finalBonus, int timesCompleted = 0, bool complete = false) : base(name, desc, points, timesCompleted, complete)
    {
        _maxCompletions = maxCompletions;
        _finalBonus = finalBonus;
    }

    public override void Display()
    {
        Console.WriteLine($"{_name} ({_desc}): {Checkbox()} Completed {_timesCompleted} out of {_maxCompletions} times.");
    }
    public override string ToString()
    {
        return $"{GetType()}|{_name}|{_desc}|{_pointValue}|{_complete}|{_timesCompleted}|{_maxCompletions}|{_finalBonus}";
    }
    public override int RecordCompletion()
    {
        if(!_complete){
            int points = _pointValue;
            _timesCompleted++;
            if(_timesCompleted == _maxCompletions)
            {
                _complete = true;
                points += _finalBonus;
            }
            return points;
        }
        return 0;
    }
}
