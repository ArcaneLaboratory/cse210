public class Journal
{
    public List<Entry> entries;

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
        foreach (Entry e in entries)
        {
            e.Display();
        }
    }

    public void WriteToFile(string fileName)
    {
        foreach (Entry e in entries)
        {
            e.WriteToFile(fileName);
        }
    }

    public void ReadFromFile(string fileName)
    {
        List<Entry> le = new();
        string[] lines = File.ReadAllLines(fileName);
        for(int i = 0; i < lines.Length/2; i++)
        {
            string date = lines[i];
            string text = lines[i+2];
            le.Add(new Entry(text, date));
        }
        AddEntries(le);
    }
}
