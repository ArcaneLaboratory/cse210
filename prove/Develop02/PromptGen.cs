public class PromptGen
{
    private List<string> prompts = [];

    private readonly Random r = new();

    public PromptGen()
    {
        prompts = [
            "What's something unexpected that happened to you today? ",
            "What opportunities to bring joy to others did you take advantage of today? ",
            "How have you been blessed today? ",
            "What is one thing you've accomplished today? ",
            "What are you grateful for today? "
        ];
    }

    public PromptGen(List<string> l)
    {
        prompts = l;
    }

    /// <summary>
    /// Constructor <c>PromptGen</c> overwrites default prompts if <paramref name="overwriteFlag"/> is set to true, otherwise it adds to default prompt list.
    /// </summary>
    public PromptGen(List<string> l, bool overwriteFlag)
    {
        if (overwriteFlag)
        {
            prompts = l;
        }
        else
        {
            prompts.AddRange(l);
        }
    }

    public void AddPrompt(string s)
    {
        prompts.Add(s);
    }

    public void RemovePrompt(int index)
    {
        prompts.RemoveAt(index);
    }

    public void RemovePrompt(string s)
    {
        prompts.Remove(s);
    }

    public void ClearPrompts()
    {
        prompts = [];
    }

    public string GeneratePrompt()
    {
        return prompts[r.Next(0, prompts.Count)];
    }
}