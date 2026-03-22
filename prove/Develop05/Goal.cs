public class Goal
{
    protected string _name;
    protected string _desc;
    protected int _pointValue;
    protected bool _complete;
    public Goal(string name, string desc, int points, bool complete = false)
    {
        _name = name;
        _desc = desc;
        _pointValue = points;
        _complete = complete;
    }

    public string Checkbox()
    {
        if (_complete)
        {
            return "[✓]";
        }
        else
        {
            return "[ ]";
        }
    }

    public virtual void Display()
    {
        Console.WriteLine($"{_name} ({_desc}): {Checkbox()}");
    }
    public override string ToString()
    {
        return $"{GetType()}|{_name}|{_desc}|{_pointValue}|{_complete}";
    }

    public virtual int RecordCompletion()
    {
        if(!_complete){
            _complete = true;
            return _pointValue;
        }
        return 0;
    }
}