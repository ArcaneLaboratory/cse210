using System.Diagnostics.CodeAnalysis;

public class Entry
{
    public string entryText;
    public DateTime entryTime;

    public Entry()
    {
        entryText = "|";
        entryTime = DateTime.Now;
    }

    public Entry(string text)
    {
        entryText = text;
        entryTime = DateTime.Now;
    }

    public Entry(string text, string time)
    {
        entryText = text;
        DateTime dt;
        if(DateTime.TryParse(time, out dt))
        {
            entryTime = dt;
        }
        else
        {
            entryTime = DateTime.Now;
            Console.WriteLine($"Warning: unable to parse {time} into a DateTime object, reverting to current time");
        }
    }

    public Entry(string text, DateTime time)
    {
        entryText = text;
        entryTime = time;
    }

    public override string ToString()
    {
        return $"{entryTime}:\n{entryText}";
    }

    public void Display()
    {
        Console.WriteLine($"{entryTime}:\n{entryText}");
    }

    public void WriteToFile(string fileName)
    {
        using (StreamWriter file = new StreamWriter(fileName))
        {
            file.WriteLine($"{entryTime}:\n{entryText}");
        }
    }
}
