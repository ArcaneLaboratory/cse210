/// <summary>
/// Represents a single journal entry with its time of creation and contents. Provides methods for accessing the contents of the entry.
/// </summary>
public class Entry
{
    /// <summary>
    /// The text of the <c>Entry</c>.
    /// </summary>
    private string _entryText;
    /// <summary>
    /// The time the <c>Entry</c> was recorded.
    /// </summary>
    private DateTime _entryTime;

    /// <summary>
    /// Default <c>Entry</c> constructor, generally should not be used. Provided for use as a fallback when necessary for error handling etc.
    /// </summary>
    public Entry()
    {
        _entryText = "|";
        _entryTime = DateTime.Now;
    }

    /// <summary>
    /// Initializes an <c>Entry</c> with <c><paramref name="text"/></c> and sets its <c>_entryTime</c> to <c>DateTime.Now</c>.
    /// </summary>
    /// <param name="text">the text to initialize the Entry with.</param>
    public Entry(string text)
    {
        _entryText = text;
        _entryTime = DateTime.Now;
    }

    /// <summary>
    /// Initializes an <c>Entry</c> with <c><paramref name="text"/></c> and sets its <c>_entryTime</c> to the parsing of <c><paramref name="time"/></c>.
    /// </summary>
    /// <param name="text">the text to initialize the Entry with.</param>
    /// <param name="time">a string to parse into the DateTime to intitalize the Entry with.</param>
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

    /// <summary>
    /// Initializes an <c>Entry</c> with <c><paramref name="text"/></c> and sets its <c>_entryTime</c> to <c><paramref name="time"/></c>.
    /// </summary>
    /// <param name="text">the text to initialize the Entry with.</param>
    /// <param name="time">a DateTime to initialize the Entry with.</param>
    public Entry(string text, DateTime time)
    {
        _entryText = text;
        _entryTime = time;
    }

    /// <summary>
    /// Accessor method for the text of an <c>Entry</c>
    /// </summary>
    /// <returns><c>_entryText</c>, the text of the journal entry</returns>
    public string GetText()
    {
        return _entryText;
    }

    /// <summary>
    /// Accessor method for the time of an <c>Entry</c>'s creation
    /// </summary>
    /// <returns><c>_entryTime</c>, the time of the journal entry's creation</returns>
    public DateTime GetTime()
    {
        return _entryTime;
    }

    /// <summary>
    /// Returns a string representing the <c>Entry</c>, formatted as its date followed by its text on a new line.
    /// </summary>
    /// <returns><c>$"{_entryTime}\n{_entryText}"</c></returns>
    public override string ToString()
    {
        return $"{_entryTime}\n{_entryText}";
    }

    /// <summary>
    /// Writes <c>Entry.ToString()</c> to the console.
    /// </summary>
    public void Display()
    {
        Console.WriteLine(ToString());
    }
}
