public class Journal
{
    private List<Entry> entries;

    public Journal()
    {
        entries = new();
    }

    public Journal(Entry e)
    {
        entries = [e];
    }

    public Journal(Entry[] ae)
    {
        for (int i = 0; i < ae.Length; i++)
        {
            entries.Add(ae[i]);
        }
    }

    public Journal(List<Entry> le)
    {
        entries = le;
    }

    public List<Entry> GetEntries()
    {
        return entries;
    }

    public void AddEntry(Entry e)
    {
        entries.Add(e);
    }

    public void AddEntries(Entry[] ae)
    {
        for (int i = 0; i < ae.Length; i++)
        {
            entries.Add(ae[i]);
        }
    }

    public void AddEntries(List<Entry> le)
    {
        foreach (Entry e in le)
        {
            entries.Add(e);
        }
    }

    public void Display()
    {
        if(entries.Count > 0){
        foreach (Entry e in entries)
        {
            e.Display();
        }
        }
        else
        {
            Console.WriteLine("Your journal is currently empty. Try writing new entries or loading from a file.");
        }
    }

    public void WriteToFile(string fileName, bool append = true)
    {
        using StreamWriter file = new(fileName, append);
        foreach (Entry e in entries)
        {
            file.WriteLine(e.ToString());
        }
    }

    public void ReadFromFile(string fileName)
    {
        try
        {
            List<Entry> le = [];
            string[] lines = File.ReadAllLines(fileName);
            for (int i = 0; i <= lines.Length / 2; i+=2)
            {
                string date = lines[i];
                string text = lines[i + 1];
                le.Add(new Entry(text, date));
            }
            AddEntries(le);
            Console.WriteLine($"Journal entries successfully loaded from {fileName}.");
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine($"Could not find a file named {fileName}.");
        }
    }

    public void ReadFromFile(string fileName, Journal existing)
    {
        try
        {
            List<Entry> le = [];
            string[] lines = File.ReadAllLines(fileName);
            for (int i = 0; i < lines.Length / 2; i++)
            {
                string date = lines[i*2];
                string text = lines[(i*2) + 1];
                le.Add(new Entry(text, date));
            }
            existing.AddEntries(le);
            Console.WriteLine($"Journal entries successfully loaded from {fileName}.");
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine($"Could not find a file named {fileName}.");
        }
    }
}
