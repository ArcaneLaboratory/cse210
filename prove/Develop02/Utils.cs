public class Utils
{
    public static bool GetYNResponse(string prompt)
    {
        return GenericPrompt($"{prompt} (y/n)").ToLower().Contains('y');
    }
    public static string GenericPrompt(string prompt)
    {
        Console.WriteLine(prompt);
        Console.Write("> ");
        return Console.ReadLine();
    }
}