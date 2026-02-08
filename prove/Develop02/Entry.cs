public class Entry
{
    private string _entryText;
    private readonly DateTime _entryTime;

    public Entry()
    {
        _entryText = "|";
        _entryTime = DateTime.Now;
    }

    public Entry(string text)
    {
        _entryText = text;
        _entryTime = DateTime.Now;
    }

    public Entry(string text, string time)
    {
        _entryText = text;
        if (DateTime.TryParse(time, out DateTime dt))
        {
            _entryTime = dt;
        }
        else
        {
            _entryTime = DateTime.Now;
            Console.WriteLine($"Warning: unable to parse {time} into a DateTime object, reverting to current time");
        }
    }

    public Entry(string text, DateTime time)
    {
        _entryText = text;
        _entryTime = time;
    }

    public override string ToString()
    {
        return $"{_entryTime}\n{_entryText}";
    }

    public void Display()
    {
        Console.WriteLine(ToString());
    }
}
