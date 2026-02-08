/// <summary>
/// A container for the logic of generating prompts for a journal entry. Provides methods for modifying prompt options and randomly selecting a prompt.
/// </summary>
public class PromptGen
{
    /// <summary>
    /// The list of writing prompts stored by the <c>PromptGen</c>
    /// </summary>
    private List<string> _prompts = [];

    /// <summary>
    /// A random number generator for use by the <c>GeneratePrompt()</c> method.
    /// </summary>
    private readonly Random _r = new();

    // <summary>
    // Default constructor <c>PromptGen</c> has five basic hard-coded prompts. Generally should not be used, provided for use as a fallback when necessary for error handling etc.
    // </summary>
    public PromptGen()
    {
        _prompts =
        [
            "What's something unexpected that happened to you today? ",
            "What opportunities to bring joy to others did you take advantage of today? ",
            "How have you been blessed today? ",
            "What is one thing you've accomplished today? ",
            "What are you grateful for today? ",
        ];
    }

    /// <summary>
    /// Initializes a <c>PromptGen</c> from a file.
    /// </summary>
    /// <param name="fileName">the name of the file to initialize from.</param>
    public PromptGen(string fileName)
    {
        try
        {
            string[] lines = File.ReadAllLines(fileName);
            foreach (string s in lines)
            {
                AddPrompt(s);
            }
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("File not found.");
        }
    }

    /// <summary>
    /// Adds a single prompt to the list of prompts.
    /// </summary>
    /// <param name="s">the prompt to add to the list of prompts.</param>
    public void AddPrompt(string s)
    {
        _prompts.Add(s);
    }

    /// <summary>
    /// Reads a file, adding a new prompt to the list of prompts containing the exact text of one line of the file.
    /// </summary>
    /// <param name="fileName">the name of the file to read from.</param>
    public void ReadPrompts(string fileName)
    {
        try
        {
            string[] lines = File.ReadAllLines(fileName);
            foreach (string s in lines)
            {
                AddPrompt(s);
            }
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("File not found.");
        }
    }

    /// <summary>
    /// Clears all prompts from the <c>PromptGen</c>.
    /// </summary>
    public void ClearPrompts()
    {
        _prompts = [];
    }

    /// <summary>
    /// Outputs a random prompt from the list of prompts.
    /// </summary>
    /// <returns>a random prompt from the list of prompts, given by <c>_prompts[_r.Next(0, _prompts.Count)]</c>.</returns>
    public string GeneratePrompt()
    {
        return _prompts[_r.Next(0, _prompts.Count)];
    }
}
