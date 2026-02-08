public class PromptGen
{
    private List<string> _prompts = [];

    private readonly Random _r = new();

    public PromptGen()
    {
        _prompts = [
            "What's something unexpected that happened to you today? ",
            "What opportunities to bring joy to others did you take advantage of today? ",
            "How have you been blessed today? ",
            "What is one thing you've accomplished today? ",
            "What are you grateful for today? "
        ];
    }

    public PromptGen(List<string> l)
    {
        _prompts = l;
    }

    /// <summary>
    /// Constructor <c>PromptGen</c> overwrites default prompts if <paramref name="overwriteFlag"/> is set to true, otherwise it adds to default prompt list.
    /// </summary>
    public PromptGen(List<string> l, bool overwriteFlag)
    {
        if (overwriteFlag)
        {
            _prompts = l;
        }
        else
        {
            _prompts.AddRange(l);
        }
    }

    public void AddPrompt(string s)
    {
        _prompts.Add(s);
    }

    public void RemovePrompt(int index)
    {
        _prompts.RemoveAt(index);
    }

    public void RemovePrompt(string s)
    {
        _prompts.Remove(s);
    }

    public void ClearPrompts()
    {
        _prompts = [];
    }

    public string GeneratePrompt()
    {
        return _prompts[_r.Next(0, _prompts.Count)];
    }
}