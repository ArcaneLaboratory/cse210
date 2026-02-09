/// <summary>
/// Represents a journal with a list of <c>Entry</c> objects. Provides methods to query, add, remove, and display those entries, as well as file I/O.
/// </summary>
public class Journal
{
    /// <summary>
    /// The list of all <c>Entry</c> objects currently stored by the <c>Journal</c>.
    /// </summary>
    private List<Entry> _entries;

    /// <summary>
    /// Basic <c>Journal</c> constructor. Initializes <c>_entries</c> to an empty list.
    /// </summary>
    public Journal()
    {
        _entries = new();
    }

    /// <summary>
    /// Initializes a <c>Journal</c> with a single of <c>Entry</c> object.
    /// </summary>
    /// <param name="e">an Entry object to initialize the Journal with.</param>
    public Journal(Entry e)
    {
        _entries = [e];
    }
    /// <summary>
    /// Initializes a <c>Journal</c> with a list of <c>Entry</c> objects.
    /// </summary>
    /// <param name="le">a list of Entry objects to initialize the Journal with. </param>
    public Journal(List<Entry> le)
    {
        _entries = le;
    }

    /// <summary>
    /// Accessor method for the <c>_entries</c> of a <c>Journal</c>.
    /// </summary>
    /// <returns><c>_entries</c>, the list of <c>Entry</c> objects in the <c>Journal</c></returns>
    public List<Entry> GetEntries()
    {
        return _entries;
    }

    /// <summary>
    /// Adds a single <c>Entry</c> object to the journal's <c>_entries</c>.
    /// </summary>
    /// <param name="e">the Entry to add to the journal</param>
    public void AddEntry(Entry e)
    {
        _entries.Add(e);
    }

    /// <summary>
    /// Adds a list of <c>Entry</c> objects to the journal's <c>_entries</c>.
    /// </summary>
    /// <param name="le">a lsit of Entry objects to add to the journal.</param>
    public void AddEntries(List<Entry> le)
    {
        foreach (Entry e in le)
        {
            _entries.Add(e);
        }
    }

    /// <summary>
    /// Iterates through each <c>Entry</c> in <c>_entries</c>, calling their <c>Display()</c> method.
    /// </summary>
    public void Display()
    {
        if (_entries.Count > 0)
        {
            foreach (Entry e in _entries)
            {
                e.Display();
            }
        }
        else
        {
            Console.WriteLine(
                "Your journal is currently empty. Try writing new entries or loading from a file."
            );
        }
    }

    /// <summary>
    /// Writes each <c>Entry</c> of the <c>Journal</c> to the specified file, defaulting to appending to the file if possible.
    /// </summary>
    /// <param name="fileName">the name of the file to write to</param>
    /// <param name="append">if <c>true</c> or not specified, appends to existing file where possible; otherwise, overwrites.</param>
    public void WriteToFile(string fileName, bool append = true)
    {
        using StreamWriter file = new(fileName, append);
        foreach (Entry e in _entries)
        {
            file.WriteLine(e.ToString());
        }
    }

    /// <summary>
    /// Clears existing entries, then reads a file and parses it into a list of <c>Entry</c> objects, then adds the resulting list to the <c>Journal</c>.
    /// </summary>
    /// <param name="fileName">the name of the file to read from.</param>
    public void ReadFromFile(string fileName)
    {
        _entries.Clear();
        try
        {
            List<Entry> le = [];
            string[] lines = File.ReadAllLines(fileName);
            for (int i = 0; i <= lines.Length / 2; i += 2)
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

    /// <summary>
    /// Reads a file and parses it into a list of <c>Entry</c> objects, then adds the resulting list to the <c>Journal</c>.
    /// There doesn't necessarily need to be a separate function for the current program's functionality, so I'm calling my questionable implementation "future-proofing."
    /// I'm very tired. It works. Sue me.
    /// </summary>
    /// <param name="fileName">the name of the file to read from.</param>
    /// <param name="existing">the journal to add the parsed file's contents to.</param>
    public void ReadFromFile(string fileName, Journal existing)
    {
        try
        {
            List<Entry> le = [];
            string[] lines = File.ReadAllLines(fileName);
            for (int i = 0; i < lines.Length / 2; i++)
            {
                string date = lines[i * 2];
                string text = lines[(i * 2) + 1];
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
