public class PromptGen
{
    List<string> prompts = new();

    Random r = new();

    public PromptGen()
    {
        prompts = [
            "What's something unexpected that happened to you today?",
            "What opportunities to bring joy to others did you take advantage of today?",
            "How have you been blessed today?",
            "What is one thing you've accomplished today?",
            "What are you grateful for today?"
        ];
    }

    public string GeneratePrompt()
    {
        return prompts[r.Next(0, prompts.Count)];
    }
}